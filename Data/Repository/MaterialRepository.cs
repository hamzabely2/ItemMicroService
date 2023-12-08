using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class MaterialRepository : GenericRepository<Material>, MaterialIRepository
    {
        public MaterialRepository(ItemMicroServiceIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Material>();
        }
        private readonly DbSet<Material> _table;


        /// get material by name   <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Material> GetMaterialByName(string label)
        {
            Material material = await _table.FirstOrDefaultAsync(x => x.Label == label).ConfigureAwait(false);

            return material;
        }

    }
}
