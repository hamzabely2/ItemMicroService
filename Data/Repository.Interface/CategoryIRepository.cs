using Entity.Model;

namespace Repository.Interface
{
    public interface CategoryIRepository : GenericIRepository<Category>
    {
        Task<Category> GetCategoryByName(string label);
    }
}
