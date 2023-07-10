using AutoMapper;
using BusinessObject.DTO.PublisherDTO;
using BusinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<PublisherDTO>> GetPublishers()
        {
            return Ok(_mapper.Map<IEnumerable<PublisherDTO>>(_publisherRepository.Get().AsQueryable()));
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            return Ok(_publisherRepository.GetPublisherById(id));
        }

        [HttpPost]
        public IActionResult PostPublisher([FromBody] PublisherRequestDTO publisher)
        {
            _publisherRepository.Add(_mapper.Map<Publisher>(publisher));
            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public IActionResult PutPublisher(int id, [FromBody] PublisherDTO publisher)
        {
            if(_publisherRepository.GetPublisherById(id) == null)
            {
                return NotFound();
            }
            _publisherRepository.Update(_mapper.Map<Publisher>(publisher));
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherRepository.Delete(id);
            return Ok();
        }
    }
}
