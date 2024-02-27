using AutoMapper;
using CustomerService1.Data;
using CustomerService1.Entities;
using CustomerService1.Models;
using CustomerService1.ServiceCalls;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerService1.Controllers
{
    [ApiController]
    [Route("api/kontaktOsobe")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class KontaktOsobaController : ControllerBase
    {
        private readonly IKontaktOsobaRepository _kontaktOsobaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        public KontaktOsobaController(IKontaktOsobaRepository kontaktOsobaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            _kontaktOsobaRepository = kontaktOsobaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;

        }
        /// <summary>
        /// Vraca sve kontakt osobe.
        /// </summary>
        /// <returns>Lista kontakt osoba</returns>
        //get kontakt osobe
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<KontaktOsobaDto>> getKontaktOsobe()
        {
            message.method = "GET";
            var kOsobe = _kontaktOsobaRepository.getAllKontaktOsobe();
            if (kOsobe == null || kOsobe.Count== 0)
            {
                message.information = "Nema kontakt osoba";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            message.information = "Lista kontakt osoba";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map < List < KontaktOsobaDto >>(kOsobe));
        }
        /// <summary>
        /// Vraca kontakt osobu sa zeljenim id-jem.
        /// </summary>
        /// <param name="kontaktOsobaId">Id kontakt osobe</param>
        /// <returns>Vraca jednu kontakt osobu.</returns>
        //get kontakt osoba by id
        [HttpGet("{kontaktOsobaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<KontaktOsobaDto> getKontatOsobaById(Guid kontaktOsobaId)
        {
            message.method = "GET";
            var ko = _kontaktOsobaRepository.getKontaktOsobaById(kontaktOsobaId);
            if (ko == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }
            message.information = "Kontakt osoba je vracena";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KontaktOsobaDto>(ko));
        }
        /// <summary>
        /// Kreiranje nove kontakt osobe.
        /// </summary>
        /// <param name="kontaktOsoba">Model kontakt osobe</param>
        /// <returns>Potvrda o kreiranoj kontakt osobi</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove kontakt osobe \ 
        /// POST /api/kontaktOsobe  \ 
        /// { 
        ///     "ime": "Sonja",
        ///     "prezime": "Peric",
        ///     "funkcija": "funkc4",
        ///     "telefon": "0644521498"       
        /// }
        /// </remarks>
        //create kontakt osoba
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KontaktOsobaDto> postKontaktOsoba([FromBody] KontaktOsobaCreationDto kontaktOsoba)
        {
            message.method = "POST";
            try
            {
                var ko = mapper.Map<KontaktOsoba>(kontaktOsoba);
                var confirmation = _kontaktOsobaRepository.postKontaktOsoba(ko);
                string location = linkGenerator.GetPathByAction("getKontaktOsobe", "KontaktOsoba", new { kontaktOsobaId = confirmation.KontaktOsobaID });
                message.information = "Kontakt osoba je uspesno izvrsen";
                loggerService.CreateMessage(message);
                return Created(location, mapper.Map<KontaktOsobaConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
        /// <summary>
        /// Brisanje kontakt osobe.
        /// </summary>
        /// <param name="kontaktOsobaId">Id kontakt osobe koja se brise</param>
        /// <returns></returns>
        //delete kontakt osoba
        [HttpDelete("{kontaktOsobaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKontaktOsoba(Guid kontaktOsobaId)
        {
            message.method = "DELETE";
            try
            {
                var ko = _kontaktOsobaRepository.getKontaktOsobaById(kontaktOsobaId);
                if (ko == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                _kontaktOsobaRepository.deleteKontaktOsoba(kontaktOsobaId);
                message.information = "Kontakt osoba je obrisana";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        //update kontakt osoba
       // [HttpPut]
        /* public ActionResult<KontaktOsobaConfirmationDto> putKontaktOsoba(KontaktOsobaUpdateDto kontaktOsoba)
         {
             try
             {

                 KontaktOsoba oldKontaktOsoba = _kontaktOsobaRepository.getKontaktOsobaById(kontaktOsoba.KontaktOsobaID);
                 if (oldKontaktOsoba==null)
                 {
                     return NotFound();
                 }
                 KontaktOsoba ko = mapper.Map<KontaktOsoba>(kontaktOsoba);

                 mapper.Map(ko, oldKontaktOsoba);
                 _kontaktOsobaRepository.SaveChanges();
                 return Ok(mapper.Map<KontaktOsobaConfirmationDto>(oldKontaktOsoba));

             }
             catch 
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
             }
         }*/
        /// <summary>
        /// Modifikovanje kontakt osobe.
        /// </summary>
        /// <param name="kontaktOsoba">Model kontakt osobe</param>
        /// <returns>Potvrda o modifikovanoj kontakt osobi.</returns>
        /// <remarks>
        /// Primer zahteva za modifikovanje kontakt osobe
        /// {
        ///"kontaktOsobaID": "a215e4cb-a427-40cf-88b2-8488d140a939",
        ///"ime": "Sofija",
        ///"prezime": "Nikolic",
        ///"funkcija": "funkc5",
        ///"telefon": "0649855123"
        ///}
    /// </remarks>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KontaktOsobaConfirmation> putKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            message.method = "PUT";
            try
            {
                if (_kontaktOsobaRepository.getKontaktOsobaById(kontaktOsoba.KontaktOsobaID) == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                message.information = "Kontakt osoba je uspesno izmenjen";
                loggerService.CreateMessage(message);
                return Ok(_kontaktOsobaRepository.updateKontaktOsoba(kontaktOsoba));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

    }
}
