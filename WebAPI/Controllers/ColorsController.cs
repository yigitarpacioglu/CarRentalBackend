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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAllService();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.AddService(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.UpdateService(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.DeleteService(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
