using AutoMapper;
using BusinessObjects.DTO.CategoryDTO;
using BusinessObjects.DTO.ProductDTO;
using BusinessObjects.Models;

namespace ProductManagementAPI.Mapping
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();
        }
    }
}