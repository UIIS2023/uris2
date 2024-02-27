using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/kultura")]
    [Produces("application/json", "application/xml")]
    public class KulturaController : ControllerBase
    {
        private readonly IKulturaRepository kulturaRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Kultura";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public KulturaController(IKulturaRepository kulturaService, IMapper mapper, ILogerService loggerService)
        {
            this.kulturaRepository = kulturaService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve kulture.
        /// </summary>
        /// <returns>Lista kultura.</returns>
        /// <response code="200">Vraca listu kultura.</response>
        /// <response code="204">Nije pronadjena ni jedna kultura.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<KulturaDto>> getAllKultura()
        {
            List<Entities.Kultura> kulture = kulturaRepository.getAllKultura();
            message.serviceName = naziv;
            message.method = "GET";

            if (kulture == null || kulture.Count == 0)
            {
                message.information = "Nema kultura.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista kultura";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<KulturaDto> kulturaDto = mapper.Map<List<KulturaDto>>(kulture);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<KulturaDto>>(kulturaDto));
        }

        /// <summary>
        /// Vraca jednu kulturu na osnovu ID-ja.
        /// </summary>
        /// // <param name="kulturaId">ID kulture</param>
        /// <returns>Trazena kultura</returns>
        /// <response code="200">Trazena kultura je uspesno pronadjena.</response>
        /// <response code="404">Trazena kultura nije pronadjena.</response>
        [HttpGet("{kulturaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KulturaDto> getKulturaByID(Guid kulturaId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.Kultura kultura = kulturaRepository.getKulturaByID(kulturaId);

            if (kultura == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            KulturaDto kultDto = mapper.Map<KulturaDto>(kultura);
            message.information = "Kultura je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KulturaDto>(kultDto));

        }

        /// <summary>
        /// Brise kulturu.
        /// </summary>
		/// <param name="kulturaId">ID kulture</param>
        /// <response code="204">Uspesno izvrseno brisanje kulture.</response>
        /// <response code="404">Nije pronadjena kultura sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja kulture.</response>
        [HttpDelete("{kulturaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKultura(Guid kulturaId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.Kultura kultura = kulturaRepository.getKulturaByID(kulturaId);

                if (kultura == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                kulturaRepository.deleteKultura(kulturaId);
                kulturaRepository.saveChanges();
                message.information = "Kultura je obrisana.";
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
        /// Updatuje kulturu.
        /// </summary>
		/// <param name="kulturaDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu kulturu.</returns>
        /// <response code="200">Updatovanje kulture je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena kultura sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja kulture.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KulturaDto> putKultura(KulturaDto kulturaDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.Kultura oldKultura = kulturaRepository.getKulturaByID(kulturaDto.kulturaID);

                if (oldKultura == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.Kultura kultura = mapper.Map<Entities.Kultura>(kulturaDto);
                mapper.Map(kultura, oldKultura);
                kulturaRepository.saveChanges();
                message.information = "Kultura je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<KulturaDto>(kultura));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu kulturu.
        /// </summary>
		/// <param name="kulturaDto">Body koji sadzi kulturu koja treba da se kreira.</param>
        /// <returns> Kreirana kultura.</returns>
        /// <response code="201">Kreiranje kulture je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja kulture.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KulturaDto> postKultura([FromBody] KulturaDto kulturaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.Kultura kultura = mapper.Map<Entities.Kultura>(kulturaDto);
                kulturaRepository.postKultura(kultura);
                kulturaRepository.saveChanges();
                message.information = "Kultura je uspesno izvrsena.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<KulturaDto>(kultura));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
