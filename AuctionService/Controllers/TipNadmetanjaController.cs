using System;
using AuctionService.DtoModels;
using AuctionService.Repository;
using AuctionService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuctionService.ServiceCalls;


namespace AuctionService.Controllers
{
	[ApiController]
	[Route("api/tipoviNadmetanja")]
    [Produces("application/json", "application/xml")]
    public class TipJavnogNadmetanjaController : ControllerBase
	{
		private readonly ITipNadmetanjaRepository tipNadmetanjaRepository;
		private readonly IMapper mapper;
		private readonly string naziv = "Tip_javnog_nadmetanja";
        private readonly ILogerService loggerService;
        private readonly Message message = new Message();


        public TipJavnogNadmetanjaController(ITipNadmetanjaRepository tipNadmetanjaService,IMapper mapper, ILogerService loggerService)
		{
			this.tipNadmetanjaRepository = tipNadmetanjaService;
			this.mapper = mapper;
			this.loggerService = loggerService;
		}

        /// <summary>
        /// Vraca sve tipove nadmetanja.
        /// </summary>
        /// <returns>Lista tipova nadmetanja</returns>
        /// <response code="200">Vraca listu tipova nadmetanja</response>
        /// <response code="204">Nije pronadjen ni jedan tip nadmetanja</response>
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<List<TipNadmetanjaDto>> getAllTipoviNadmetanja()
		{
			List<Entities.TipJavnogNadmetanja> tipoviNadmetanja = tipNadmetanjaRepository.getAllTipoviJavnogNadmetanja();

			message.serviceName = naziv;
			message.method = "GET";

			if(tipoviNadmetanja == null || tipoviNadmetanja.Count == 0)
			{
				message.information = "Nema tipova javnih nadmetanja";
				message.error = "No content";
				loggerService.CreateMessage(message);
				return NoContent();
			}

			message.information = "Lista tipova javnih nadmetanja";
			loggerService.CreateMessage(message);

			//ovde samo ceo objekat namapirmao na dto objekat klase
			List<TipNadmetanjaDto> tipoviNadmetanjaDto = mapper.Map<List<TipNadmetanjaDto>>(tipoviNadmetanja);

			//prolazimo kroz te objekte i returnujemo ih
			return Ok(mapper.Map<List<TipNadmetanjaDto>>(tipoviNadmetanjaDto));
		}

