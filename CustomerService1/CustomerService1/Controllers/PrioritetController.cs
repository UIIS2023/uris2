using AutoMapper;
using CustomerService1.Data;
using CustomerService1.Entities;
using CustomerService1.Models;
using CustomerService1.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService1.Controllers
{
    [ApiController]
    [Route("api/prioriteti")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class PrioritetController : ControllerBase
    {
        private readonly IPrioritetRepository prioritetRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();
        public PrioritetController(IPrioritetRepository prioritetRepository, LinkGenerator linkGenerator, IMapper mapper, ILogerService loggerService)
        {
            this.prioritetRepository = prioritetRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;

        }
        /// <summary>
        /// Vraca sve prioritete
        /// </summary>
        /// <returns>Lista prioriteta</returns>
        //get prioritet
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PrioritetDto>> getPrioriteti()
        {
            message.method = "GET";

            var prior = prioritetRepository.getAllPrioritet();
            if (prior == null || prior.Count == 0)
            {
                message.information = "Nema prioriteta";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            message.information = "Lista prioriteta";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<PrioritetDto>>(prior));
        }
        /// <summary>
        /// Vraca prioritet sa zeljenim id-jem
        /// </summary>
        /// <param name="prioritetId">Id prioriteta</param>
        /// <returns>Vraca jedan prioritet</returns>
        //get prioritet by id
        [HttpGet("{prioritetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PrioritetDto> getPrioritetById(Guid prioritetId)
        {
            message.method = "GET";
            var pr = prioritetRepository.getPrioritetById(prioritetId);
            if (pr == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }
            message.information = "Prioritet je vracen";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<PrioritetDto>(pr));
        }
        /// <summary>
        /// Kreiranje novog prioriteta
        /// </summary>
        /// <param name="prioritet">Model prioriteta</param>
        /// <returns>Potvrda o kreiranom prioritetu</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog prioriteta
        /// {
        ///"opisPrioriteta": "prioritet5"
        ///}
        /// </remarks>
        //create prioritet
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrioritetDto> postPrioritet([FromBody] PrioritetCreationDto prioritet)
        {
            message.method = "POST";
            try
            {
                var p = mapper.Map<Prioritet>(prioritet);
                var confirmation = prioritetRepository.postPrioritet(p);
                string location = linkGenerator.GetPathByAction("getPrioriteti", "Prioritet", new { prioritetId = confirmation.PrioritetID });
                message.information = "Prioritet je uspesno izvrsen";
                loggerService.CreateMessage(message);
                return Created(location, mapper.Map<PrioritetConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
        /// <summary>
        /// Brisanje prioriteta
        /// </summary>
        /// <param name="prioritetId">Id prioriteta koji se brise</param>
        /// <returns></returns>
        //delete prioritet
        [HttpDelete("{prioritetId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deletePrioritet(Guid prioritetId)
        {
            message.method = "DELETE";
            try
            {
                var prior = prioritetRepository.getPrioritetById(prioritetId);
                if (prior == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                prioritetRepository.deletePrioritet(prioritetId);
                message.information = "Prioritet je obrisan";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Modifikovanje prioriteta
        /// </summary>
        /// <param name="prioritet">Model prioriteta</param>
        /// <returns>Potvrda o modifikovanom prioritetu</returns>
        /// <remarks>
        /// Primer zahteva za modifikovanje prioriteta
        /// {
        ///"prioritetID": "1de13266-85e8-4120-8b1f-daacc32c5811",
        /// "opisPrioriteta": "prior2"
        ///}
        /// </remarks>
        //update prioritet
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PrioritetConfirmation> putPrioritet(Prioritet prioritet)
        {
            message.method = "PUT";
            try
            {
                if (prioritetRepository.getPrioritetById(prioritet.PrioritetID) == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                message.information = "Prioritet je uspesno izmenjen";
                loggerService.CreateMessage(message);
                return Ok(prioritetRepository.updatePrioritet(prioritet));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
