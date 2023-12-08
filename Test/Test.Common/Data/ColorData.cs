
using Context.Interface;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common
{
    public static class ColorData
    {
        public static void CreateColor(this ItemMicroServiceIDbContext idbContext)
        {
            var color1 = new Color
            {
                Id = 1,
                Label = "red"
            };
            var color2 = new Color
            {
                Id = 2,
                Label = "green"
            };
            idbContext.Colors.AddRange(color1, color2);
            idbContext.SaveChanges();
        }
    }
}
