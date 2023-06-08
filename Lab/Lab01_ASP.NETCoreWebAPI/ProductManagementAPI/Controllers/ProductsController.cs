using BusinessObjects_;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTO;
using Repositories;


namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        // GET:api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductRepository>> GetProducts()
        {
            List<Product> productList = repository.GetProducts();
            List<ProductResponse> productDTO = ProductResponse.DTO(productList);
            return Ok(productDTO);
        }

        //GET:api/Products/id
        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProductById(int id)
        {
            Product product = repository.GetProductById(id);
            ProductResponse productResponse = new ProductResponse(product);

            return Ok(productResponse);
        }

        //POST: api/Products
        [HttpPost]
        public IActionResult PostProduct([FromBody] PostProductRequest product) {
            Product product1 = new Product()
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };
            repository.SaveProduct(product1);
            return NoContent();
        }

        //PUT: api/Products/id
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, PostProductRequest product)
        {
            var productTmp = repository.GetProductById(id);
            if(productTmp == null)
            {
                return NotFound();
            }
            Product product1 = new Product()
            {
                ProductId = id,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };
            repository.UpdateProduct(product1);
            return NoContent();
        }

        //Delete: api/Products/id
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();

            }
            repository.DeleteProduct(product);
            return NoContent();
        }
    }
}
