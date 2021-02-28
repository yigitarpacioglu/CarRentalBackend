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

       
        [HttpPost("Add")]
        public IActionResult Add([FromForm]CarImage carImage, [FromForm] IFormFile image)
        {
                string key = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(image.FileName).ToLower();
                if (extension != ".jpeg" && extension != ".png")
                {
                    return BadRequest(CarImageMessages.MissmatchingFileExtension);
                }
                string uniqueName = key + extension;
                string basePath = _webHostEnvironment.WebRootPath + @"\\Assets\\";
                carImage.ImagePath = basePath + uniqueName;
                var result = _carImageService.AddService(carImage);
                

                if (result.Success)
                {
                    if (!Directory.Exists(basePath))
                    {
                        Directory.CreateDirectory(basePath);
                    }

                    using (FileStream fileStream = System.IO.File.Create(carImage.ImagePath))
                    {
                        image.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

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
