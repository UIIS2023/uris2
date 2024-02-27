using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za oglasnu tablu
    /// </summary>
    [ApiController]
    [Route("api/oglasnaTabla")]
    public class OglasnaTablaController : ControllerBase
    {
        private readonly IOglasnaTablaRepository oglasnaTablarepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public OglasnaTablaController(IOglasnaTablaRepository oglasnaTablarepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.oglasnaTablarepository = oglasnaTablarepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <param name="oglasnaTabla">Naziv Oglasne Tabla</param>
        /// <response code="200">Vraćena je lsita OglasnaTabla</response>
        /// <response code="204">Nije pronađena ni jedan OglasnaTabla</response>
        /// <returns>Lista OglasnaTabla</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<OglasnaTablaDTO>> GetAllOglasnaTablas()
        {
            var oglasneTabla = oglasnaTablarepository.GetAllOglasnaTablas();

            if (oglasneTabla == null || oglasneTabla.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<OglasnaTablaDTO>>(oglasneTabla));
        }
        /// <summary>
        /// Vraća tip Oglasne Table sa prosleđnim ID-jem
        /// </summary>
        /// <param name="tipZalbeIdId">ID Oglasne Table</param>
        /// <returns>Oglasne Table</returns>
        /// <response code="200">Vraćen je traženi Oglasne Table</response>
        /// <response code="404">Nije pronađena Oglasna Table sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{oglasnaTablaId}")]
        public ActionResult<OglasnaTablaDTO> GetOglasnaTabla(Guid oglasnaTablaId)
        {
            var oglasnaTabla = oglasnaTablarepository.GetOglasnaTablaEntityById(oglasnaTablaId);

            if (oglasnaTabla == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<OglasnaTabla>(oglasnaTabla));
        }
        /// <summary>
        /// Kreira novu OglasnaTabla
        /// </summary>
        
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa žalbe \
        /// POST /api/oglasnaTabla \
        /// {   
        ///     "oglasnaTabla": "oglasna tabla br. 3"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju OglasnaTable</returns>
        /// <response code="201">Vraćen je kreiran OglasnaTable</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa nove OglasnaTabla</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<OglasnaTablaDTO> CreateOglasnaTabla([FromBody] OglasnaTablaCreationDTO oglasnaTabla)
        {
            try
            {
               

                OglasnaTabla createdOglasnaTabla = oglasnaTablarepository.CreateOglasnaTabla(mapper.Map<OglasnaTabla>(oglasnaTabla));
                oglasnaTablarepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllOglasnaTablas", "OglasnaTabla", new { oglasnaTablaId = createdOglasnaTabla.oglasnaTablaId });

                return Created(location, mapper.Map<OglasnaTablaDTO>(createdOglasnaTabla));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create OglasnaTabla error");
            }
        }
        /// <summary>
        /// Izmena OglasnaTabla
        /// </summary>
        /// <param name="oglasnaTablaId">ID Oglasne Tabla</param>
        
        /// <returns>Potvrda o izmeni OglasnaTabla</returns>
        /// <response code="200">Izmenjen OglasnaTabla</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađena OglasnaTabla sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene OglasnaTabla</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<OglasnaTablaDTO> UpdateOglasnaTabla([FromBody] OglasnaTablaDTO oglasnaTabla)
        {
            try
            {
                

                var oglasnaTablaEntity = oglasnaTablarepository.GetOglasnaTablaEntityById(oglasnaTabla.oglasnaTablaId);

                if (oglasnaTablaEntity == null)
                {


                    return NotFound();
                }
                OglasnaTabla novOglasnaTabla = mapper.Map<OglasnaTabla>(oglasnaTabla);
                mapper.Map(oglasnaTabla, oglasnaTablaEntity);
                oglasnaTablarepository.UpdateOglasnaTabla(mapper.Map<OglasnaTabla>(novOglasnaTabla));
                oglasnaTablarepository.SaveChanges();


                return Ok(oglasnaTabla);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update OglasnaTabla error");
            }

        }
        /// <summary>
        /// Brisanje Oglasne Tabla na osnovu ID-ja
        /// </summary>
        /// <param name="oglasnaTablaId">ID Oglasna Table</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">OglasnaTabla je uspešno obrisana</response>
        /// <response code="404">Nije pronađena OglasnaTabla sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja OglasnaTable</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{oglasnaTablaId}")]
        public ActionResult DeleteOglasnaTabla(Guid oglasnaTablaId)
        {
            try
            {
                var oglasnaTabla = oglasnaTablarepository.GetOglasnaTablaEntityById(oglasnaTablaId);

                if (oglasnaTabla == null)
                {

                    return NotFound();
                }

                oglasnaTablarepository.DeleteOglasnaTabla(oglasnaTablaId);
                oglasnaTablarepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete OglasnaTabla error");
            }
        }

    }
}
