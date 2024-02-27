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
    [Route("api/parcela")]
    [Produces("application/json", "application/xml")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository parcelaRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Parcela";
        private readonly IKupacService kupacService;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public ParcelaController(IParcelaRepository parcelaRepository, IMapper mapper, IKupacService kupacService, ILogerService loggerService)
        {
            this.parcelaRepository = parcelaRepository;
            this.mapper = mapper;
            this.kupacService = kupacService;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve parcele.
        /// </summary>
        /// <returns> Lista parcela</returns>
        /// <response code="200">Vraca listu parcela</response>
        /// <response code="204">Nije pronadjena ni jedna parcela.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ParcelaDto>> getAllParcela()
        {
            List<Entities.Parcela> parcele = parcelaRepository.getAllParcela();
            message.serviceName = naziv;
            message.method = "GET";

            if (parcele == null || parcele.Count == 0)
            {
                message.information = "Nema parcela.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<ParcelaDto> parceleDto = mapper.Map<List<ParcelaDto>>(parcele);
            message.information = "Lista parcela";
            loggerService.CreateMessage(message);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<ParcelaDto>>(parceleDto));
        }

        /// <summary>
        /// Vraca jednu parcelu na osnovu ID-ja.
        /// </summary>
        /// // <param name="parcelaId">ID parcele</param>
        /// <returns>Trazena parcela</returns>
        /// <response code="200">Trazena parcela je uspesno pronadjena.</response>
        /// <response code="404">Trazena parcela nije pronadjena.</response>
        [HttpGet("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParcelaDto> getParcelaByID(Guid parcelaId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.Parcela parcela = parcelaRepository.getParcelaByID(parcelaId);

            if (parcela == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            ParcelaDto parcDto = mapper.Map<ParcelaDto>(parcela);
            message.information = "Parcela je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<ParcelaDto>(parcDto));

        }

        /// <summary>
        /// Brise parcelu.
        /// </summary>
		/// <param name="parcelaId">ID parcele</param>
        /// <response code="204">Uspesno izvrseno brisanje parcele.</response>
        /// <response code="404">Nije pronadjena parcela sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja parcele.</response>
        [HttpDelete("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteParcela(Guid parcelaId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.Parcela parcela = parcelaRepository.getParcelaByID(parcelaId);

                if (parcela == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                parcelaRepository.deleteParcela(parcelaId);
                parcelaRepository.saveChanges();
                message.information = "Parcela je obrisana.";
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
        /// Updatuje parcelu.
        /// </summary>
		/// <param name="parcelaDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu parcelu.</returns>
        /// <response code="200">Updatovanje parcele je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena parcela sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja parcele.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParcelaDto> putParcela(ParcelaDto parcelaDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.Parcela oldParcela = parcelaRepository.getParcelaByID(parcelaDto.parcelaID);

                if (oldParcela == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.Parcela parcela = mapper.Map<Entities.Parcela>(parcelaDto);
                mapper.Map(parcela, oldParcela);
                parcelaRepository.saveChanges();
                message.information = "Parcela je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<ParcelaDto>(parcela));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu parcelu.
        /// </summary>
		/// <param name="parcelaDto">Body koji sadzi parcelu koja treba da se kreira.</param>
        /// <returns> Kreirana parcela.</returns>
        /// <response code="201">Kreiranje parcele je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja parcele.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> postParcela([FromBody] ParcelaDto parcelaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.Parcela parcela = mapper.Map<Entities.Parcela>(parcelaDto);
                parcelaRepository.postParcela(parcela);
                parcelaRepository.saveChanges();
                message.information = "Parcela je uspesno izvrsena.";
                loggerService.CreateMessage(message);

                return Created("uri", mapper.Map<ParcelaDto>(parcela));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
