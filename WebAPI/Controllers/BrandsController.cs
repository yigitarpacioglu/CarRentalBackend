using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReCapProject.Business.Abstract;
using ReCapProject.Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAllService();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.AddService(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.UpdateService(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.DeleteService(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
