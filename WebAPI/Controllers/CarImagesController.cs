using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Entities.Concrete;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        public static IWebHostEnvironment _webHostEnvironment; 

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost("add")]
        public IActionResult AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAllService();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("GetAllByCarId")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.UpdateService(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.DeleteService(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
