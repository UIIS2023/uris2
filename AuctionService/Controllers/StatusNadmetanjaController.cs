using System;
using AuctionService.DtoModels;
using AuctionService.Repository;
using AuctionService.ServiceCalls;
using AuctionService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers
{
	[ApiController]
	[Route("api/statusiNadmetanja")]
	[Produces("application/xml", "application/json")]
	public class StatusNadmetanjaController : ControllerBase
	{
		private readonly IStatusNadmetanjaRepository statusNadmetanjaRepository;
		private readonly IMapper mapper;
		private readonly string name = "Status_nadmetanja";
		private readonly ILogerService loggerService;
		private readonly Message message = new Message();

		public StatusNadmetanjaController(IStatusNadmetanjaRepository statusNadmetanjaService, IMapper mapper, ILogerService loggerService)
		{
			this.statusNadmetanjaRepository = statusNadmetanjaService;
			this.mapper = mapper;
			this.loggerService = loggerService;

		}

        /// <summary>
        /// Vraca sve statuse nadmetanja.
        /// </summary>
        /// <returns>Lista statusa nadmetanja</returns>
        /// <response code="200">Vraca listu statusa nadmetanja</response>
        /// <response code="204">Nije pronadjen ni jedan status nadmetanja</response>
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<List<StatusNadmetanjaDto>> getAllStatusiNadmetanja()
		{
			message.method = "GET";
			message.serviceName = name;
			List<Entities.StatusNadmetanja> statusiNadmetanja = statusNadmetanjaRepository.getAllStatusiNadmetanja();

			if (statusiNadmetanja == null || statusiNadmetanja.Count == 0)
			{
				message.error = "No content";
				loggerService.CreateMessage(message);
				return NoContent();
			}

			List<StatusNadmetanjaDto> statusiNadmetanjaDto = mapper.Map<List<StatusNadmetanjaDto>>(statusiNadmetanja);
			message.information = "Lista statusa nasmetanja";
			loggerService.CreateMessage(message);
			return Ok(mapper.Map<List<StatusNadmetanjaDto>>(statusiNadmetanjaDto));
		}

        /// <summary>
        /// Vraca jednan status nadmetanja na osnovu ID-ja.
        /// </summary>
        /// // <param name="statusNadmetanjaId">ID javnog nadmetanja</param>
        /// <returns>Trazeni status nadmetanja</returns>
        /// <response code="200">Tazeni status nadmetanja je uspesno pronadjen</response>
        /// <response code="404">Trazeni status nadmetanja nije pronadjen</response>
        [HttpGet("{statusNadmetanjaId}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<StatusNadmetanjaDto> getStatusNadmetanjaById(Guid statusNadmetanjaId)
		{
			message.method = "GET";
			message.serviceName = name;
			Entities.StatusNadmetanja statusNadmetanja = statusNadmetanjaRepository.getStatusNadmetanjaByID(statusNadmetanjaId);

			if (statusNadmetanja == null)
			{
				message.error = "Not found";
				loggerService.CreateMessage(message);
				return NotFound();
			}

			StatusNadmetanjaDto statusNadmetanjaDto = mapper.Map<StatusNadmetanjaDto>(statusNadmetanja);
			message.information = "Status nadmetanja sa prosledjenim id-jem je vracen";
			loggerService.CreateMessage(message);
			return Ok(mapper.Map<StatusNadmetanjaDto>(statusNadmetanjaDto));
		}

        /// <summary>
        /// Brise status nadmetanja.
        /// </summary>
        /// <param name="statusNadmetanjaId">ID statusa nadmetanja</param>
        /// <response code="204">Uspesno izvrseno brisanje</response>
        /// <response code="404">Nije pronadjen status nadmetanja sa datim id-jem</response>
        /// <response code="500">Desila se greska prilikom brisanja statusa nadmetanja</response>
        [HttpDelete("{statusNadmetanjaId}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult deleteStatusNadmetanja(Guid statusNadmetanjaId)
		{
			message.method = "DELETE";
			message.serviceName = name;
			try
			{
				Entities.StatusNadmetanja statusNadmetanja = statusNadmetanjaRepository.getStatusNadmetanjaByID(statusNadmetanjaId);

				if (statusNadmetanja == null)
				{
					message.error = "Not found";
					loggerService.CreateMessage(message);
					return NotFound();
				}

				statusNadmetanjaRepository.deleteStatusNadmetanja(statusNadmetanjaId);
				statusNadmetanjaRepository.SaveChanges();
				message.information = "Status nadmetanja je obrisan";
				loggerService.CreateMessage(message);
				return NoContent();

			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
			}

		}

        /// <summary>
        /// Updatuje status nadmetanja.
        /// </summary>
		/// <param name="statusNadmetanjaDto">Body koji sadzi podatke koji treba da se izmene</param>
        /// <returns> Vraca izmenjen status nadmetanja</returns>
        /// <response code="200">Updatovanje je uspesno izvrseno</response>
        /// <response code="404">Nije pronadjen status nadmetanja sa prosledjenim id-jem</response>
		/// <response code="500">Desila se greska prilikom updatovanja statusa nadmetanja</response>
        [HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<StatusNadmetanjaConformationDto> updateStatusNadmetanja(StatusJavnogNadmetanjaUpdateDto statusNadmetanjaDto)
		{ 

            message.method = "PUT";
			message.serviceName = name;
			try
			{
				Entities.StatusNadmetanja oldStatusNadetanja = statusNadmetanjaRepository.getStatusNadmetanjaByID(statusNadmetanjaDto.statusNadmetanjaID);

				if (oldStatusNadetanja == null)
				{
					message.error = "Not found";
			        loggerService.CreateMessage(message);
			         return NotFound();
				}
				Entities.StatusNadmetanja statusNadmetanja = mapper.Map<Entities.StatusNadmetanja>(statusNadmetanjaDto);
				mapper.Map(statusNadmetanja, oldStatusNadetanja);
				statusNadmetanjaRepository.SaveChanges();
				message.information = "Status nadmetanja je izmenjen";
				loggerService.CreateMessage(message);
		
				return Ok(mapper.Map<StatusNadmetanjaConformationDto>(oldStatusNadetanja));

			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
			}
		}

        /// <summary>
        /// Kreira novi status nadmetanja
        /// </summary>
		/// <param name="statusNadmetanjaDto">Body koji sadzi status nadmetanja koji treba da se kreira</param>
        /// <returns> Kreirani status nadmetanja </returns>
        /// <response code="201">Kreiranje statusa nadmetanja je uspesno izvrseno</response>
        [HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<StatusNadmetanjaConformationDto> postStatusNadmetanja([FromBody] StatusNadmetanjaCreationDto statusNadmetanjaDto)
		{
            message.method = "POST";
            message.serviceName = name;
            try
			{
				Entities.StatusNadmetanja statusNadmetanja = mapper.Map<Entities.StatusNadmetanja>(statusNadmetanjaDto);
				statusNadmetanjaRepository.postStatusNadmetanja(statusNadmetanja);
				statusNadmetanjaRepository.SaveChanges();
				message.information = "Status nadmetanja je kreiran";
				loggerService.CreateMessage(message);
				return Created("uri", mapper.Map<StatusNadmetanjaConformationDto>(statusNadmetanja));

			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
			}
		}
	}


}

