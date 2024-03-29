﻿using AutoMapper;
using AdresaService.Repositories;
using AdresaService.Services;
using AdresaService.Entities;
using AdresaService.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/drzava")]
    [Produces("application/json", "application/xml")]

    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaRepository drzavaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        public DrzavaController(IDrzavaRepository drzavaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.drzavaRepository = drzavaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DrzavaDto>> GetDrzavaList()
        {
            var drzave = drzavaRepository.GetDrzavaList();


            if (drzave == null || drzave.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<DrzavaDto>>(drzave));
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{drzavaId}")]
        public ActionResult<DrzavaDto> GetDrzavaById(Guid drzavaId) //Na ovaj parametar će se mapirati ono što je prosleđeno u ruti
        {
            var drzava = drzavaRepository.GetDrzavaById(drzavaId);

            if (drzava == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DrzavaDto>(drzava));
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<DrzavaDto> CreateDrzava([FromBody] DrzavaDto drzava)
        {
            try
            {

                Drzava d = mapper.Map<Drzava>(drzava);
                Drzava drzava1 = drzavaRepository.CreateDrzava(d);

                string location = linkGenerator.GetPathByAction("GetDrzavaList", "Drzava", new { drzavaId = drzava1.DrzavaId });
                return Created(location, mapper.Map<DrzavaDto>(drzava1));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{drzavaId}")]
        public IActionResult DeleteDrzava(Guid drzavaId)
        {
            try
            {
                Drzava drzava = drzavaRepository.GetDrzavaById(drzavaId);
                if (drzava == null)
                {
                    return NotFound();
                }

                drzavaRepository.DeleteDrzava(drzavaId);
                drzavaRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska prilikom brisanja drzave!");
            }
        }

        [HttpPut]
        [Produces("application/json")]
        public ActionResult<DrzavaDto> UpdateDrzava(Drzava drzava)
        {
            try
            {
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                var oldDrzava = drzavaRepository.GetDrzavaById(drzava.DrzavaId);
                if (oldDrzava == null)
                {
                    return NotFound();
                }
                Drzava d = mapper.Map<Drzava>(drzava);

                mapper.Map(d, oldDrzava); //Update objekta koji treba da sačuvamo u bazi                

                drzavaRepository.SaveChanges(); //Perzistiramo promene
                return Ok(mapper.Map<DrzavaDto>(d));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpOptions]
        public IActionResult GetDrzavaOptions()
        {
            Response.Headers.Add("Allow", "GET, HEAD, POST, PUT, DELETE");
            return Ok();
        }

    }
}