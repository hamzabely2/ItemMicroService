using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class ImageRepository : GenericRepository<ImageItem>, IImageRepository
    {
        public ImageRepository(ItemMicroServiceIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<ImageItem>();
        }
        private readonly DbSet<ImageItem> _table;







    }
}
