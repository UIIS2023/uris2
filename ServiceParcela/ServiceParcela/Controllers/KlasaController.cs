using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/klasa")]
    [Produces("application/json", "application/xml")]
    public class KlasaController : ControllerBase
    {
        private readonly IKlasaRepository klasaRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Klasa";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public KlasaController(IKlasaRepository klasaService, IMapper mapper, ILogerService loggerService)
        {
            this.klasaRepository = klasaService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve klase.
        /// </summary>
        /// <returns>Lista klasa.</returns>
        /// <response code="200">Vraca listu klasa.</response>
        /// <response code="204">Nije pronadjena ni jedna klasa.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<KlasaDto>> getAllKlasa()
        {
            List<Entities.Klasa> klase = klasaRepository.getAllKlasa();
            message.serviceName = naziv;
            message.method = "GET";

            if (klase == null || klase.Count == 0)
            {
                message.information = "Nema klasa.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista klasa";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<KlasaDto> klasaDto = mapper.Map<List<KlasaDto>>(klase);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<KlasaDto>>(klasaDto));
        }

        /// <summary>
        /// Vraca jednu klasu na osnovu ID-ja.
        /// </summary>
        /// // <param name="klasaId">ID klase</param>
        /// <returns>Trazena klasa</returns>
        /// <response code="200">Trazena klasa je uspesno pronadjena.</response>
        /// <response code="404">Trazena klasa nije pronadjena.</response>
        [HttpGet("{klasaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KlasaDto> getKlasaByID(Guid klasaId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.Klasa klasa = klasaRepository.getKlasaByID(klasaId);

            if (klasa == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            KlasaDto klaDto = mapper.Map<KlasaDto>(klasa);
            message.information = "Klasa je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KlasaDto>(klaDto));

        }

        /// <summary>
        /// Brise klasu.
        /// </summary>
		/// <param name="klasaId">ID klase</param>
        /// <response code="204">Uspesno izvrseno brisanje klase.</response>
        /// <response code="404">Nije pronadjena klasa sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja klase.</response>
        [HttpDelete("{klasaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKlasa(Guid klasaId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.Klasa klasa = klasaRepository.getKlasaByID(klasaId);

                if (klasa == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                klasaRepository.deleteKlasa(klasaId);
                klasaRepository.saveChanges();
                message.information = "Klasa je obrisana.";
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
        /// Updatuje klasu.
        /// </summary>
		/// <param name="klasaDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu klasu.</returns>
        /// <response code="200">Updatovanje klase je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena klasa sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja klase.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KlasaDto> putKlasa(KlasaDto klasaDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.Klasa oldKlasa = klasaRepository.getKlasaByID(klasaDto.klasaID);

                if (oldKlasa == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.Klasa klasa = mapper.Map<Entities.Klasa>(klasaDto);
                mapper.Map(klasa, oldKlasa);
                klasaRepository.saveChanges();
                message.information = "Klasa je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<KlasaDto>(klasa));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu klasu.
        /// </summary>
		/// <param name="klasaDto">Body koji sadzi klasu koja treba da se kreira.</param>
        /// <returns> Kreirana klasa.</returns>
        /// <response code="201">Kreiranje klase je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja klase.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KlasaDto> postKlasa([FromBody] KlasaDto klasaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.Klasa klasa = mapper.Map<Entities.Klasa>(klasaDto);
                klasaRepository.postKlasa(klasa);
                klasaRepository.saveChanges();
                message.information = "Klasa je uspesno izvrsena.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<KlasaDto>(klasa));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
