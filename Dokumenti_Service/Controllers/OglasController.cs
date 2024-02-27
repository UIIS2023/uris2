using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Oglas;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za oglase
    /// </summary>
    [ApiController]
    [Route("api/oglas")]
    public class OglasController : ControllerBase
    {
        private readonly IOglasRepository oglasirepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public OglasController(IOglasRepository oglasirepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.oglasirepository = oglasirepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <param name="complaintType">Naziv oglasa</param>
        /// <response code="200">Vraćena je lsita oglasa</response>
        /// <response code="204">Nije pronađen ni jedan oglas</response>
        /// <returns>Lista oglasa</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<OglasDTO>> GetAllOglases()
        {
            var oglasi = oglasirepository.GetAllOglases();

            if (oglasi == null || oglasi.Count == 0)
            {

                return NoContent();
            }


            return Ok(mapper.Map<List<OglasDTO>>(oglasi));
        }
        /// <summary>
        /// Vraća oglas sa prosleđnim ID-jem
        /// </summary>
        /// <param name="oglasId">ID oglasa</param>
        /// <returns>Tip žalbe</returns>
        /// <response code="200">Vraćen je traženi oglas</response>
        /// <response code="404">Nije pronađen oglas sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{oglasId}")]
        public ActionResult<OglasDTO> GetOglas(Guid oglasId)
        {
            var oglas = oglasirepository.GetOglasEntityById(oglasId);

            if (oglas == null)
            {

                return NotFound();
            }

            return Ok(mapper.Map<OglasDTO>(oglas));
        }
        /// <summary>
        /// Kreira novi oglas
        /// </summary>
        /// <param name="oglas">Model oglasa</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog oglasa \
        /// POST /api/oglas \
        /// {   
        ///     "oglas": "Davanje zemljišta u zakup"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju oglasae</returns>
        /// <response code="201">Vraćen je kreiran oglas</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog oglasa</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<OglasDTO> CreateOglas([FromBody] OglasCreationDTO oglas)
        {
            try
            {


                Oglas createdOglas = oglasirepository.CreateOglas(mapper.Map<Oglas>(oglas));
                oglasirepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAllOglases", "Oglas", new { oglasId = createdOglas.oglasId });

                return Created(location, mapper.Map<OglasDTO>(createdOglas));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Oglas error");
            }

        }
        /// <summary>
        /// Izmena oglasa
        /// </summary>
        /// <returns>Potvrda o izmeni oglasa</returns>
        /// <response code="200">Izmenjen oglas</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen oglas sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene oglasa</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<OglasDTO> UpdateOglas([FromBody] OglasDTO oglas)
        {
            try
            {


                var oglasEntity = oglasirepository.GetOglasEntityById(oglas.oglasId);

                if (oglasEntity == null)
                {


                    return NotFound();
                }
                Oglas novOglas = mapper.Map<Oglas>(oglas);

                mapper.Map(novOglas, oglasEntity);
                oglasirepository.UpdateOglas(mapper.Map<Oglas>(novOglas));
                oglasirepository.SaveChanges();


                return Ok(oglas);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update oglas error");
            }

        }
        /// <summary>
        /// Brisanje oglasa na osnovu ID-ja
        /// </summary>
        /// <param name="oglasId">ID oglasa</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">oglas je uspešno obrisan</response>
        /// <response code="404">Nije pronađen oglas sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja oglasa</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{oglasId}")]
        public ActionResult DeleteOglas(Guid oglasId)
        {
            try
            {
                var oglas = oglasirepository.GetOglasEntityById(oglasId);

                if (oglas == null)
                {

                    return NotFound();
                }

                oglasirepository.DeleteOglas(oglasId);
                oglasirepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Oglas error");
            }
        }
    }
}
