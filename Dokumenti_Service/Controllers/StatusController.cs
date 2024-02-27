using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Dokument;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za status
    /// </summary>
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusrepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public StatusController(IStatusRepository statusrepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.statusrepository = statusrepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <param name="Status">Naziv Statusa</param>
        /// <response code="200">Vraćena je lsita Status</response>
        /// <response code="204">Nije pronađen ni jedan Status</response>
        /// <returns>Lista Statusa</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAllStatuses()
        {
            var statusi = statusrepository.GetAllStatuses();

            if (statusi == null || statusi.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<StatusDTO>>(statusi));
        }
        /// <summary>
        /// Vraća Status sa prosleđnim ID-jem
        /// </summary>
        /// <param name="statusId">ID Statusa</param>
        /// <returns>Status</returns>
        /// <response code="200">Vraćen je traženi Status</response>
        /// <response code="404">Nije pronađen Status sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{statusId}")]
        public ActionResult<StatusDTO> GetTipStatus(Guid statusId)
        {
            var status = statusrepository.GetStatusEntityById(statusId);

            if (status == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<StatusDTO>(status));
        }
        /// <summary>
        /// Kreira novi Status
        /// </summary>
        /// <remarks>
        /// Primer zahteva za kreiranje novog Status \
        /// POST /api/status \
        /// {   
        ///     "status": "Aktivan"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju Statusa</returns>
        /// <response code="201">Vraćen je kreiran Status</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog Statusa</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<StatusDTO> CreateStatus([FromBody] StatusCreationDTO status)
        {
            try
            {
                
                Status createdStatus = statusrepository.CreateStatus(mapper.Map<Status>(status));

                statusrepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetAllStatuses", "Status", new { statusId = createdStatus.statusID });

                return Created(location, mapper.Map<StatusDTO>(createdStatus));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Status error");
            }
        }
        /// <summary>
        /// Izmena Statusa
        /// </summary>
        /// <param name="statusId">ID Statusa</param>
        
        /// <returns>Potvrda o izmeni Statusa</returns>
        /// <response code="200">Izmenjen Status</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen Status sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene Statusa</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<StatusDTO> UpdateStatus( [FromBody] StatusDTO status)
        {
            try
            {
                

                var statusEntity = statusrepository.GetStatusEntityById(status.statusID);

                if (statusEntity == null)
                {


                    return NotFound();
                }
                Status novStatus = mapper.Map<Status>(status);
                mapper.Map(status, statusEntity);
                statusrepository.UpdateStatus(mapper.Map<Status>(novStatus));
                statusrepository.SaveChanges();


                return Ok(status);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update Status error");
            }

        }
        /// <summary>
        /// Brisanje Statusa na osnovu ID-ja
        /// </summary>
        /// <param name="statusId">ID Statusa</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">Status je uspešno obrisan</response>
        /// <response code="404">Nije pronađen Status sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja Statusa</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{statusId}")]
        public ActionResult DeleteStatus(Guid statusId)
        {
            try
            {
                var status = statusrepository.GetStatusEntityById(statusId);

                if (status == null)
                {

                    return NotFound();
                }

                statusrepository.DeleteStatus(statusId);
                statusrepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Status error");
            }
        }
    }
}
