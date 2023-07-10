using AutoMapper;
using BusinessObject.DTO.BookDTO;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return Ok(_mapper.Map<IEnumerable<BookDTO>>(_bookRepository.Get()).AsQueryable());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_bookRepository.GetBookById(id));
        }
        [HttpPost]
        public IActionResult PostBook([FromBody] BookRequestDTO book)
        {
            _bookRepository.Add(_mapper.Map<Book>(book));
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] BookDTO book)
        {
            if(_bookRepository.GetBookById(id) == null)
            {
                return NotFound();
            }
            _bookRepository.Update(_mapper.Map<Book>(book));
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
