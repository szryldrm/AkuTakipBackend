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
    public class AmperController : ControllerBase
    {
        private IAmperService _amperService;
        public AmperController(IAmperService amperService)
        {
            _amperService = amperService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _amperService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int amperId)
        {
            var result = _amperService.GetById(amperId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Amper amper)
        {
            var result = _amperService.Add(amper);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Amper amper)
        {
            var result = _amperService.Update(amper);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}