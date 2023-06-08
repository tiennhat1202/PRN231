using BusinessObject;
using eStoreAPI.DTO.CategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository categoryRepository = new CategoryRepository();

        [HttpGet]
        public ActionResult<IEnumerable<GetCategoryResponse>> GetMembers()
        {
            List<Category> members = categoryRepository.GetCategories();
            List<GetCategoryResponse> result = GetCategoryResponse.ToDTO(members);
            return Ok(result);
        }
    }
}
