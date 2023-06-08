using BusinessObject;

namespace eStoreAPI.DTO.CategoryDTO
{
    public class GetCategoryResponse
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public GetCategoryResponse(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
        }
        public static List<GetCategoryResponse> ToDTO(List<Category> listCategories)
        {
            List<GetCategoryResponse> getCategories = new List<GetCategoryResponse>();
            foreach (var item in listCategories) getCategories.Add(new GetCategoryResponse(item));
            return getCategories;
        }
    }
}
