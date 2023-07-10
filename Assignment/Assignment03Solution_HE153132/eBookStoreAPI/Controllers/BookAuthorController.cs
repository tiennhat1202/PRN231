using AutoMapper;
using BusinessObject.DTO.BookAuthorDTO;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Collections;

namespace eBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IMapper _mapper;
        public BookAuthorController(IBookAuthorRepository bookAuthorRepository, IMapper mapper)
        {
            _bookAuthorRepository = bookAuthorRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<BookAuthorDTO>> GetBookAuthors()
        {
            return Ok(_mapper.Map<IEnumerable<BookAuthorDTO>>(_bookAuthorRepository.Get().AsQueryable()));
        }
        [HttpPost]
        public IActionResult PostBookAuthor([FromBody] BookAuthorDTO bookAuthor)
        {
            _bookAuthorRepository.Add(_mapper.Map<BookAuthor>(bookAuthor));
            return Ok(bookAuthor);
        }
        [HttpPut]
        public IActionResult PutBookAuthor([FromBody] BookAuthorDTO bookAuthor)
        {
            _bookAuthorRepository.Update(_mapper.Map<BookAuthor>(bookAuthor));
            return Ok(bookAuthor);
        }
        [HttpDelete]
        public IActionResult DeleteBookAuthor([FromBody] BookAuthorDTO bookAuthor)
        {
            _bookAuthorRepository.Delete(_mapper.Map<BookAuthor>(bookAuthor));
            return Ok(bookAuthor);
        }
    }
}
