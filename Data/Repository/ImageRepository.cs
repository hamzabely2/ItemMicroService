using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImageRepository : GenericRepository<ImageItem>, ImageIRepository
    {
        public ImageRepository(ItemMicroServiceIDbContext idbcontext) : base(idbcontext)
        {
            _table = _idbcontext.Set<ImageItem>();
        }
        private readonly DbSet<ImageItem> _table;




     

        
    }
}
