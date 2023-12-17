using Entity.Model;

namespace Repository.Interface
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByName(string label);
    }
}
