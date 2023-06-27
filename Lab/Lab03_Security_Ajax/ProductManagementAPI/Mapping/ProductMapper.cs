using AutoMapper;
using BusinessObjects.DTO.ProductDTO;
using BusinessObjects.Models;

namespace ProductManagementAPI.Mapping
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<Product, ProductPostDTO>().ReverseMap();
            CreateMap<Product, ProductPutDTO>().ReverseMap();

        }
    }
}
