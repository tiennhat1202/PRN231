using BusinessObject;
using eStoreAPI.DTO.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<GetProductResponse>> GetProducts()
        {
            List<Product> products = productRepository.GetProducts();
            List<GetProductResponse> result = GetProductResponse.ToDTO(products);
            return Ok(result);
        }

        [HttpGet("Filter")]
        public ActionResult<IEnumerable<GetProductResponse>> GetProductsByFilter(string searchString)
        {
            List<Product> products = new List<Product>();
            products = productRepository.GetProductsByFilter(searchString);
            List<GetProductResponse> result = GetProductResponse.ToDTO(products);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<GetProductResponse> GetProductById(int id)
        {
            Product product = productRepository.GetProductById(id);
            GetProductResponse getProductResponse = new GetProductResponse(product);
            return Ok(getProductResponse);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] CreateProductRequest createProduct)
        {
            Product product = new Product()
            {
                ProductName = createProduct.ProductName,
                CategoryId = createProduct.CategoryId,
                UnitPrice = createProduct.UnitPrice,
                Weight = createProduct.Weight,
                UnitsInStock = createProduct.UnitsInStock,
            };
            productRepository.AddProduct(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductRequest updateProduct)
        {
            var found = productRepository.GetProductById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                Product p = new Product()
                {
                    ProductId = id,
                    CategoryId = updateProduct.CategoryId,
                    ProductName = updateProduct.ProductName,
                    UnitPrice = updateProduct.UnitPrice,
                    Weight = updateProduct.Weight,
                    UnitsInStock = updateProduct.UnitsInStock,
                };
                productRepository.UpdateProduct(p);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var found = productRepository.GetProductById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                productRepository.DeleteProduct(id);
                return NoContent();
            }
        }
    }
}
