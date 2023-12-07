using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ItemIRepository : GenericIRepository<Item>
    {
       List<Item> GetItemsWithDetails();
       Task<Item> GetItemByName(string name);
    }
}
