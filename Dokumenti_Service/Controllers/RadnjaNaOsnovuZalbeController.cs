using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za tip žalbe
    /// </summary>
    [ApiController]
    [Route("api/radnjaNaOsnovuZalbe")]
    public class RadnjaNaOsnovuZalbeController : ControllerBase 
    {
        private readonly IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public RadnjaNaOsnovuZalbeController(IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.radnjaNaOsnovuZalbeRepository = radnjaNaOsnovuZalbeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbe">Naziv radnje</param>
        /// <response code="200">Vraćena je lsita radnji</response>
        /// <response code="204">Nije pronađena ni jedna radnja</response>
        /// <returns>Lista radnji</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<RadnjaNaOsnovuZalbeDTO>> GetAllRadnjaNaOsnovuZalbes()
        {
            var radnje = radnjaNaOsnovuZalbeRepository.GetAllRadnjaNaOsnovuZalbes();

            if (radnje == null || radnje.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<RadnjaNaOsnovuZalbeDTO>>(radnje));
        }
        /// <summary>
        /// Vraća radnju sa prosleđnim ID-jem
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeId">ID tipa žalbe</param>
        /// <returns>Radnja Na Osnovu Zalbe</returns>
        /// <response code="200">Vraćena je tražena RadnjaNaOsnovuZalbe</response>
        /// <response code="404">Nije pronađena RadnjaNaOsnovuZalbe sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{radnjaNaOsnovuZalbeId}")]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> GetRadnjaNaOsnovuZalbe(Guid radnjaNaOsnovuZalbeId)
        {
            var radnjaNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeEntityById(radnjaNaOsnovuZalbeId);

            if (radnjaNaOsnovuZalbe == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<RadnjaNaOsnovuZalbeDTO>(radnjaNaOsnovuZalbe));
        }
        /// <summary>
        /// Kreira novu radnju
        /// </summary>
        
        /// <remarks>
        /// Primer zahteva za kreiranje novoe radnje \
        /// POST /api/radnjaNaOsnovuZalbe \
        /// {   
        ///     "radnjaNaOsnovuZalbe": "Prihvatanje zelbe i proglasenje drugog kruga"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju radnje</returns>
        /// <response code="201">Vraćena je kreirana radnja</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa nove radnje</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> CreateRadnjaNaOsnovuZalbe([FromBody] RadnjaNaOsnovuZalbeCreationDTO radnjaNaOsnovuZalbe)
        {
            try
            {
                

                

                RadnjaNaOsnovuZalbe createdRadnjaNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.CreateRadnjaNaOsnovuZalbe(mapper.Map<RadnjaNaOsnovuZalbe>(radnjaNaOsnovuZalbe));
                radnjaNaOsnovuZalbeRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllRadnjaNaOsnovuZalbes", "RadnjaNaOsnovuZalbe", new { radnjaNaOsnovuZalbeId = createdRadnjaNaOsnovuZalbe.radnjaNaOsnovuZalbeId });

                return Created(location, mapper.Map<RadnjaNaOsnovuZalbe>(createdRadnjaNaOsnovuZalbe));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create RadnjaNaOsnovuZalbe error");
            }
        }
        /// <summary>
        /// Izmena Radnja Na Osnovu Zalbe
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeId">ID Radnja Na Osnovu Zalbee</param>
        
        /// <returns>Potvrda o izmeni Radnja Na Osnovu Zalbe</returns>
        /// <response code="200">Izmenjena Radnja Na Osnovu Zalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađena RadnjaNaOsnovuZalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene Radnje Na Osnovu Zalbe</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> UpdateRadnjaNaOsnovuZalbe( [FromBody] RadnjaNaOsnovuZalbeDTO radnjaNaOsnovuZalbe)
        {
            try
            {
                

                var radnjaNaOsnovuZalbeEntity = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeEntityById(radnjaNaOsnovuZalbe.radnjaNaOsnovuZalbeId);

                if (radnjaNaOsnovuZalbeEntity == null)
                {


                    return NotFound();
                }
                RadnjaNaOsnovuZalbe novaRadnja = mapper.Map<RadnjaNaOsnovuZalbe>(radnjaNaOsnovuZalbe);
                mapper.Map(radnjaNaOsnovuZalbe, radnjaNaOsnovuZalbeEntity);
                radnjaNaOsnovuZalbeRepository.UpdateRadnjaNaOsnovuZalbe(mapper.Map<RadnjaNaOsnovuZalbe>(novaRadnja));
                radnjaNaOsnovuZalbeRepository.SaveChanges();

                return Ok(radnjaNaOsnovuZalbe);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update RadnjaNaOsnovuZalbe error");
            }

        }
        /// <summary>
        /// Brisanje RadnjaNaOsnovuZalbe na osnovu ID-ja
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeId">ID Radnje Na Osnovu Zalbe</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">RadnjaNaOsnovuZalbe je uspešno obrisana</response>
        /// <response code="404">Nije pronađena RadnjaNaOsnovuZalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja RadnjaNaOsnovuZalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{radnjaNaOsnovuZalbeId}")]
        public ActionResult DeleteRadnjaNaOsnovuZalbe(Guid radnjaNaOsnovuZalbeId)
        {
            try
            {
                var radnjaNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeEntityById(radnjaNaOsnovuZalbeId);

                if (radnjaNaOsnovuZalbe == null)
                {

                    return NotFound();
                }

                radnjaNaOsnovuZalbeRepository.DeleteRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbeId);
                radnjaNaOsnovuZalbeRepository.SaveChanges();
                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete radnja Na Osnovu Zalbe error");
            }
        }
    }
}
