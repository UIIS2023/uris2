using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService1.Data;
using PaymentService1.Entities;
using PaymentService1.Models;
using PaymentService1.ServiceCalls;

namespace PaymentService1.Controllers
{
    [ApiController]
    [Route("api/kursneListe")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class KursnaListaController : ControllerBase
    {
        private readonly IKursnaListaRepository kursnaListaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();
        public KursnaListaController(IKursnaListaRepository kursnaListaRepository, LinkGenerator linkGenerator, IMapper mapper, ILogerService logerService)
        {
            this.kursnaListaRepository = kursnaListaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;

        }
        /// <summary>
        /// Vraca sve kursne liste
        /// </summary>
        /// <returns>Lista kurseva</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<KursnaListaDto>> getKurs()
        {
            message.method = "GET";

            var kurs = kursnaListaRepository.getAllKurs();
            if (kurs == null || kurs.Count == 0)
            {
                message.information = "Nema kursnih listi";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            message.information = "Lista kursnih listi";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<KursnaListaDto>>(kurs));
        }
        /// <summary>
        /// Vraca kurs sa zeljenim id-jem
        /// </summary>
        /// <param name="kursnaListaId">Id kursa</param>
        /// <returns>Tacno jedan kurs</returns>
        [HttpGet("{kursnaListaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<KursnaListaDto> getKursById(Guid kursnaListaId)
        {
            message.method = "GET";
            var kurs = kursnaListaRepository.getKursById(kursnaListaId);
            if (kurs == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }
            message.information = "Kurs je vracen";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KursnaListaDto>(kurs));
        }
        /// <summary>
        /// Kreiranje novog kursa
        /// </summary>
        /// <param name="kurs">Model kursne liste</param>
        /// <returns>Potvrda o kreiranju novog kursa</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog kursa
        ///{
        ///"datum": "2023-02-13T14:26:46.623Z",
        ///"valuta": "Romanian lei",
        ///"vrednost": 24
        ///}
        /// </remarks>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KursnaListaDto> postKurs([FromBody] KursnaListaCreationDto kurs)
        {
            message.method = "POST";
            try
            {
                var ku = mapper.Map<KursnaLista>(kurs);
                var confirmation = kursnaListaRepository.postKurs(ku);
                string location = linkGenerator.GetPathByAction("getKurs", "KursnaLista", new { kursnaListaId = confirmation.KursnaListaID });
                message.information = "Kurs je uspesno izvrsen";
                loggerService.CreateMessage(message);
                return Created(location, mapper.Map<KursnaListaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
        /// <summary>
        /// Brisanje kursa
        /// </summary>
        /// <param name="kursnaListaId">Id kursa</param>
        /// <returns></returns>
        [HttpDelete("{kursnaListaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKurs(Guid kursnaListaId)
        {
            message.method = "DELETE";
            try
            {
                var k = kursnaListaRepository.getKursById(kursnaListaId);
                if (k == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                kursnaListaRepository.deleteKurs(kursnaListaId);
                message.information = "Kursna lista je obrisana";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Modifikovanje kursa
        /// </summary>
        /// <param name="kurs">Model kursne liste</param>
        /// <returns>Potvrda o modifikovanoj kursnoj listi</returns>
        /// <remarks>
        /// Primer zahteva za modifikovanje kursa
        /// {
        ///"kursnaListaID": "1de13266-85e8-4120-8b1f-daacc32c5811",
        ///"datum": "2023-02-13T14:28:31.166Z",
        ///"valuta": "Euro",
        ///"vrednost": 117
        ///}
        /// </remarks>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KursnaListaConfirmation> putKurs(KursnaLista kurs)
        {
            message.method = "PUT";
            try
            {
                if (kursnaListaRepository.getKursById(kurs.KursnaListaID) == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                message.information = "Kurs je uspesno izmenjen";
                loggerService.CreateMessage(message);
                return Ok(kursnaListaRepository.updateKurs(kurs));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

    }
}
