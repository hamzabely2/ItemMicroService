using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(ItemMicroServiceIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<Color>();
        }
        private readonly DbSet<Color> _table;


        /// get color by name   <summary>
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Color> GetColorByName(string label)
        {
            Color color = await _table.FirstOrDefaultAsync(x => x.Label == label).ConfigureAwait(false);

            return color;
        }
    }
}
