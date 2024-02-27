using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za Dokument
    /// </summary>
    [ApiController]
    [Route("api/dokument")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository dokumenterepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public DokumentController(IDokumentRepository dokumenterepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.dokumenterepository = dokumenterepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        
        /// <response code="200">Vraćena je lsita dokumenata</response>
        /// <response code="204">Nije pronađen ni jedan dokument</response>
        /// <returns>Lista dokumenata</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<DokumentDTO>> GetAllDokuments()
        {
            var dokumenti = dokumenterepository.GetAllDokuments();

            if (dokumenti == null || dokumenti.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<DokumentDTO>>(dokumenti));
        }
        /// <summary>
        /// Vraća dokument sa prosleđnim ID-jem
        /// </summary>
        /// <param name="dokumentId">ID dokumenta</param>
        /// <returns>Dokument</returns>
        /// <response code="200">Vraćen je traženi dokument</response>
        /// <response code="404">Nije pronađen dokument sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{dokumentId}")]
        public ActionResult<DokumentDTO> GetDokument(Guid dokumentId)
        {
            var dokument = dokumenterepository.GetDokumentEntityById(dokumentId);

            if (dokument == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<DokumentDTO>(dokument));
        }
        /// <summary>
        /// Kreira novi dokument
        /// </summary>
        /// <returns>Potvrda o kreiranju dokumenta</returns>
        /// <response code="201">Vraćen je kreiran dokument</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog dokumenta</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<DokumentDTO> CreateDokument([FromBody] DokumentCreationDTO dokument)
        {
            try
            {


                Dokument createdDokument = dokumenterepository.CreateDokument(mapper.Map<Dokument>(dokument));
                dokumenterepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAllDokuments", "Dokument", new { dokumentId = createdDokument.dokumentId });

                return Created(location, mapper.Map<DokumentDTO>(createdDokument));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Dokument error");
            }

        }
        /// <summary>
        /// Izmena tipa Dokumenta
        /// </summary>
        /// <returns>Potvrda o izmeni dokumenta</returns>
        /// <response code="200">Izmenjen dokument</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen dokumente sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene dokumenta</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<DokumentDTO> UpdateDokument([FromBody] DokumentDTO dokument)
        {
            try
            {


                var dokumentEntity = dokumenterepository.GetDokumentEntityById(dokument.dokumentId);

                if (dokumentEntity == null)
                {


                    return NotFound();
                }
               Dokument novDokument = mapper.Map<Dokument>(dokument);

                mapper.Map(novDokument, dokumentEntity);
                dokumenterepository.UpdateDokument(mapper.Map<Dokument>(novDokument));
                dokumenterepository.SaveChanges();


                return Ok(dokument);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update Dokument error");
            }

        }
        /// <summary>
        /// Brisanje dokumenta na osnovu ID-ja
        /// </summary>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">Dokument je uspešno obrisan</response>
        /// <response code="404">Nije pronađen dokument sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja dokumenta</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{dokumentId}")]
        public ActionResult DeleteDokument(Guid dokumentId)
        {
            try
            {
                var dokument = dokumenterepository.GetDokumentEntityById(dokumentId);

                if (dokument == null)
                {

                    return NotFound();
                }

                dokumenterepository.DeleteDokument(dokumentId);
                dokumenterepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Dokument error");
            }
        }
    }
}
