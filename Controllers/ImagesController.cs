using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Models;

namespace UploadImage.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ImagesController(ApplicationDbContext context)
        {
            _context = context ?? throw new Exception();
        }

        [HttpGet]
        public async Task<ICollection<Image>> Get()
        {
            return _context.Images.ToList();
        }
        [HttpPost("upload/{id}")]
        public async Task<IActionResult> Upload(List<IFormFile> files, int id)
        {
            try
            {
                var result = new List<Image>();
                foreach (var file in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    _context.Images.Add(new Image() { ImageName = file.FileName, IdStadium = id });
                    await _context.SaveChangesAsync();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}