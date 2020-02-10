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
    public class MarkaController : ControllerBase
    {
        private IMarkaService _markaService;
        public MarkaController(IMarkaService markaService)
        {
            _markaService = markaService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _markaService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int markaId)
        {
            var result = _markaService.GetById(markaId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Marka marka)
        {
            var result = _markaService.Add(marka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Marka marka)
        {
            var result = _markaService.Update(marka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Marka marka)
        {
            var result = _markaService.Delete(marka);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}