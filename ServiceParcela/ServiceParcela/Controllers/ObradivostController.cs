using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/obradivost")]
    [Produces("application/json", "application/xml")]
    public class ObradivostController : ControllerBase 
    {
        private readonly IObradivostRepository obradivostRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Obradivost";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public ObradivostController(IObradivostRepository obradivostService, IMapper mapper, ILogerService loggerService)
        {
            this.obradivostRepository = obradivostService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve obradivosti.
        /// </summary>
        /// <returns>Lista obradivosti.</returns>
        /// <response code="200">Vraca listu obradivosti.</response>
        /// <response code="204">Nije pronadjena ni jedna obradivost.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ObradivostDto>> getAllObradivost()
        {
            List<Entities.Obradivost> obradivosti = obradivostRepository.getAllObradivost();
            message.serviceName = naziv;
            message.method = "GET";

            if (obradivosti == null || obradivosti.Count == 0)
            {
                message.information = "Nema obradivosti.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista obradivosti";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<ObradivostDto> obradivostiDto = mapper.Map<List<ObradivostDto>>(obradivosti);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<ObradivostDto>>(obradivostiDto));
        }

        /// <summary>
        /// Vraca jednu obradivost na osnovu ID-ja.
        /// </summary>
        /// // <param name="obradivostId">ID obradivosti</param>
        /// <returns>Trazena obradivost</returns>
        /// <response code="200">Trazena obradivost je uspesno pronadjena.</response>
        /// <response code="404">Trazena obradivost nije pronadjena.</response>
        [HttpGet("{obradivostId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ObradivostDto> getObradivostByID(Guid obradivostId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.Obradivost obradivost = obradivostRepository.getObradivostByID(obradivostId);

            if (obradivost == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            ObradivostDto obrDto = mapper.Map<ObradivostDto>(obradivost);
            message.information = "Obradivost je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<ObradivostDto>(obrDto));

        }

        /// <summary>
        /// Brise obradivost.
        /// </summary>
		/// <param name="obradivostId">ID obradivosti</param>
        /// <response code="204">Uspesno izvrseno brisanje obradivosti.</response>
        /// <response code="404">Nije pronadjena obradivost sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja obradivosti.</response>
        [HttpDelete("{obradivostId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteObradivost(Guid obradivostId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.Obradivost obradivost = obradivostRepository.getObradivostByID(obradivostId);

                if (obradivost == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                obradivostRepository.deleteObradivost(obradivostId);
                obradivostRepository.saveChanges();
                message.information = "Obradivost je obrisana.";
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
        /// Updatuje obradivost.
        /// </summary>
		/// <param name="obradivostDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu obradivost.</returns>
        /// <response code="200">Updatovanje obradivosti je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena obradivost sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja obradivosti.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ObradivostDto> putObradivost(ObradivostDto obradivostDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.Obradivost oldObr = obradivostRepository.getObradivostByID(obradivostDto.obradivostID);

                if (oldObr == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.Obradivost obradivost = mapper.Map<Entities.Obradivost>(obradivostDto);
                mapper.Map(obradivost, oldObr);
                obradivostRepository.saveChanges();
                message.information = "Obradivost je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<ObradivostDto>(obradivost));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu obradivost.
        /// </summary>
		/// <param name="obradivostDto">Body koji sadzi obradivost koja treba da se kreira.</param>
        /// <returns> Kreirana obradivost.</returns>
        /// <response code="201">Kreiranje obradivosti je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja obradivosti.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ObradivostDto> postObradivost([FromBody] ObradivostDto obradivostDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.Obradivost obradivost = mapper.Map<Entities.Obradivost>(obradivostDto);
                obradivostRepository.postObradivost(obradivost);
                obradivostRepository.saveChanges();
                message.information = "Obradivost je uspesno izvrsena.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<ObradivostDto>(obradivost));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
