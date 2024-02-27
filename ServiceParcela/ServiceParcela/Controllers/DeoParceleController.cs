using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/deoParcele")]
    [Produces("application/json", "application/xml")]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository deoParceleRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Deo_parcele";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public DeoParceleController(IDeoParceleRepository deoParceleService, IMapper mapper, ILogerService loggerService)
        {
            this.deoParceleRepository = deoParceleService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve delove parcele.
        /// </summary>
        /// <returns>Lista delova parcele.</returns>
        /// <response code="200">Vraca listu delova parcele.</response>
        /// <response code="204">Nije pronadjen ni jedan deo parcele.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<DeoParceleDto>> getAllDeoParcele()
        {
            List<Entities.DeoParcele> deloviParcele = deoParceleRepository.getAllDeoParcele();
            message.serviceName = naziv;
            message.method = "GET";

            if (deloviParcele == null || deloviParcele.Count == 0)
            {
                message.information = "Nema delova parcele.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista delova parcele";
            loggerService.CreateMessage(message);

            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<DeoParceleDto> deloviParceleDto = mapper.Map<List<DeoParceleDto>>(deloviParcele);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<DeoParceleDto>>(deloviParceleDto));
        }

        /// <summary>
        /// Vraca jedan deo parcele na osnovu ID-ja.
        /// </summary>
        /// // <param name="deoParceleId">ID dela parcele</param>
        /// <returns>Trazeni deo parcele</returns>
        /// <response code="200">Trazeni deo parcele je uspesno pronadjen.</response>
        /// <response code="404">Trazeni deo parcele nije pronadjen.</response>
        [HttpGet("{deoParceleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeoParceleDto> getDeoParceleByID(Guid deoParceleId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.DeoParcele deoParcele = deoParceleRepository.getDeoParceleByID(deoParceleId);

            if (deoParcele == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            DeoParceleDto deoParcDto = mapper.Map<DeoParceleDto>(deoParcele);
            message.information = "Deo parcele je vracen.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<DeoParceleDto>(deoParcDto));

        }

        /// <summary>
        /// Brise deo parcele.
        /// </summary>
		/// <param name="deoParceleId">ID dela parcele</param>
        /// <response code="204">Uspesno izvrseno brisanje dela parcele.</response>
        /// <response code="404">Nije pronadjen deo parcele sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja dela parcele.</response>
        [HttpDelete("{deoParceleId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteDeoParcele(Guid deoParceleId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.DeoParcele deoParcele = deoParceleRepository.getDeoParceleByID(deoParceleId);

                if (deoParcele == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                deoParceleRepository.deleteDeoParcele(deoParceleId);
                deoParceleRepository.saveChanges();
                message.information = "Deo parcele je obrisan.";
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
        /// Updatuje deo parcele.
        /// </summary>
		/// <param name="deoParceleDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjen deo parcele.</returns>
        /// <response code="200">Updatovanje dela parcele je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjen deo parcele sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja dela parcele.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeoParceleDto> putDeoParcele(DeoParceleDto deoParceleDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.DeoParcele oldDeoP = deoParceleRepository.getDeoParceleByID(deoParceleDto.deoParceleID);

                if (oldDeoP == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.DeoParcele deoParcele = mapper.Map<Entities.DeoParcele>(deoParceleDto);
                mapper.Map(deoParcele, oldDeoP);
                deoParceleRepository.saveChanges();
                message.information = "Deo parcele je uspesno izmenjen.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<DeoParceleDto>(deoParcele));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novi deo parcele.
        /// </summary>
		/// <param name="deoParceleDto">Body koji sadzi deo parcele koji treba da se kreira.</param>
        /// <returns> Kreiran deo parcele.</returns>
        /// <response code="201">Kreiranje dela parcele je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja dela parcele.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleDto> postDeoParcele([FromBody] DeoParceleDto deoParceleDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.DeoParcele deoParcele = mapper.Map<Entities.DeoParcele>(deoParceleDto);
                deoParceleRepository.postDeoParcele(deoParcele);
                deoParceleRepository.saveChanges();
                message.information = "Deo parcele je uspesno izvrsen.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<DeoParceleDto>(deoParcele));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
