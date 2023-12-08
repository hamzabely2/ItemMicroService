using Context.Interface;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public static class ItemData
    {
        public static void CreateItem(this ItemMicroServiceIDbContext idbContext)
        {
            var item1 = new Item
            {
                Id = 1,
                Name = "vase",
                Price = 30,
                Description = "description vase",
                CategoryId = 1,
                ColorId = 1,
                MaterialId = 1,
                Stock = true
            };
            var item2 = new Item
            {
                Id = 2,
                Name = "tagin",
                Price = 20,
                Description = "description tagin",
                CategoryId = 1,
                ColorId = 1,
                MaterialId = 1,
                Stock = true
            };
            idbContext.Items.AddRange(item1, item2);
            idbContext.SaveChanges();
        }
    }
}
