using AutoMapper;
using Dokumenti_Service.Data;
using Dokumenti_Service.Entities.Zalba;
using Dokumenti_Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dokumenti_Service.Controllers
{
    /// <summary>
    /// Kontroler za tip žalbe
    /// </summary>
    [ApiController]
    [Route("api/tipZalbe")]
    public class TipZalbeController : ControllerBase
    {
        private readonly ITipZalbeRepository tipZalberepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public TipZalbeController(ITipZalbeRepository tipZalberepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.tipZalberepository = tipZalberepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// </summary>
        /// <param name="complaintType">Naziv tipa žalbe</param>
        /// <response code="200">Vraćena je lsita tipova žalbi</response>
        /// <response code="204">Nije pronađen ni jedan tip žalbe</response>
        /// <returns>Lista tipova žalbi</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<TipZalbeDTO>> GetAllTipZalbes()
        {
            var tipoviZalbe = tipZalberepository.GetAllTipZalbes();

            if (tipoviZalbe == null || tipoviZalbe.Count == 0)
            {
                
                return NoContent();
            }

            
            return Ok(mapper.Map<List<TipZalbeDTO>>(tipoviZalbe));
        }
        /// <summary>
        /// Vraća tip žalbe sa prosleđnim ID-jem
        /// </summary>
        /// <param name="tipZalbeIdId">ID tipa žalbe</param>
        /// <returns>Tip žalbe</returns>
        /// <response code="200">Vraćen je traženi tip žalbe</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{tipZalbeId}")]
        public ActionResult<TipZalbeDTO> GetTipZalbe(Guid tipZalbeId)
        {
            var tipZalbe = tipZalberepository.GetTipZalbeEntityById(tipZalbeId);

            if (tipZalbe == null)
            {
                
                return NotFound();
            }
            
            return Ok(mapper.Map<TipZalbeDTO>(tipZalbe));
        }
        /// <summary>
        /// Kreira novi tip žalbe
        /// </summary>
        /// <param name="tipZalbe">Model tipa žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa žalbe \
        /// POST /api/tipZalbe \
        /// {   
        ///     "tipZalbe": "Zalba na Odluku o davanju u zakup"
        ///}
        /// </remarks>
        /// <returns>Potvrda o kreiranju tipa žalbe</returns>
        /// <response code="201">Vraćen je kreiran tip žalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="500">Desila se greška prilikom unosa novog tipa žalbe</response>
        ///[Consumes("applciation/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<TipZalbeDTO> CreateTipZalbe([FromBody] TipZalbeCreationDTO tipZalbe)
        {
            try
            {
                

                    TipZalbe createdTipZalbe = tipZalberepository.CreateTipZalbe(mapper.Map<TipZalbe>(tipZalbe));
            tipZalberepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetAllTipZalbes", "TipZalbe", new { tipZalbeId = createdTipZalbe.tipZalbeId });

                return Created(location, mapper.Map<TipZalbeDTO>(createdTipZalbe));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Complaint Type error");
            }
            
        }
        /// <summary>
        /// Izmena tipa žalbe
        /// </summary>
        /// <param name="tipZalbeId">ID tipa žalbe</param>
        /// <param name="tipZalbe">Model tipa zalbe</param>
        /// <returns>Potvrda o izmeni tipa žalbe</returns>
        /// <response code="200">Izmenjen tip zalbe</response>
        /// <response code="400">Uneti podaci se već nalaze u bazi podataka</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom izmene tipa žalbe</response>
        ///[Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<TipZalbeDTO> UpdateTipZalbe([FromBody] TipZalbeDTO tipZalbe)
        {
            try
            {
                

                var tipZalbeEntity = tipZalberepository.GetTipZalbeEntityById(tipZalbe.tipZalbeId);

                if (tipZalbeEntity == null)
                {
                    

                    return NotFound();
                }
                TipZalbe novTipZalbe = mapper.Map<TipZalbe>(tipZalbe);

                mapper.Map(novTipZalbe,tipZalbeEntity);
                tipZalberepository.UpdateTipZalbe(mapper.Map<TipZalbe>(novTipZalbe));
                tipZalberepository.SaveChanges();


                return Ok(tipZalbe);
            }
            catch (Exception exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Update TipZalbe error");
            } 

        }
        /// <summary>
        /// Brisanje tipa žalbe na osnovu ID-ja
        /// </summary>
        /// <param name="tipZalbeId">ID tipa žalbe</param>
        /// <returns>Status 204 (No Content)</returns>
        /// <response code="204">Tip žalbe je uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip žalbe sa unetim ID-jem</response>
        /// <response code="500">Serverska greška tokom brisanja tipa žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{tipZalbeId}")]
        public ActionResult DeleteTipZalbe(Guid tipZalbeId)
        {
            try
            {
                var tipZalbe = tipZalberepository.GetTipZalbeEntityById(tipZalbeId);

                if (tipZalbe == null)
                {
                    
                    return NotFound();
                }

                tipZalberepository.DeleteTipZalbe(tipZalbeId);
                tipZalberepository.SaveChanges();

                return NoContent();
            }
            catch
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Tip Zalbe error");
            }
        }

    }

}
