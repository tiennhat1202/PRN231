using AutoMapper;
using BusinessObject.DTO.AuthorDTO;
using BusinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Collections;

namespace eBookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()
        {
            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(_authorRepository.Get()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorRepository.GetAuthorById(id));
        }

        [HttpPost]
        public IActionResult PostAuthor([FromBody] AuthorRequestDTO author)
        {
            _authorRepository.Add(_mapper.Map<Author>(author));
            return Ok(author);
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, [FromBody] AuthorDTO author)
        {
            if(_authorRepository.GetAuthorById(id) == null)
            {
                return NotFound();
            }
            _authorRepository.Update(_mapper.Map<Author>(author));
            return Ok(author);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
            return Ok();
        }
    }
}
