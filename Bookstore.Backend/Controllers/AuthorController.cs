using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Swashbuckle.AspNetCore.Annotations;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateNewAuthorModel author)
        {
            var newAuthor = _mapper.Map<Author>(author); // TODO how to map from typeID to List
            await _authorService.CreateNewAuthor(newAuthor);
            return Ok(); //TODO but what to do if exeption
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] AuthorDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            await _authorService.EditAuthor(newAuthor);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int authorId)
        {
            await _authorService.DeleteAuthor(authorId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetAll()
        {
           var result =  await _authorService.GetAllAuthors();

           if (result.Any())
           {
               return Ok(result);
           }

           return BadRequest(result); //TODO dont like
        }
    }
}
