using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Repository;
using UgovorZakupService.Services;
using UgovorZakupService.ServiceCalls;



namespace UgovorZakupService.Controllers
{
    [ApiController]
    [Route("api/tipoviGarancije")]
    [Produces("application/json", "application/xml")]
    public class TipGarancijeController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITipGarancijeRepository tipGarancijeRepository;

        public TipGarancijeController(IMapper mapper, ITipGarancijeRepository tipGarancijeService)
        {
            this.mapper = mapper;
            this.tipGarancijeRepository = tipGarancijeService;
        }


        /// <summary>
        /// Updatuje tip garancije.
        /// </summary>
		/// <param name="tipGarancijeDto">Body koji sadzi podatke koji treba da se izmene</param>
        /// <returns> Vraca izmenjen tip garancije</returns>
        /// <response code="200">Updatovanje je uspesno izvrseno</response>
        /// <response code="404">Nije pronadjen tip garancije sa prosledjenim id-jem</response>
		/// <response code="500">Desila se greska prilikom updatovanja tipa garancije</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TipGarancijeConfirmationDto> updateTipGarancije(TipGarancijeUpdateDto tipGarancijeDto)
        {
            try
            {
                Entities.TipGarancije oldTipGarancije = tipGarancijeRepository.GetTipGarancijeById(tipGarancijeDto.tipGarancijeID);

                if (oldTipGarancije == null)
                {
                    return NotFound();
                }

                Entities.TipGarancije tipGarancije = mapper.Map<Entities.TipGarancije>(tipGarancijeDto);
                mapper.Map(tipGarancije, oldTipGarancije);
                tipGarancijeRepository.SaveChanges();
                return Ok(mapper.Map<TipGarancijeConfirmationDto>(oldTipGarancije));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Kreira novu licitaciju
        /// </summary>
		/// <param name="tipGarancijeDto">Body koji sadzi licitaciju koja treba da se kreira</param>
        /// <returns> Kreirana tipGarancije</returns>
        /// <response code="201">Kreiranje licitacije je uspesno izvrseno</response>
        /// <response code="500">Desila se greska prilikom kreiranja licitacije</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipGarancijeConfirmationDto> postTipGarancije([FromBody] TipGarancijeCreationDto tipGarancijeDto)
        {
            try
            {
                Entities.TipGarancije tipGarancije = mapper.Map<Entities.TipGarancije>(tipGarancijeDto);
                tipGarancijeRepository.CreateTipGarancije(tipGarancije);
                tipGarancijeRepository.SaveChanges();
                return Created("uri", mapper.Map<TipGarancijeConfirmationDto>(tipGarancije));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }

        /// <summary>
        /// Vraca sve licitacije.
        /// </summary>
        /// <returns> Lista tipGarancije</returns>
        /// <response code="200">Vraca listu tipGarancije</response>
        /// <response code="204">Nije pronadjen ni jedna tipGarancije</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipGarancijeDto>> getAllTipoviGarancije()
        {
            List<Entities.TipGarancije> tipoviGarancije = tipGarancijeRepository.GetAllTipGarancije();
            if (tipoviGarancije == null || tipoviGarancije.Count == 0)
            {
                return NoContent();
            }

            List<TipGarancijeDto> tipoviGarancijeDto = mapper.Map<List<TipGarancijeDto>>(tipoviGarancije);
            return Ok(mapper.Map<List<TipGarancijeDto>>(tipoviGarancijeDto));
        }

        /// <summary>
        /// Vraca jednu licitaciju na osnovu ID-ja.
        /// </summary>
        /// // <param name="tipGarancijeId">ID javnog nadmetanja</param>
        /// <returns>Trazena tipGarancije</returns>
        /// <response code="200">Tazena tipGarancije je uspesno pronadjena</response>
        /// <response code="404">Trazena tipGarancije nije pronadjena</response>
        [HttpGet("{tipGarancijeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipGarancijeDto> getTipGarancijeById(Guid tipGarancijeId)
        {
            Entities.TipGarancije tg = tipGarancijeRepository.GetTipGarancijeById(tipGarancijeId);
            if (tg == null)
            {
                return NotFound();
            }

            TipGarancijeDto tgDto = mapper.Map<TipGarancijeDto>(tg);
            return Ok(tgDto);
        }

        /// <summary>
        /// Brise licitaciju.
        /// </summary>
		/// <param name="tipGarancijeId">ID licitacije</param>
        /// <response code="204">Uspesno izvrseno brisanje</response>
        /// <response code="404">Nije pronadjena tipGarancije sa datim id-jem</response>
		/// <response code="500">Desila se greska prilikom brisanja licitacije</response>
        [HttpDelete("{tipGarancijeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult deleteTipGarancije(Guid tipGarancijeId)
        {
            try
            {
                Entities.TipGarancije tg = tipGarancijeRepository.GetTipGarancijeById(tipGarancijeId);

                if (tg == null)
                {
                    return NotFound();
                }

                tipGarancijeRepository.DeleteTipGarancije(tipGarancijeId);
                tipGarancijeRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }


    }
}