        /// <summary>
        /// Vraca jednan tip nadmetanja na osnovu ID-ja.
        /// </summary>
        /// // <param name="tipNadmetanjaId">ID javnog nadmetanja</param>
        /// <returns>Trazeni tip nadmetanja</returns>
        /// <response code="200">Tazeni tip nadmetanja je uspesno pronadjen</response>
        /// <response code="404">Trazeni tip nadmetanja nije pronadjen</response>
        [HttpGet("{tipNadmetanjaId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<TipNadmetanjaDto> geTipJavnogNadmetanjaById(Guid tipNadmetanjaId)
		{
			message.method = "GET";
			message.serviceName = naziv;
			Entities.TipJavnogNadmetanja tipNadmetanja = tipNadmetanjaRepository.getTipJavnogNadmetanjaById(tipNadmetanjaId);

			if(tipNadmetanja == null)
			{
				message.error = "Not found";
				loggerService.CreateMessage(message);
				return NotFound();
			}

			TipNadmetanjaDto tipJnDto = mapper.Map<TipNadmetanjaDto>(tipNadmetanja);
			message.information = "Tip nadmetanja je vracen";
			loggerService.CreateMessage(message);
			return Ok(mapper.Map<TipNadmetanjaDto>(tipJnDto));

		}

        /// <summary>
        /// Brise tip nadmetanja.
        /// </summary>
        /// <param name="tipNadmetanjaId">ID tipa nadmetanja</param>
        /// <response code="204">Uspesno izvrseno brisanje</response>
        /// <response code="404">Nije pronadjen tip nadmetanja sa datim id-jem</response>
        /// <response code="500">Desila se greska prilikom brisanja tip nadmetanja</response>
        [HttpDelete("{tipNadmetanjaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteTipNadmetanja(Guid tipNadmetanjaId)
		{
            message.method = "DELETE";
            message.serviceName = naziv;
            try
			{
				
				Entities.TipJavnogNadmetanja tipNadmetanja = tipNadmetanjaRepository.getTipJavnogNadmetanjaById(tipNadmetanjaId);

				if (tipNadmetanja == null)
				{
					message.error = "Not found";
					loggerService.CreateMessage(message);
					return NotFound();
				}

				tipNadmetanjaRepository.deleteTipJavnogNadmetanja(tipNadmetanjaId);
				tipNadmetanjaRepository.SaveChanges();
				message.information = "Tip nadmeranja je obrisan";
				loggerService.CreateMessage(message);
				return NoContent();

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
			}
			
		}

        /// <summary>
        /// Updatuje tip nadmetanja.
        /// </summary>
		/// <param name="tipNadmetanjaDto">Body koji sadzi podatke koji treba da se izmene</param>
        /// <returns> Vraca izmenjen tip nadmetanja</returns>
        /// <response code="200">Updatovanje je uspesno izvrseno</response>
        /// <response code="404">Nije pronadjen tip nadmetanja sa prosledjenim id-jem</response>
		/// <response code="500">Desila se greska prilikom updatovanja tipa nadmetanja</response>
        [HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipJavnogNadmetanjaConformationDto> putTipJavnogNadmetanja(TipJavnogNadmetanjaUpdateDto tipNadmetanjaDto)
		{
            message.method = "PUT";
            message.serviceName = naziv;
            try
			{
				Entities.TipJavnogNadmetanja oldTipJn = tipNadmetanjaRepository.getTipJavnogNadmetanjaById(tipNadmetanjaDto.tipJavnogNadmetanjaID);

				if(oldTipJn == null)
				{
					message.error = "Not found";
					loggerService.CreateMessage(message);
					return NotFound();
				}

				Entities.TipJavnogNadmetanja tipJavnogNadmetanja = mapper.Map<Entities.TipJavnogNadmetanja>(tipNadmetanjaDto);
				mapper.Map(tipJavnogNadmetanja, oldTipJn);
				tipNadmetanjaRepository.SaveChanges();
				message.information = "Tip nadmetanja je uspesno izmenjen";
				loggerService.CreateMessage(message);
				return Ok(mapper.Map<TipJavnogNadmetanjaConformationDto>(oldTipJn));
			}
			catch(Exception ex)
			{
				return (StatusCode(StatusCodes.Status500InternalServerError, "Put error"));
			}

		}

        /// <summary>
        /// Kreira novi tip nadmetanja
        /// </summary>
        /// <param name="tipNadmetanjaDto">Body koji sadzi tip nadmetanja koji treba da se kreira</param>
        /// <returns> Kreirani tip nadmetanja </returns>
        /// <response code="201">Kreiranje tipa nadmetanja je uspesno izvrseno</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipJavnogNadmetanjaConformationDto> postStatusNadmetanja([FromBody] TipNadmetanjaCreationDto tipNadmetanjaDto)
        {
            message.method = "POST";
            message.serviceName = naziv;
            try
            {
                Entities.TipJavnogNadmetanja tipNadmetanja = mapper.Map<Entities.TipJavnogNadmetanja>(tipNadmetanjaDto);
				TipJavnogNadmetanjaConformationDto idtip = tipNadmetanjaRepository.postTipJavnogNadmetanja(tipNadmetanja);
				//Entities.TipJavnogNadmetanja tip = tipNadmetanjaService.getTipJavnogNadmetanjaById(idtip.tipJavnogNadmetanjaID);
				//tipNadmetanjaService.SaveChanges();
				message.information = "Tip nadmetanja je uspesno izvrsen";
				loggerService.CreateMessage(message);
				tipNadmetanjaRepository.SaveChanges();
                return Created("uri",mapper.Map<TipJavnogNadmetanjaConformationDto>(idtip));

            }
            catch(Exception ex)
            {
				Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Post error");
            }
        }
    }
}

