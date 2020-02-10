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
    public class AkuOzellikController : ControllerBase
    {
        private IAkuOzellikService _akuOzellikService;
        public AkuOzellikController(IAkuOzellikService akuOzellikService)
        {
            _akuOzellikService = akuOzellikService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _akuOzellikService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int akuOzellikId)
        {
            var result = _akuOzellikService.GetById(akuOzellikId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(AkuOzellik akuOzellik)
        {
            var result = _akuOzellikService.Add(akuOzellik);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(AkuOzellik akuOzellik)
        {
            var result = _akuOzellikService.Update(akuOzellik);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(AkuOzellik akuOzellik)
        {
            var result = _akuOzellikService.Delete(akuOzellik);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}