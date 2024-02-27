using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService1.Data;
using PaymentService1.Entities;
using PaymentService1.Models;
using PaymentService1.ServiceCalls;

namespace PaymentService1.Controllers
{
    [ApiController]
    [Route("api/uplate")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository uplataRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();
        public UplataController(IUplataRepository uplataRepository, LinkGenerator linkGenerator, IMapper mapper, ILogerService loggerService)
        {
            this.uplataRepository = uplataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;


        }
        /// <summary>
        /// Vraca sve uplate
        /// </summary>
        /// <returns>Lista uplata</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<UplataDto>> getUplate()
        {
            message.method = "GET";

            var uplate = uplataRepository.getAllUplate();
            if (uplate == null || uplate.Count == 0)
            {
                message.information = "Nema uplata";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            message.information = "Lista uplata";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<UplataDto>>(uplate));
        }
        /// <summary>
        /// Vraca uplatu sa zeljenim id-jem
        /// </summary>
        /// <param name="uplataId">Id uplate</param>
        /// <returns>Tacno jednu uplatu</returns>
        [HttpGet("{uplataId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UplataDto> getUplataById(Guid uplataId)
        {
            message.method = "GET";
            var u = uplataRepository.getUplataById(uplataId);
            if (u == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }
            message.information = "Uplata je vracena";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<UplataDto>(u));
        }
        /// <summary>
        /// Kreiranje nove uplate
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o kreiranoj uplati</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove uplate
        /// {
        ///"brojRacuna": "1111",
        ///"pozivNaBroj": "121212",
        ///"iznos": 20500,
        ///"uplatilac": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"svrhaUplate": "svrha uplate1",
        ///"datum": "2023-02-13T14:19:26.242Z",
        ///"javnoNadmetanje": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///}
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataDto> postKontaktOsoba([FromBody] UplataCreationDto uplata)
        {
            message.method = "POST";
            try
            {
                var u = mapper.Map<Uplata>(uplata);
                var confirmation = uplataRepository.postUplata(u);
                string location = linkGenerator.GetPathByAction("getUplate", "Uplata", new { uplataId = confirmation.UplataID });
                message.information = "Uplata je uspesno izvrsena";
                loggerService.CreateMessage(message);
                return Created(location, mapper.Map<UplataConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
        /// <summary>
        /// Brisanje uplate
        /// </summary>
        /// <param name="uplataId">Id uplate</param>
        /// <returns></returns>
        [HttpDelete("{uplataId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteUplata(Guid uplataId)
        {
            message.method = "DELETE";
            try
            {
                var u = uplataRepository.getUplataById(uplataId);
                if (u == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                uplataRepository.deleteUplata(uplataId);
                message.information = "Uplata je obrisana";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Modifikovanje uplate
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o modifikovanoj uplati</returns>
        /// <remarks>
        /// Primer zahteva za modifikovanje uplate
        /// {
        /// "uplataID": "a215e4cb-a427-40cf-88b2-8488d140a939",
        ///"brojRacuna": "1122564",
        ///"pozivNaBroj": "12000",
        ///"iznos": 23000,
        ///"uplatilac": "a215e4cb-a427-40cf-88b2-8488d140a939",
        ///"svrhaUplate": "svrha1",
        ///"datum": "2023-02-13T14:20:40.417Z",
        ///"javnoNadmetanje": "a215e4cb-a427-40cf-88b2-8488d140a939"
        ///}
        /// </remarks>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UplataConfirmation> putUplata(Uplata uplata)
        {
            message.method = "PUT";
            try
            {
                if (uplataRepository.getUplataById(uplata.UplataID) == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                message.information = "Uplata je uspesno izmenjena";
                loggerService.CreateMessage(message);
                return Ok(uplataRepository.updateUplata(uplata));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
