using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.ModelsDTO;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {
        private IBookImageService _bookImageService;
        private IMapper _mapper;

        public BookImageController(IBookImageService bookImageService, IMapper mapper)
        {
            _bookImageService = bookImageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddImageToBook([FromBody]List<BookImageDTO> images, int bookId)
        {
            throw new Exception();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteImage( int imageId)
        {


            throw new Exception();
        }
    }
}
