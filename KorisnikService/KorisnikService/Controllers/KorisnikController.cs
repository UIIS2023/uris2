using System;
using AutoMapper;
using KorisnikService.DtoModels;
using KorisnikService.Entities;
using KorisnikService.Repositories;
using KorisnikService.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace KorisnikService.Controllers 
{
	[ApiController]
    [Route("api/korisnici")]
    [Produces("application/json", "application/xml")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikRepository korisnikRepository;
        private readonly IMapper mapper;
        private readonly ILoggerService loggerService;
        private readonly Message message = new Message();
        private readonly string name = "Korisnik service";
        public KorisnikController(IKorisnikRepository korisnikRepository, IMapper mapper, ILoggerService loggerService)
		{
            this.korisnikRepository = korisnikRepository;
            this.mapper = mapper;
            this.loggerService = loggerService;
		}

        /// <summary>
        /// Vraca sve korisnike.
        /// </summary>
        /// <returns> Lista korisnika</returns>
        /// <response code="200">Lista korisnika</response>
        /// <response code="404">Nije pronadjen ni jedan korisnik</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<KorisnikDto>> getAllKorisnici()
        {
            message.Method = "GET";
            message.ServiceName = name;
            List<Korisnik> korisnici = korisnikRepository.getAllKorisnici();

            if (korisnici == null || korisnici.Count == 0)
            {
                message.Error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }

            message.Information = "Lista korisnika vracena";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<KorisnikDto>>(korisnici));
        }

        /// <summary>
        /// Vraca samojednog korisnika.
        /// </summary>
        /// <returns> Jedan korisnik</returns>
        /// <response code="200">Korisni je uspesno pronadjen</response>
        /// <response code="404">Korisnik nije pronadjen</response>

        [HttpGet("{korisnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<KorisnikDto> getKorisnikById(Guid korisnikId)
        {
            message.Method = "GET";
            message.ServiceName = name;
            Korisnik k = korisnikRepository.getKorisnikById(korisnikId);
            if (k == null)
            {
                message.Error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
            }

            message.Information = "Korisnik sa prosledjenim id-jem vracen";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<KorisnikDto>(k));
        }

        /// <summary>
        /// Brise korisnika.
        /// </summary>
        /// <response code="204">Korisnik je uspesno obrisan</response>
        /// <response code="404">Nema korisnika sa prosledjenim id-jem</response>
        /// <response code="500">Greska prilikom brisanja korisnika</response>
        [HttpDelete("{korisnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteKorisnik(Guid korisnikId)
        {
            message.Method = "DELETE";
            message.ServiceName = name;
            try
            {
                Korisnik k = korisnikRepository.getKorisnikById(korisnikId);
                if (k == null)
                {
                    message.Error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

                korisnikRepository.deleteKorisnik(korisnikId);
                korisnikRepository.SaveChanges();
                message.Information = "Brisanje korisnika";
                loggerService.CreateMessage(message);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }

        /// <summary>
        /// Kreiranje korisnika.
        /// </summary>
        /// <returns>Krreirani korisnik</returns>
        /// <response code="201">Korisnik je uspesno kreiran</response>
        /// <response code="500">Greska prilikom kreiranja korisnika</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public ActionResult<KorisnikDto> postKorisnik([FromBody] KorisnikCreateDto korisnik)
        {
            message.ServiceName = name;
            message.Method = "POST";
            try
            {
                Korisnik K = mapper.Map<Korisnik>(korisnik);
                Korisnik kor = korisnikRepository.postKorisnik(K);
                korisnikRepository.SaveChanges();
                message.Information = "Korisnik je kreiran";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<KorisnikDto>(kor));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }


        }

        /// <summary>
        /// Izmena korisnika.
        /// </summary>
        /// <response code="200">Korisnik je uspesno izmenjen</response>
        /// <response code="404">Nema korisnika sa prosledjenim id-jem</response>
        /// <response code="500">Greska prilikom izmene korisnika</response>

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult putKorisnik(KorisnikUpdateDto korisnik)
        {
            message.Method = "PUT";
            message.ServiceName = name;
            try
            {
                Korisnik Korisnik = mapper.Map<Korisnik>(korisnik);
                Korisnik k = korisnikRepository.getKorisnikById(Korisnik.korisnikId);

                if (k == null)
                {
                    message.Error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }


                KorisnikDto korisnikDto = mapper.Map<KorisnikDto>(korisnik);
                mapper.Map(korisnikDto, k);
                message.Information = "Korisnik je uspesno izmenjen";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<KorisnikDto>(k));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Put error");
            }
        }
    }
}

