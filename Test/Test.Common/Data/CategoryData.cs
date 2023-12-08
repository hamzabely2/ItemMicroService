
using Context.Interface;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public static class CategoryData
    {
        public static void CreateCategory(this ItemMicroServiceIDbContext idbContext)
        {
            var category1 = new Category
            {
                Id = 1,
                Label = "Tagine",
               
            };
            var category2 = new Category
            {
                Id = 2,
                Label = "Pot de conservation"
            };
            idbContext.Categories.AddRange(category1, category2);
            idbContext.SaveChanges();
        }
    }
}
