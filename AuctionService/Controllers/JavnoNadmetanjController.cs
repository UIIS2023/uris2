using System;
using System.Collections.Generic;
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
	[Route("api/javnaNadmetanja")]
	[Produces("application/json", "application/xml")]
	public class JavnoNadmetanjController : ControllerBase
	{
		private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
		private readonly IMapper mapper;
		private readonly string name = "Javno_nadmetanje_service";
		private readonly IAdresaService adresaService;
		private readonly IOvlascenoLiceService ovlascenoLiceService;
		private readonly IKupacService kupacService;
		private readonly IParcelaService parcelaService;
		private readonly ILogerService loggerService;
		private readonly Message message = new Message();

		public JavnoNadmetanjController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, IMapper mapper, IAdresaService adresaService, IOvlascenoLiceService ovlascenoLiceService, IKupacService kupacService, IParcelaService parcelaService, ILogerService logerService)
		{
			this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
			this.mapper = mapper;
			this.adresaService = adresaService;
			this.ovlascenoLiceService = ovlascenoLiceService;
			this.parcelaService = parcelaService;
			this.kupacService = kupacService;
			this.loggerService = logerService;
			
		
		}
        /// <summary>
        /// Vraca sva javna nadmetanja.
        /// </summary>
        /// <returns> Lista javnih nadmetanja</returns>
        /// <response code="200">Vraca listu javnih nadmetanja</response>
        /// <response code="204">Nije pronadjen ni jedno javno nadmetanje</response>
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<JavnoNadmetanjeDto>> getAllJavnaNadmetanja()
		{
			message.serviceName = name;
			message.method = "GET";
			List<Entities.JavnoNadmetanje> javnaNadmetanja = javnoNadmetanjeRepository.getJavnaNadmetanja();
			if (javnaNadmetanja == null || javnaNadmetanja.Count == 0)
			{
               
                message.information = "Nema javnih nadmetanja";
				message.error = "No content";
                loggerService.CreateMessage(message);
                return NoContent();
            }


			List<JavnoNadmetanjeDto> javnoNadmetanjeDto = mapper.Map<List<JavnoNadmetanjeDto>>(javnaNadmetanja);
			message.information = "Lista javnih nadmetanja";
            loggerService.CreateMessage(message);
			
            foreach (JavnoNadmetanjeDto jn in javnoNadmetanjeDto)
			{
                jn.adreasa = adresaService.getAdresa(jn.adresaID).Result;
				jn.ovlascenoLice = ovlascenoLiceService.getOvlascenoLice(jn.ovlascenoLiceID).Result;
				jn.najboljiPonudjac = kupacService.getKupci(jn.najboljiPonudjacID).Result;
				foreach(Guid parcela in jn.parceleID)
				{
					jn.parcele.Add(parcelaService.getParcela(parcela).Result);
				}

				foreach(Guid kupci in jn.prijavljeniKupciID)
				{
					jn.prijavljeniKupci.Add(kupacService.getKupci(kupci).Result);
				}
				
			}
			loggerService.CreateMessage(message);
			return Ok(mapper.Map<List<JavnoNadmetanjeDto>>(javnoNadmetanjeDto));
		}

        /// <summary>
        /// Vraca jedno javno nadmetanje na osnovu ID-ja.
        /// </summary>
        /// // <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
        /// <returns>Trazeno javno nadmetanje</returns>
        /// <response code="200">Trazeno javno nadmetanje je uspesno pronadjeno</response>
        /// <response code="404">Trazeno javno nadmetanje nije pronadjeno</response>
        [HttpGet("{javnoNadmetanjeId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<JavnoNadmetanjeDto> getJavnoNadmetanjeById(Guid javnoNadmetanjeId)
		{
			message.serviceName = name;
			message.method = "GET";

			Entities.JavnoNadmetanje jn = javnoNadmetanjeRepository.getJavnoNadmetanjeByID(javnoNadmetanjeId);
			if (jn == null)
			{
				
				message.information = "Nema javnih nadmetanja";
				message.error = "No content";
                loggerService.CreateMessage(message);
                return NotFound();
            }

			JavnoNadmetanjeDto jnDto = mapper.Map<JavnoNadmetanjeDto>(jn);
			jnDto.adreasa = adresaService.getAdresa(jnDto.adresaID).Result;
			jnDto.ovlascenoLice = ovlascenoLiceService.getOvlascenoLice(jnDto.ovlascenoLiceID).Result;
			jnDto.najboljiPonudjac = kupacService.getKupci(jnDto.najboljiPonudjacID).Result;
			foreach(Guid p in jnDto.parceleID)
			{
				jnDto.parcele.Add(parcelaService.getParcela(p).Result);
			}
			foreach(Guid k in jnDto.prijavljeniKupciID)
			{
				jnDto.prijavljeniKupci.Add(kupacService.getKupci(k).Result);
			}
			message.information = "Lista javnih nadmetanja";
            loggerService.CreateMessage(message);
            return Ok(jnDto);
		}

		/// <summary>
		/// Brise javno nadmetanje.
		/// </summary>
		/// <param name="javnoNadmetanjeId">ID javnog nadmetanja</param>
		/// <response code="204">Uspesno izvrseno brisanje</response>
		/// <response code="404">Nije pronadjeno javno nadmetanje sa datim id-jem</response>
		/// <response code="500">Desila se greska prilikom brisanja javnog nadmetanja</response>
		[HttpDelete("{javnoNadmetanjeId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult deleteJavnoNadmetanje(Guid javnoNadmetanjeId)
		{
			message.serviceName = name;
			message.method = "DELETE";

			try
			{
				Entities.JavnoNadmetanje jn = javnoNadmetanjeRepository.getJavnoNadmetanjeByID(javnoNadmetanjeId);

				if (jn == null)
				{

					message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

				javnoNadmetanjeRepository.deleteJavnoNadmetanje(javnoNadmetanjeId);
				javnoNadmetanjeRepository.saveChanges();
				message.information = "Javno nadmetanje je obrisano";
                loggerService.CreateMessage(message);
                return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
			}

		}

        /// <summary>
        /// Updatuje javno nadmetanje.
        /// </summary>
		/// <param name="jnDto">Body koji sadzi podatke koji treba da se izmene</param>
        /// <returns> Vraca izmenjeno javno nadmetanje</returns>
        /// <response code="200">Updatovanje je uspesno izvrseno</response>
        /// <response code="404">Nije pronadjeno javno nadmetanje sa prosledjenim id-jem</response>
		/// <response code="500">Desila se greska prilikom updatovanja javnog nadmetanja</response>
        [HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<JavnoNadmetanjeConformationDto> putJavnoNadmetanje(JavnoNadmetanjeUpdateDto jnDto)
		{
			message.serviceName = name;
			message.method = "PUT";
			try
			{
				Entities.JavnoNadmetanje oldJn = javnoNadmetanjeRepository.getJavnoNadmetanjeByID(jnDto.javnoNadmetanjeID);

				if (oldJn == null)
				{            
                    message.error = "Not found";
                    loggerService.CreateMessage(message);
                    return NotFound();
                }

				Entities.JavnoNadmetanje javnoNadmetanje = mapper.Map<Entities.JavnoNadmetanje>(jnDto);
				mapper.Map(javnoNadmetanje, oldJn);
				javnoNadmetanjeRepository.saveChanges();
				message.information = "Javno nadmetanje je izmenjeno";
                loggerService.CreateMessage(message);
                return Ok(mapper.Map<JavnoNadmetanjeConformationDto>(oldJn));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
			}
		}

		/// <summary>
		/// Kreira novo javno nadmetanje
		/// </summary>
		/// <param name="javnoNadmetanjeDto">Body koji sadzi javno nadmetanje koje treba da se kreira</param>
		/// <returns> Kreirano javno nadmetanje</returns>
		/// <response code="201">Kreiranje jn je uspesno izvrseno</response>
		/// <response code="500">Desila se greska prilikom kreiranja javnog nademtanja</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<JavnoNadmetanjeConformationDto> postJavnoNadmetnanje([FromBody] JavnoNadmetanjeCreationDto javnoNadmetanjeDto)
		{
			message.method = "POST";
			message.serviceName = name;
			try
			{
				Entities.JavnoNadmetanje javnoNadmetanje = mapper.Map<Entities.JavnoNadmetanje>(javnoNadmetanjeDto);
				javnoNadmetanjeRepository.postJavnoNadmetanje(javnoNadmetanje);
				javnoNadmetanjeRepository.saveChanges();
				message.information = "Javno nadmetanje je kreirano";
                loggerService.CreateMessage(message);
                return Created("uri", mapper.Map<JavnoNadmetanjeConformationDto>(javnoNadmetanje));

			}
			catch (Exception ex)
			{
                message.error = "Post error";
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
				
			}
		}
	}
}

