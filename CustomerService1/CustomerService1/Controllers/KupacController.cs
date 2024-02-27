using AutoMapper;
using CustomerService1.Data;
using CustomerService1.Entities;
using CustomerService1.Models;
using CustomerService1.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService1.Controllers
{
    [ApiController]
    [Route("api/kupci")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class KupacController: ControllerBase
    {
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();

        public KupacController(IKupacRepository kupacRepository, LinkGenerator linkGenerator, IMapper mapper, ILogerService loggerService)
        {
            this.kupacRepository= kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.loggerService = loggerService;

        }
        /// <summary>
        /// Vraca sve kupce
        /// </summary>
        /// <returns>Lista kupaca</returns>
        //get kupci
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<KupacDto>> getKupci()
        {
            message.method = "GET";
            var kupci = kupacRepository.getAllKupci();
            if (kupci == null || kupci.Count == 0)
            {
                message.information = "Nema kupaca";
                message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }
            message.information = "Lista kupaca";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<KupacDto>>(kupci));
        }
        /// <summary>
        /// Vraca kupca sa zeljenim id-jem
        /// </summary>
        /// <param name="kupacId">Id kupca</param>
        /// <returns>Vraca jednog kupca</returns>
        //get kupac by id
        [HttpGet("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<KupacDto> getKupacById(Guid kupacId)
        {
            message.method = "GET";
            var ku = kupacRepository.getKupacById(kupacId);
            if (ku == null)
            {
                message.error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }
            message.information = "Kupac je vracen";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KupacDto>(ku));
        }
        /// <summary>
        /// Kreiranje novog kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns>Potvrda o kreiranom kupcu</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog kupca
        /// {
        ///"fizPravno": true,
        ///"ostvarenaPovrsina": "150",
        ///"zabrana": true,
        ///"pocetakZabrane": "2023-02-13T13:16:11.043Z",
        ///"duzinaZabrane": "1 godina",
        ///"prestanakZabrane": "2024-02-13T13:16:11.043Z",
        ///"ovlascenoLiceID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"prioritetID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"brTel1": "1111111",
        ///"brTel2": "2222",
        ///"adresaID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"uplataID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"email": "sl200@gmail.com",
        ///"brojRacuna": "2121212"
        ///}
        /// </remarks>
        //create kupac
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacDto> postKupac([FromBody] KupacCreationDto kupac)
        {
            message.method = "POST";
            try
            {
                var ku = mapper.Map<Kupac>(kupac);
                var confirmation = kupacRepository.postKupac(ku);
                string location = linkGenerator.GetPathByAction("getKupci", "Kupac", new { kontaktOsobaId = confirmation.KupacID });
                message.information = "Kupac je uspesno izvrsen";
                loggerService.CreateMessage(message);
                return Created(location, mapper.Map<KupacConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
        /// <summary>
        /// Brisanje kupca 
        /// </summary>
        /// <param name="kupacId">Id kupca koji se brise</param>
        /// <returns></returns>
        //delete kupac
        [HttpDelete("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKupac(Guid kupacId)
        {
            message.method = "DELETE";
            try
            {
                var ku = kupacRepository.getKupacById(kupacId);
                if (ku == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                kupacRepository.deleteKupac(kupacId);
                message.information = "Kupac je obrisan";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Modifikovanje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns>Potvrda o modifikovanom kupcu</returns>
        /// ///<remarks>
        /// Primer zahteva za modifikovanje kupca
        /// {
        ///"kupacID": "208a48a5-371c-4f9d-ac23-18bb176ff8f3",
        /// "fizPravno": true,
        ///"ostvarenaPovrsina": "200",
        /// "zabrana": true,
        /// "pocetakZabrane": "2023-02-13T13:16:11.070Z",
        ///"duzinaZabrane": "1",
        ///"prestanakZabrane": "2024-02-13T13:16:11.070Z",
        /// "ovlascenoLiceID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        /// "prioritetID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        /// "brTel1": "0654355498",
        /// "brTel2": "256487",
        /// "adresaID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///"uplataID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        /// "email": "nikola@gmail.com",
        /// "brojRacuna": "1212121",
        /// "ovlascenoLice": {
        ///   "ovlascenoLiceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///   "ime": "Dusan",
        ///   "prezime": "Vojinovic",
        ///  "licaZaKojaVrsiLicitaciju": [
        ///    "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///   ],
        ///   "brojTabli": [
        ///     0
        ///   ]
        ///   },
        /// "uplata": {
        ///  "uplataID": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "iznos": 15000
        ///},
        ///"adresa": {
        ///  "adresaId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "ulica": "Bulevar Oslobodjenja",
        ///  "broj": "165",
        ///  "mesto": "Novi Sad",
        ///  "postanskiBroj": "21000",
        ///  "drzava": "Srbija"
        ///}
        /// }
        /// </remarks>
        //update kupac
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KupacConfirmation> putKupac(Kupac kupac)
        {
            message.method = "PUT";
            try
            {
                if (kupacRepository.getKupacById(kupac.KupacID) == null)
                {
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }
                message.information = "Kupac je uspesno izmenjen";
                loggerService.CreateMessage(message);
                return Ok(kupacRepository.updateKupac(kupac));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

    }
}
