using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/odvodnjavanje")]
    [Produces("application/json", "application/xml")]
    public class OdvodnjavanjeController : ControllerBase 
    {
        private readonly IOdvodnjavanjeRepository odvodnjavanjeRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Odvodnjavanje";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public OdvodnjavanjeController(IOdvodnjavanjeRepository odvodnjavanjeService, IMapper mapper, ILogerService loggerService)
        {
            this.odvodnjavanjeRepository = odvodnjavanjeService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sva odvodnjavanja.
        /// </summary>
        /// <returns>Lista odvodnjavanja.</returns>
        /// <response code="200">Vraca listu odvodnjavanja.</response>
        /// <response code="204">Nije pronadjeno ni jedno odvodnjavanje.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<OdvodnjavanjeDto>> getAllOdvodnjavanje()
        {
            List<Entities.Odvodnjavanje> odvodnjavanja = odvodnjavanjeRepository.getAllOdvodnjavanje();
            message.serviceName = naziv;
            message.method = "GET";

            if (odvodnjavanja == null || odvodnjavanja.Count == 0)
            {
                message.information = "Nema odvodnjavanja.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista odvodnjavanja";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<OdvodnjavanjeDto> odvodnjavanjaDto = mapper.Map<List<OdvodnjavanjeDto>>(odvodnjavanja);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<OdvodnjavanjeDto>>(odvodnjavanjaDto));
        }

        /// <summary>
        /// Vraca jedno odvodnjavanje na osnovu ID-ja.
        /// </summary>
        /// // <param name="odvodnjavanjeId">ID odvodnjavanja</param>
        /// <returns>Trazeno odvodnjavanje</returns>
        /// <response code="200">Trazeno odvodnjavanje je uspesno pronadjeno.</response>
        /// <response code="404">Trazeno odvodnjavanje nije pronadjeno.</response>
        [HttpGet("{odvodnjavanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OdvodnjavanjeDto> getOdvodnjavanjeByID(Guid odvodnjavanjeId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.Odvodnjavanje odvodnjavanje = odvodnjavanjeRepository.getOdvodnjavanjeByID(odvodnjavanjeId);

            if (odvodnjavanje == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            OdvodnjavanjeDto odvodDto = mapper.Map<OdvodnjavanjeDto>(odvodnjavanje);
            message.information = "Odvodnjavanje je vraceno.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<OdvodnjavanjeDto>(odvodDto));

        }

        /// <summary>
        /// Brise odvodnjavanje.
        /// </summary>
		/// <param name="odvodnjavanjeId">ID odvodnjavanja</param>
        /// <response code="204">Uspesno izvrseno brisanje odvodnjavanja.</response>
        /// <response code="404">Nije pronadjeno odvodnjavanje sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja odvodnjavanja.</response>
        [HttpDelete("{odvodnjavanjeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteOdvodnjavanje(Guid odvodnjavanjeId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.Odvodnjavanje odvodnjavanje = odvodnjavanjeRepository.getOdvodnjavanjeByID(odvodnjavanjeId);

                if (odvodnjavanje == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                odvodnjavanjeRepository.deleteOdvodnjavanje(odvodnjavanjeId);
                odvodnjavanjeRepository.saveChanges();
                message.information = "Odvodnjavanje je obrisano.";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }

        /// <summary>
        /// Updatuje odvodnjavanje.
        /// </summary>
		/// <param name="odvodnjavanjeDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjeno odvodnjavanje.</returns>
        /// <response code="200">Updatovanje odvodnjavanja je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjeno odvodnjavanje sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja odvodnjavanja.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OdvodnjavanjeDto> putOdvodnjavanje(OdvodnjavanjeDto odvodnjavanjeDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.Odvodnjavanje oldOdvod = odvodnjavanjeRepository.getOdvodnjavanjeByID(odvodnjavanjeDto.odvodnjavanjeID);

                if (oldOdvod == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.Odvodnjavanje odvodnjavanje = mapper.Map<Entities.Odvodnjavanje>(odvodnjavanjeDto);
                mapper.Map(odvodnjavanje, oldOdvod);
                odvodnjavanjeRepository.saveChanges();
                message.information = "Odvodnjavanje je uspesno izmenjeno.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novo odvodnjavanje.
        /// </summary>
		/// <param name="odvodnjavanjeDto">Body koji sadzi odvodnjavanje koje treba da se kreira.</param>
        /// <returns> Kreirano odvodnjavanje.</returns>
        /// <response code="201">Kreiranje odvodnjavanja je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja odvodnjavanja.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OdvodnjavanjeDto> postOdvodnjavanje([FromBody] OdvodnjavanjeDto odvodnjavanjeDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.Odvodnjavanje odvodnjavanje = mapper.Map<Entities.Odvodnjavanje>(odvodnjavanjeDto);
                odvodnjavanjeRepository.postOdvodnjavanje(odvodnjavanje);
                odvodnjavanjeRepository.saveChanges();
                message.information = "Odvodnjavanje je uspesno izvrseno.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
