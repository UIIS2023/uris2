using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Repository;
using UgovorZakupService.ServiceCalls;
using UgovorZakupService.Services;

namespace UgovorZakupService.Controllers
{
    [ApiController]
    [Route("api/ugovorOZakupu")]
    [Produces("application/json", "application/xml")]
    public class UgovorOZakupuController : ControllerBase
    {
        private readonly IUgovorOZakupuRepository UgovorOZakupuRepository;
        private readonly IMapper mapper;
        private readonly IDokumentService dokumentService;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;
        private readonly IKupacService kupacService;
        private readonly ILicnostService licnostService;


        public UgovorOZakupuController(IUgovorOZakupuRepository UgovorOZakupuRepository, IMapper mapper, IDokumentService dokumentService, IJavnoNadmetanjeService javnoNadmetanjeService, IKupacService kupacService, ILicnostService licnostService)
        {
            this.UgovorOZakupuRepository = UgovorOZakupuRepository;
            this.mapper = mapper;
            this.dokumentService = dokumentService;
            this.javnoNadmetanjeService = javnoNadmetanjeService;
            this.licnostService = licnostService;
            this.kupacService = kupacService;


        }
        /// <summary>
        /// Vraca sve ugovore o zakupu.
        /// </summary>
        /// <returns> Lista ugovora o zakupu</returns>
        /// <response code="200">Vraca listu ugovora o zakupu</response>
        /// <response code="204">Nije pronadjen ni jedan ugovor o zakupu</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UgovorOZakupuDto>> getAllUgovorOZakupu()
        {
            List<Entities.UgovorOZakupu> UgovorOZakupu = UgovorOZakupuRepository.GetAllUgovorOZakupu();
            if (UgovorOZakupu == null || UgovorOZakupu.Count == 0)
            {
                return NoContent();
            }


            List<UgovorOZakupuDto> UgovorOZakupuDto = mapper.Map<List<UgovorOZakupuDto>>(UgovorOZakupu);

            foreach (UgovorOZakupuDto uz in UgovorOZakupuDto)
            {
                uz.javnoNadmetanje = javnoNadmetanjeService.getJavnoNadmetanje(uz.javnoNadmetanjeID).Result;
                uz.lice = kupacService.getKupac(uz.kupacID).Result;
                uz.odluka = dokumentService.getDokument(uz.dokumentID).Result;
                uz.ministar = licnostService.getLicnost(uz.licnostID).Result;

            }

            return Ok(mapper.Map<List<UgovorOZakupuDto>>(UgovorOZakupuDto));
        }

        /// <summary>
        /// Vraca jedan ugovor o zakupu na osnovu ID-ja.
        /// </summary>
        /// // <param name="UgovorOZakupuId">ID ugovora o zakupu</param>
        /// <returns>Trazeni ugovor o zakupu</returns>
        /// <response code="200">Trazeni ugovor o zakupu je uspesno pronadjen</response>
        /// <response code="404">Trazeni ugovor o zakupu nije pronadjen</response>
        [HttpGet("{UgovorOZakupuId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UgovorOZakupuDto> getUgovorOZakupuById(Guid UgovorOZakupuID)
        {
            Entities.UgovorOZakupu uz = UgovorOZakupuRepository.GetUgovorOZakupuById(UgovorOZakupuID);
            if (uz == null)
            {
                return NotFound();
            }

            UgovorOZakupuDto uzDto = mapper.Map<UgovorOZakupuDto>(uz);
            uzDto.odluka = dokumentService.getDokument(uzDto.dokumentID).Result;
            uzDto.javnoNadmetanje = javnoNadmetanjeService.getJavnoNadmetanje(uzDto.javnoNadmetanjeID).Result;
            uzDto.lice = kupacService.getKupac(uzDto.kupacID).Result;
            uzDto.ministar = licnostService.getLicnost(uzDto.licnostID).Result;


            return Ok(uzDto);
        }

        /// <summary>
        /// Brise ugovor o zakupu.
        /// </summary>
		/// <param name="UgovorOZakupuId">ID ugovora o zakupu</param>
        /// <response code="204">Uspesno izvrseno brisanje</response>
        /// <response code="404">Nije pronadjen ugovor o zakupu sa datim id-jem</response>
		/// <response code="500">Desila se greska prilikom brisanja ugovora o zakupu</response>
        [HttpDelete("{UgovorOZakupuId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult deleteUgovorOZakupu(Guid UgovorOZakupuID)
        {
            try
            {
                Entities.UgovorOZakupu uz = UgovorOZakupuRepository.GetUgovorOZakupuById(UgovorOZakupuID);

                if (uz == null)
                {
                    return NotFound();
                }

                UgovorOZakupuRepository.DeleteUgovorOZakupu(UgovorOZakupuID);
                UgovorOZakupuRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }

        /// <summary>
        /// Updatuje ugovor o zakupu.
        /// </summary>
		/// <param name="jnDto">Body koji sadzi podatke koji treba da se izmene</param>
        /// <returns> Vraca izmenjen ugovor o zakupu</returns>
        /// <response code="200">Updatovanje je uspesno izvrseno</response>
        /// <response code="404">Nije pronadjen ugovor o zakupu sa prosledjenim id-jem</response>
		/// <response code="500">Desila se greska prilikom updatovanja ugovora o zakupu</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UgovorOZakupuConfirmationDto> putUgovorOZakupu(UgovorOZakupuUpdateDto uzDto)
        {
            try
            {
                Entities.UgovorOZakupu oldUz = UgovorOZakupuRepository.GetUgovorOZakupuById(uzDto.ugovorOZakupuID);

                if (oldUz == null)
                {
                    return NotFound();
                }

                Entities.UgovorOZakupu UgovorOZakupu = mapper.Map<Entities.UgovorOZakupu>(uzDto);
                mapper.Map(UgovorOZakupu, oldUz);
                UgovorOZakupuRepository.SaveChanges();
                return Ok(mapper.Map<UgovorOZakupuConfirmationDto>(oldUz));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        /// <summary>
        /// Kreira novi ugovor o zakupu
        /// </summary>
		/// <param name="UgovorOZakupuDto">Body koji sadzi ugovor o zakupu koje treba da se kreira</param>
        /// <returns> Kreiran ugovor o zakupu</returns>
        /// <response code="201">Kreiranje ugovora o zakupu je uspesno izvrseno</response>
        /// <response code="500">Desila se greska prilikom kreiranja ugovora o zakupu</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UgovorOZakupuConfirmationDto> postUgovorOZakupu([FromBody] UgovorOZakupuCreationDto UgovorOZakupuDto)
        {
            try
            {
                Entities.UgovorOZakupu UgovorOZakupu = mapper.Map<Entities.UgovorOZakupu>(UgovorOZakupuDto);
                UgovorOZakupuRepository.CreateUgovorOZakupu(UgovorOZakupu);
                UgovorOZakupuRepository.SaveChanges();
                return Created("uri", mapper.Map<UgovorOZakupuConfirmationDto>(UgovorOZakupu));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}
