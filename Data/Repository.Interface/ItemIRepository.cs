using Entity.Model;

namespace Repository.Interface
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        List<Item> GetItemsWithDetails();
        Task<Item> GetItemByName(string name);
    }
}
