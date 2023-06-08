using BusinessObjects_;
using System.Text.Json.Serialization;

namespace ProductManagementWebClient.Models
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

        [JsonConstructor]
        public CategoryResponse(int categoryId, string categoryName)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
        }


        public static List<CategoryResponse> DTO(List<Category> categories)
        {
            List<CategoryResponse> categoryResponse = new List<CategoryResponse>();
            foreach (var item in categories)
            {
                categoryResponse.Add(new CategoryResponse(item));
            }
            return categoryResponse;
        }
    }
}
