using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/zasticenaZona")]
    [Produces("application/json", "application/xml")]
    public class ZasticenaZonaController : ControllerBase 
    {
        private readonly IZasticenaZonaRepository zasticenaZonaRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Zasticena_zona";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaService, IMapper mapper, ILogerService loggerService)
        {
            this.zasticenaZonaRepository = zasticenaZonaService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve zasticene zone.
        /// </summary>
        /// <returns>Lista zasticenih zona.</returns>
        /// <response code="200">Vraca listu zasticenih zona.</response>
        /// <response code="204">Nije pronadjena ni jedna zasticena zona.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ZasticenaZonaDto>> getAllZasticenaZona()
        {
            List<Entities.ZasticenaZona> zasticeneZone = zasticenaZonaRepository.getAllZasticenaZona();
            message.serviceName = naziv;
            message.method = "GET";

            if (zasticeneZone == null || zasticeneZone.Count == 0)
            {
                message.information = "Nema zasticenih zona.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista zasticenih zona";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<ZasticenaZonaDto> zasticeneZoneDto = mapper.Map<List<ZasticenaZonaDto>>(zasticeneZone);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<ZasticenaZonaDto>>(zasticeneZoneDto));
        }

        /// <summary>
        /// Vraca jednu zasticenu zonu na osnovu ID-ja.
        /// </summary>
        /// // <param name="zasticenaZonaId">ID zasticene zone</param>
        /// <returns>Trazena zasticena zona</returns>
        /// <response code="200">Trazena zasticena zona je uspesno pronadjena.</response>
        /// <response code="404">Trazena zasticena zona nije pronadjena.</response>
        [HttpGet("{zasticenaZonaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ZasticenaZonaDto> getZasticenaZonaByID(Guid zasticenaZonaId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.ZasticenaZona zasticenaZona = zasticenaZonaRepository.getZasticenaZonaByID(zasticenaZonaId);

            if (zasticenaZona == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            ZasticenaZonaDto zastZonaDto = mapper.Map<ZasticenaZonaDto>(zasticenaZona);
            message.information = "Zasticena zona je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<ZasticenaZonaDto>(zastZonaDto));

        }

        /// <summary>
        /// Brise zasticenu zonu.
        /// </summary>
		/// <param name="zasticenaZonaId">ID zasticene zone</param>
        /// <response code="204">Uspesno izvrseno brisanje.</response>
        /// <response code="404">Nije pronadjena zasticena zona sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja zasticene zone.</response>
        [HttpDelete("{zasticenaZonaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteZasticenaZona(Guid zasticenaZonaId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.ZasticenaZona zasticenaZona = zasticenaZonaRepository.getZasticenaZonaByID(zasticenaZonaId);

                if (zasticenaZona == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                zasticenaZonaRepository.deleteZasticenaZona(zasticenaZonaId);
                zasticenaZonaRepository.saveChanges();
                message.information = "Zasticena zona je obrisana.";
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
        /// Updatuje zasticenu zonu.
        /// </summary>
		/// <param name="zasticenaZonaDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu zasticenu zonu.</returns>
        /// <response code="200">Updatovanje zasticene zone je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena zasticena zona sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja zasticene zone.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ZasticenaZonaDto> putZasticenaZona(ZasticenaZonaDto zasticenaZonaDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.ZasticenaZona oldZastZona = zasticenaZonaRepository.getZasticenaZonaByID(zasticenaZonaDto.zasticenaZonaID);

                if (oldZastZona == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.ZasticenaZona zasticenaZona = mapper.Map<Entities.ZasticenaZona>(zasticenaZonaDto);
                mapper.Map(zasticenaZona, oldZastZona);
                zasticenaZonaRepository.saveChanges();
                message.information = "Zasticena zona je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<ZasticenaZonaDto>(zasticenaZona));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu zasticenu zonu.
        /// </summary>
		/// <param name="zasticenaZonaDto">Body koji sadzi zasticenu zonu koja treba da se kreira.</param>
        /// <returns> Kreirana zasticena zona.</returns>
        /// <response code="201">Kreiranje zasticene zone je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja zasticene zone.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenaZonaDto> postZasticenaZona([FromBody] ZasticenaZonaDto zasticenaZonaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.ZasticenaZona zasticenaZona = mapper.Map<Entities.ZasticenaZona>(zasticenaZonaDto);
                zasticenaZonaRepository.postZasticenaZona(zasticenaZona);
                zasticenaZonaRepository.saveChanges();
                message.information = "Zasticena zona je uspesno izvrsena.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<ZasticenaZonaDto>(zasticenaZona));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
