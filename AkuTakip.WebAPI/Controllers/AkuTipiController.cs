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
    public class AkuTipiController : ControllerBase
    {
        private readonly IAkuTipiService _akuTipiService;
        public AkuTipiController(IAkuTipiService akuTipiService)
        {
            _akuTipiService = akuTipiService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _akuTipiService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int akuTipiId)
        {
            var result = _akuTipiService.GetById(akuTipiId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(AkuTipi akuTipi)
        {
            var result = _akuTipiService.Add(akuTipi);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(AkuTipi akuTipi)
        {
            var result = _akuTipiService.Update(akuTipi);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}