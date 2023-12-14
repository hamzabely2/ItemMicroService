using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ItemMicroServiceIDbContext _idbcontext) : base(_idbcontext)
        {
            _table = _idbcontext.Set<Item>();
        }
        private readonly DbSet<Item> _table;


        /// get by name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Item> GetItemByName(string name)
        {
            Item item = await _table.FirstOrDefaultAsync(x => x.Name == name).ConfigureAwait(false);

            return item;
        }

        /// get b name   <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<Item> GetItemsWithDetails()
        {
            return _table
                .Include(i => i.Colors)
                .Include(i => i.Categories)
                .Include(i => i.Materials)
                .Include(i => i.ImagesItems)
                    .ThenInclude(ii => ii.Images).ToList();
        }


    }
}
