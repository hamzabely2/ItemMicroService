
using Context.Interface;
using Entity.Model;

namespace Test.Common
{
    public static class ColorData
    {
        public static void CreateColors(this ItemMicroServiceIDbContext idbContext)
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
        public static void CreateColor(this ItemMicroServiceIDbContext idbContext)
        {
            var color1 = new Color
            {
                Id = 3,
                Label = "red"
            };
         
            idbContext.Colors.AddRange(color1);
            idbContext.SaveChanges();
        }
    }
}
