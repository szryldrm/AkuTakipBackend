using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkuTakip.Business.Abstract;
using AkuTakip.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkuTakip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarantiDetayController : ControllerBase
    {
        private IGarantiDetayService _garantiDetayService;
        public GarantiDetayController(IGarantiDetayService garantiDetayService)
        {
            _garantiDetayService = garantiDetayService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _garantiDetayService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int garantiDetayId)
        {
            var result = _garantiDetayService.GetById(garantiDetayId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyplakawithdate")]
        public IActionResult GetByPlakaWithDate(string plaka, string date1, string date2)
        {
            var result = _garantiDetayService.GetByPlakaWithDate(plaka, date1, date2);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyplaka")]
        //[Authorize(Roles = "Garanti.Get")]
        public IActionResult GetByPlaka(string plaka)
        {
            var result = _garantiDetayService.GetByPlaka(plaka);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(GarantiDetay garantiDetay)
        {
            var result = _garantiDetayService.Add(garantiDetay);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(GarantiDetay garantiDetay)
        {
            var result = _garantiDetayService.Update(garantiDetay);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}