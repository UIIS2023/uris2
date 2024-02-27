using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;
using ServiceParcela.Services;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/oblikSvojine")]
    [Produces("application/json", "application/xml")]
    public class OblikSvojineController : ControllerBase
    {
        private readonly IOblikSvojineRepository oblikSvojineRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Oblik_svojine";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public OblikSvojineController(IOblikSvojineRepository oblikSvojineService, IMapper mapper, ILogerService loggerService)
        {
            this.oblikSvojineRepository = oblikSvojineService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve oblike svojine.
        /// </summary>
        /// <returns>Lista oblika svojine.</returns>
        /// <response code="200">Vraca listu oblika svojine..</response>
        /// <response code="204">Nije pronadjen ni oblik svojine.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<OblikSvojineDto>> getAllOblikSvojine(IMapper mapper)
        {
            List<Entities.OblikSvojine> obliciSvojine = oblikSvojineRepository.getAllOblikSvojine();
            message.serviceName = naziv;
            message.method = "GET";

            if (obliciSvojine == null || obliciSvojine.Count == 0)
            {
                message.information = "Nema oblika svojine.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista oblika svojine";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<OblikSvojineDto> obliciSvojineDto = mapper.Map<List<OblikSvojineDto>>(obliciSvojine);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<OblikSvojineDto>>(obliciSvojineDto));
        }


        /// <summary>
        /// Vraca jedan oblik svojine na osnovu ID-ja.
        /// </summary>
        /// // <param name="oblikSvojineId">ID oblika svojine</param>
        /// <returns>Trazeni oblik svojine</returns>
        /// <response code="200">Trazeni oblik svojine je uspesno pronadjen.</response>
        /// <response code="404">Trazeni oblik svojine nije pronadjen.</response>
        [HttpGet("{oblikSvojineId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OblikSvojineService> getOblikSvojineByID(Guid oblikSvojineId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.OblikSvojine oblikSvojine = oblikSvojineRepository.getOblikSvojineByID(oblikSvojineId);

            if (oblikSvojine == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            OblikSvojineDto obSvojineDto = mapper.Map<OblikSvojineDto>(oblikSvojine);
            message.information = "Oblik svojine je vracen.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<OblikSvojineDto>(obSvojineDto));

        }

        /// <summary>
        /// Brise oblik svojine.
        /// </summary>
		/// <param name="oblikSvojineId">ID oblika svojine</param>
        /// <response code="204">Uspesno izvrseno brisanje oblika svojine.</response>
        /// <response code="404">Nije pronadjen oblik svojine sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja oblika svojine.</response>
        [HttpDelete("{oblikSvojineId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteOblikSvojine(Guid oblikSvojineId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.OblikSvojine oblikSvojine = oblikSvojineRepository.getOblikSvojineByID(oblikSvojineId);

                if (oblikSvojine == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                oblikSvojineRepository.deleteOblikSvojine(oblikSvojineId);
                oblikSvojineRepository.saveChanges();
                message.information = "Oblik svojine je obrisan.";
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
        /// Updatuje oblik svojine.
        /// </summary>
		/// <param name="oblikSvojineDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjen oblik svojine.</returns>
        /// <response code="200">Updatovanje oblika svojine je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjen oblik svojine sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja oblika svojine.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OblikSvojineDto> putOblikSvojine(OblikSvojineDto oblikSvojineDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.OblikSvojine oldObSvoj = oblikSvojineRepository.getOblikSvojineByID(oblikSvojineDto.oblikSvojineID);

                if (oldObSvoj == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.OblikSvojine oblikSvojine = mapper.Map<Entities.OblikSvojine>(oblikSvojineDto);
                mapper.Map(oblikSvojine, oldObSvoj);
                oblikSvojineRepository.saveChanges();
                message.information = "Oblik svojine je uspesno izmenjen.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<OblikSvojineDto>(oblikSvojine));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novi oblik svojine.
        /// </summary>
		/// <param name="oblikSvojineDto">Body koji sadzi oblik svojine koji treba da se kreira.</param>
        /// <returns> Kreiran oblik svojine.</returns>
        /// <response code="201">Kreiranje oblika svojine je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja oblika svojine.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OblikSvojineDto> postOblikSvojine([FromBody] OblikSvojineDto oblikSvojineDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.OblikSvojine oblikSvojine = mapper.Map<Entities.OblikSvojine>(oblikSvojineDto);
                oblikSvojineRepository.postOblikSvojine(oblikSvojine);
                oblikSvojineRepository.saveChanges();
                message.information = "Oblik svojine je uspesno izvrsen.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<OblikSvojineDto>(oblikSvojine));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
