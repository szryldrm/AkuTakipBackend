using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkuTakip.Business.Abstract;
using AkuTakip.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkuTakip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlakaController : ControllerBase
    {
        private IPlakaService _plakaService;
        public PlakaController(IPlakaService plakaService)
        {
            _plakaService = plakaService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _plakaService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int plakaId)
        {
            var result = _plakaService.GetById(plakaId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Plaka plaka)
        {
            var result = _plakaService.Add(plaka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Plaka plaka)
        {
            var result = _plakaService.Update(plaka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Plaka plaka)
        {
            var result = _plakaService.Delete(plaka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}