using Entity.Model;

namespace Repository.Interface
{
    public interface ItemIRepository : GenericIRepository<Item>
    {
        List<Item> GetItemsWithDetails();
        Task<Item> GetItemByName(string name);
    }
}
