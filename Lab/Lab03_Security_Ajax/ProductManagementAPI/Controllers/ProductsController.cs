using AutoMapper;
using BusinessObjects.DTO.ProductDTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponseDTO>> GetProducts()
        {
            return Ok(_mapper.Map<IEnumerable<ProductResponseDTO>>(_productRepository.GetProducts()));
        }
        //POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductPostDTO product)
        {
            Product p = new Product()
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            };
            _productRepository.SaveProduct(p);
            return NoContent();
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductPutDTO product)
        {
            var productTmp = _productRepository.GetProductById(id);
            if(productTmp == null)
            {
                return NotFound();
            }
            Product p = new Product() {
                ProductId = id,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            };
            _productRepository.UpdateProduct(p);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(product);
            return NoContent();
        }
    }
}
