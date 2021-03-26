using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }
        [HttpGet ("getall")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcolorid")]
        public IActionResult GetCarDtoColorId(int colorId )
        {
            var result = _carservice.GetCarDtoColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbrandId")]
        public IActionResult GetCarDtoBrandId(int brandId)
        {
            var result = _carservice.GetCarDtoBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet ("getallbycolorıd")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = _carservice.GetAllByColorId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getallbybrandıd")]
        public IActionResult GetAllByBrandId(int id)
        {
            var result = _carservice.GetAllByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(decimal min,decimal max)
        {
            var result = _carservice.GetByDailyPrice(min,max);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carservice.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetWithFilter")]
        public IActionResult GetWithFilter(int? brandId, int? colorId)
        {
            FilterDto filter = new FilterDto
            {
                BrandId = brandId,
                ColorId = colorId,
            };

            var result = _carservice.GetCarDetailsFatih(filter);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
