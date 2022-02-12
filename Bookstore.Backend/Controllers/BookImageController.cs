using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private readonly IBookImageService _bookImageService;
        private IWebHostEnvironment _webHostEnvironment { get; set; }

        public BookImageController(IBookImageService bookImageService,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookImageService = bookImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost] //TODO not work iFormFile
        public async Task<ActionResult> AddImageToBook([FromBody] List<IFormFile> images, int bookId)
        {
            var rootPath = _webHostEnvironment.WebRootPath;
            _bookImageService.AddNewImageToExistBookAsync(images, bookId, rootPath);
            return Ok();
        }

        [HttpDelete("{imageId}")]
        public async Task<ActionResult> DeleteImage(int imageId)
        {
            await _bookImageService.DeleteImageAsync(imageId);
            return Ok();
        }
    }
}
