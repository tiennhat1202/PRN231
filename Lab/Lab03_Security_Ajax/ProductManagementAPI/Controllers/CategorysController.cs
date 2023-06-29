using AutoMapper;
using BusinessObjects.DTO.CategoryDTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private ICategoryRepository  _categoryRepository;
        private IMapper _mapper;

        public CategorysController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseDTO>> GetCategorys()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryResponseDTO>>(_categoryRepository.GetCategories()));
        }
    }
}
