
using Model.DetailsItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
