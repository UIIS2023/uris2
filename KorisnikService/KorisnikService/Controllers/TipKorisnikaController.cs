using System;
using AutoMapper;
using KorisnikService.DtoModels;
using KorisnikService.Entities;
using KorisnikService.Repositories;
using KorisnikService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KorisnikService.ServiceCalls;

namespace KorisnikService.Controllers
{
	[ApiController]
	[Route("api/tipoviKorisnika")]
	[Produces("application/json", "application/xml")]
	public class TipKorisnikaController : ControllerBase
    {
		private readonly ITipKorisnikaRepository tipKorisnikaRepository;
		private readonly IMapper mapper;
		private readonly ILoggerService loggerService;
		private readonly Message message = new Message();
		private readonly string name = "Tip_korisnika";

		public TipKorisnikaController(ITipKorisnikaRepository tipKorisnikaRepository, IMapper mapper, ILoggerService loggerService)
		{
			this.mapper = mapper;
			this.tipKorisnikaRepository = tipKorisnikaRepository;
			this.loggerService = loggerService;
		}
        /// <summary>
        /// Vraca sve tipove korisnika.
        /// </summary>
        /// <returns> Lista tipova korisnika</returns>
        /// <response code="204">Nema tipova korisnika</response>
        /// <response code="200">Lista tipova korisnika</response>
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TipKorisnikaDto>> getAllTipoviKorisnika()
		{
			message.Method = "GET";
			message.ServiceName = name;
			List<TipKorisnika> tipoviKorisnika = tipKorisnikaRepository.getAllTipoviKorisnika();

			if(tipoviKorisnika == null || tipoviKorisnika.Count == 0)
			{
				message.Error = "No content";
				loggerService.CreateMessage(message);
				return NoContent();
			}
			message.Information = "Lista tipova korisnika";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<List<TipKorisnikaDto>>(tipoviKorisnika));
		}

        /// <summary>
        /// Vraca tip korisnika sa prosledjenim id-jem.
        /// </summary>
        /// <returns> Vraca tip korisnika</returns>
        /// <response code="200">Tip korisnika sa prosledjenim id-jem</response>
		/// <response code="404">Korisnik sa prosledjenim id-jem nije prosnadjen</response>
        [HttpGet("{korisnikId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TipKorisnikaDto> getTipKorisnikaById (Guid korisnikId)
		{
            message.Method = "GET";
            message.ServiceName = name;
            TipKorisnika tk = tipKorisnikaRepository.getTipKorisnikaById(korisnikId);
			if(tk == null)
			{
                message.Error = "Not found";
                loggerService.CreateMessage(message);
                return NotFound();
			}

            message.Error = "Tip korisnika sa prosledjenim id-jem";
            loggerService.CreateMessage(message);
            return Ok(mapper.Map<TipKorisnikaDto>(tk));
		}

        /// <summary>
        ///Brisanje tipa korisnika.
        /// </summary>
        /// <response code="204">Tip korisnika sa prosledjenim id-jem je uspesno obrisan</response>
        /// <response code="404">Korisnik sa prosledjenim id-jem nije prosnadjen</response>
        [HttpDelete("{tipKorisnikaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteTipKorisnika (Guid tipKorisnikaId)
		{
			message.Method = "DELETE";
			message.ServiceName = name;
			try
			{
                TipKorisnika tk = tipKorisnikaRepository.getTipKorisnikaById(tipKorisnikaId);
                if (tk == null)
                {
					message.Error = "Not found";
					loggerService.CreateMessage(message);
                    return NotFound();
                }

				message.Information = "Brisanje tipa korisnika";
				loggerService.CreateMessage(message);	
                tipKorisnikaRepository.deleteTipKorisnika(tipKorisnikaId);
                tipKorisnikaRepository.SaveChanges();
                return NoContent();

            }catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
			}
			
		}

        /// <summary>
        /// Kreiranje tipa korisnika.
        /// </summary>
        /// <returns> Vraca kreirani tip korisnika</returns>
        /// <response code="201">Tip korisnika je uspesno kreiran</response>
        /// <response code="500">Greska prilikom kreiranja tipa korisnika</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
		[Produces("application/json")]
        public ActionResult<TipKorisnikaDto> postTipKorisnika([FromBody] TipKorisnikaDto korisnik)
		{
			message.Method = "POST";
			message.ServiceName = name;
			try
			{
				TipKorisnika tipK = mapper.Map<TipKorisnika>(korisnik);
                TipKorisnika tipKorisnika = tipKorisnikaRepository.postTipKorisnika(tipK);
				tipKorisnikaRepository.SaveChanges();
				message.Information = "Tip korinika je kreiran";
				loggerService.CreateMessage(message);
				return Created("uri",mapper.Map<TipKorisnikaDto>(tipK));

            }catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
			}
			

		}

        /// <summary>
        /// Izmena tipa korisnika.
        /// </summary>
        /// <returns> Vraca izmenjeni tip korisnika</returns>
        /// <response code="200">Tip korisnika je uspesno izmenjen</response>
        /// <response code="500">Greska prilikom izmene tipa korisnika</response>
		/// <response code="404">Korisnik sa prosledjenim id-jem nije pronadjen</response>
        [HttpPut]
		[Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult putTipKorisnika(TipKorisnikaUpdateDto korisnik)
		{
			message.Method = "PUT";
			message.ServiceName = name;

			try
			{
				TipKorisnika tipKorisnika = mapper.Map<TipKorisnika>(korisnik);
				TipKorisnika tk = tipKorisnikaRepository.getTipKorisnikaById(tipKorisnika.tipKorisnikaId);

				if (tk == null)
				{
                    message.Error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
				}

				TipKorisnika tipKor = mapper.Map<TipKorisnika>(korisnik);
				mapper.Map(tipKor, tk);
				tipKorisnikaRepository.SaveChanges();
                message.Information = "Izmena tipa korisnika";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<TipKorisnikaDto>(tk));

			}catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Put error");
			}
		}
	}
}

