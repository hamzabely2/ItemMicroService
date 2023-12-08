
using Model.DetailsItem;

namespace Service.Interface
{
    public interface CategoryIService
    {
        void AddCategories();
        Task<List<CategoryDto>> GetAllCategory();
        Task<CategoryDto> CreateCategory(CategoryDto request);
        Task<CategoryDto> DeleteCategory(int CategoryId);
    }
}
