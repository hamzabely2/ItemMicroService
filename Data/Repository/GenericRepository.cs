using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class GenericRepository<T> : GenericIRepository<T> where T : class
    {
        protected readonly ItemMicroServiceIDbContext _idbcontext;
        private readonly DbSet<T> _table;
        public GenericRepository(ItemMicroServiceIDbContext idbcontext)
        {
            _idbcontext = idbcontext;
            _table = _idbcontext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetByKeys(int id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }
        public async Task<T> CreateElementAsync(T element)
        {
            var elementAdded = await _table.AddAsync(element).ConfigureAwait(false);
            await _idbcontext.SaveChangesAsync().ConfigureAwait(false);
            return elementAdded.Entity;
        }
        public async Task<T> UpdateElementAsync(T element)

        {
            var elementUpdated = _table.Update(element);
            await _idbcontext.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<T> DeleteElementAsync(T element)
        {
            var elementDeleted = _table.Remove(element);
            await _idbcontext.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;
        }
    }
}
