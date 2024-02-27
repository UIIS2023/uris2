using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za  žalbe
    /// </summary>
    [ApiController]
    [Route("api/zalba")]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository zalberepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public ZalbaController(IZalbaRepository zalberepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.zalberepository = zalberepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <response code="200">Vraćena je lsita  žalbi</response>
        /// <response code="204">Nije pronađen ni jedna žalbe</response>
        /// <returns>Lista  žalbi</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<ZalbaDTO>> GetAllZalbas()
        {
            var zalbe = zalberepository.GetAllZalbas();

            if (zalbe == null || zalbe.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<ZalbaDTO>>(zalbe));
        }
        /// <summary>
        /// Vraća  žalbu sa prosleđnim ID-jem
        /// </summary>
        /// <param name="zalbaId">ID tipa žalbe</param>
        /// <returns> žalba</returns>
        /// <response code="200">Vraćena je tražena žalba</response>
        /// <response code="404">Nije pronađena zalba sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{zalbaId}")]
        public ActionResult<ZalbaDTO> GetZalba(Guid zalbaId)
        {
            var zalba = zalberepository.GetZalbaEntityById(zalbaId);

            if (zalba == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<ZalbaDTO>(zalba));
        }
        /// <summary>
        /// Kreira nove  žalbe
        /// </summary>
        /// <param name="tipZalbe">Model  žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove žalbe \
        /// POST /api/zalbe \
        /// {   
        ///     "zalbe": "Zalba na Odluku o davanju u zakup"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju  žalbe</returns>
        /// <response code="201">Vraćena je kreirana  žalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa nove žalbe</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<ZalbaDTO> CreateZalba([FromBody] ZalbaCreationDTO zalba)
        {
            try
            {


                Zalba createdZalba = zalberepository.CreateZalba(mapper.Map<Zalba>(zalba));
                zalberepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAllZalbas", "Zalba", new { zalbaId = createdZalba.zalbaId });

                return Created(location, mapper.Map<ZalbaDTO>(createdZalba));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Zalba error");
            }

        }
        /// <summary>
        /// Izmena  žalbe
        /// </summary>
        /// <param name="zalbaId">ID tipa žalbe</param>
        /// <param name="tipZalbe">Model  zalbe</param>
        /// <returns>Potvrda o izmeni  žalbe</returns>
        /// <response code="200">Izmenjena  zalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađena  žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene  žalbe</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<ZalbaDTO> UpdateZalba([FromBody] ZalbaDTO zalba)
        {
            try
            {


                var zalbaEntity = zalberepository.GetZalbaEntityById(zalba.zalbaId);

                if (zalbaEntity == null)
                {


                    return NotFound();
                }
                Zalba novZalbe = mapper.Map<Zalba>(zalba);

                mapper.Map(novZalbe, zalbaEntity);
                zalberepository.UpdateZalba(mapper.Map<Zalba>(novZalbe));
                zalberepository.SaveChanges();


                return Ok(zalba);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update Zalbe error");
            }

        }
        /// <summary>
        /// Brisanje  žalbe na osnovu ID-ja
        /// </summary>
        /// <param name="tipZalbeId">ID  žalbe</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204"> žalba je uspešno obrisan</response>
        /// <response code="404">Nije pronađena žalba sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja  žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{zalbaId}")]
        public ActionResult DeleteZalba(Guid zalbaId)
        {
            try
            {
                var zalba = zalberepository.GetZalbaEntityById(zalbaId);

                if (zalba == null)
                {

                    return NotFound();
                }

                zalberepository.DeleteZalba(zalbaId);
                zalberepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete  Zalbe error");
            }
        }
    }
}
