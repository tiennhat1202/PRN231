using BusinessObjects_;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTO;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = repository.GetCategories();
            List<CategoryResponse> categoryResponses = CategoryResponse.DTO(categories);
            return Ok(categoryResponses);
        }
    }
}
