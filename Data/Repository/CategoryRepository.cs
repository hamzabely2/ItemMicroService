using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class CategoryRepository : GenericRepository<Category>, CategoryIRepository
    {
        public CategoryRepository(ItemMicroServiceIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Category>();
        }
        private readonly DbSet<Category> _table;
    

        /// get category by name   <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Category> GetCategoryByName(string label)
        {
            Category category = await _table.FirstOrDefaultAsync(x => x.Label == label).ConfigureAwait(false);

            return category;
        }
    }
}
