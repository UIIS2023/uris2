using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceParcela.DtoModels;
using ServiceParcela.Entities;
using ServiceParcela.Repositories;
using ServiceParcela.ServiceCalls;

namespace ServiceParcela.Controllers
{
    [ApiController]
    [Route("api/katastarskaOpstina")]
    [Produces("application/json", "application/xml")]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository katastarskaOpstinaRepository;
        private readonly IMapper mapper;
        private readonly string naziv = "Katastarska_opstina";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        /// <summary>
        /// Mapiranje 
        /// </summary>
        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaService, IMapper mapper, ILogerService loggerService)
        {
            this.katastarskaOpstinaRepository = katastarskaOpstinaService;
            this.mapper = mapper;
            this.loggerService = loggerService;
        }

        /// <summary>
        /// Vraca sve katastarske opstine.
        /// </summary>
        /// <returns>Lista katastarskih opstina.</returns>
        /// <response code="200">Vraca listu katastarskih opstina.</response>
        /// <response code="204">Nije pronadjena ni jedna katastarskih opstina.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<KatastarskaOpstinaDto>> getAllKatastarskaOpstina()
        {
            List<Entities.KatastarskaOpstina> katastarskeOpstine = katastarskaOpstinaRepository.getAllKatastarskaOpstina();
            message.serviceName = naziv;
            message.method = "GET";

            if (katastarskeOpstine == null || katastarskeOpstine.Count == 0)
            {
                message.information = "Nema katastarskih opstina.";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.information = "Lista katastarskih opstina";
            loggerService.CreateMessage(message);


            //ovde samo ceo objekat namapirmao na dto objekat klase
            List<KatastarskaOpstinaDto> katastarskeOpstineDto = mapper.Map<List<KatastarskaOpstinaDto>>(katastarskeOpstine);

            //prolazimo kroz te objekte i returnujemo ih
            return Ok(mapper.Map<List<KatastarskaOpstinaDto>>(katastarskeOpstineDto));
        }

        /// <summary>
        /// Vraca jednu katastarsku opstinu na osnovu ID-ja.
        /// </summary>
        /// // <param name="katastarskaOpstinaId">ID katastarske opstine</param>
        /// <returns>Trazena katastarska opstina</returns>
        /// <response code="200">Trazena katastarska opstina je uspesno pronadjena.</response>
        /// <response code="404">Trazena katastarska opstina nije pronadjena.</response>
        [HttpGet("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> getKatastarskaOpstinaByID(Guid katastarskaOpstinaId)
        {
            message.method = "GET";
            message.serviceName = naziv;
            Entities.KatastarskaOpstina katastarskaOpstina = katastarskaOpstinaRepository.getKatastarskaOpstinaByID(katastarskaOpstinaId);

            if (katastarskaOpstina == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            KatastarskaOpstinaDto katOpstinaDto = mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina);
            message.information = "Katastarska opstina je vracena.";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KatastarskaOpstinaDto>(katOpstinaDto));

        }

        /// <summary>
        /// Brise katastarsku opstinu.
        /// </summary>
		/// <param name="katastarskaOpstinaId">ID katastarske opstine</param>
        /// <response code="204">Uspesno izvrseno brisanje katastarske opstine.</response>
        /// <response code="404">Nije pronadjena katastarska opstina sa datim id-jem.</response>
		/// <response code="500">Desila se greska prilikom brisanja katastarske opstine.</response>
        [HttpDelete("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKatastarskaOpstina(Guid katastarskaOpstinaId)
        {
            message.method = "DELETE";
            message.serviceName = naziv;
            try
            {
                Entities.KatastarskaOpstina katastarskaOpstina = katastarskaOpstinaRepository.getKatastarskaOpstinaByID(katastarskaOpstinaId);

                if (katastarskaOpstina == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                katastarskaOpstinaRepository.deleteKatastarskaOpstina(katastarskaOpstinaId);
                katastarskaOpstinaRepository.saveChanges();
                message.information = "Katastarska opstina je obrisana.";
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
        /// Updatuje katastarsku opstinu.
        /// </summary>
		/// <param name="katastarskaOpstinaDto">Body koji sadzi podatke koji treba da se izmene.</param>
        /// <returns> Vraca izmenjenu katastarsku opstinu.</returns>
        /// <response code="200">Updatovanje katastarske opstine je uspesno izvrseno.</response>
        /// <response code="404">Nije pronadjena katastarska opstina sa prosledjenim id-jem.</response>
		/// <response code="500">Desila se greska prilikom updatovanja katastarske opstine.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> putKatastarskaOpstina(KatastarskaOpstinaDto katastarskaOpstinaDto)
        {
            message.method = "PUT";
            message.serviceName = naziv;
            try
            {
                Entities.KatastarskaOpstina oldKatOpstina = katastarskaOpstinaRepository.getKatastarskaOpstinaByID(katastarskaOpstinaDto.katastarskaOpstinaID);

                if (oldKatOpstina == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                Entities.KatastarskaOpstina katastarskaOpstina = mapper.Map<Entities.KatastarskaOpstina>(katastarskaOpstinaDto);
                mapper.Map(katastarskaOpstina, oldKatOpstina);
                katastarskaOpstinaRepository.saveChanges();
                message.information = "Katastarska opstina je uspesno izmenjena.";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
            }

        }

        /// <summary>
        /// Kreira novu katastarsku opstinu.
        /// </summary>
		/// <param name="katastarskaOpstinaDto">Body koji sadzi katastarsku opstinu koja treba da se kreira.</param>
        /// <returns> Kreirana katastarska opstina.</returns>
        /// <response code="201">Kreiranje katastarske opstine je uspesno izvrseno.</response>
        /// <response code="500">Desila se greska prilikom kreiranja katastarske opstine.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaDto> postKatastarskaOpstina([FromBody] KatastarskaOpstinaDto katastarskaOpstinaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.KatastarskaOpstina katastarskaOpstina = mapper.Map<Entities.KatastarskaOpstina>(katastarskaOpstinaDto);
                katastarskaOpstinaRepository.postKatastarskaOpstina(katastarskaOpstina);
                katastarskaOpstinaRepository.saveChanges();
                message.information = "Katastarska opstina je uspesno izvrsena.";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
