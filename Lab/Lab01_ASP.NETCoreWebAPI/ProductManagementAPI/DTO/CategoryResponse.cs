using BusinessObjects_;

namespace ProductManagementAPI.DTO
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryResponse(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.CategoryName = category.CategoryName;
        }

        public static List<CategoryResponse> DTO(List<Category> categories) { 
            List<CategoryResponse> categoryResponse = new List<CategoryResponse>();
            foreach (var item in categories)
            {
                categoryResponse.Add(new CategoryResponse(item));
            }
            return categoryResponse;
        }
    }
}
