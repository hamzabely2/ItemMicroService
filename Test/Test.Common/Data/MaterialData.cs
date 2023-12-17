using Context.Interface;
using Entity.Model;

namespace Test.Common
{
    public static class MaterialData
    {
        public static void CreateMaterial(this ItemMicroServiceIDbContext idbContext)
        {
            var material1 = new Material
            {
                Id = 1,
                Label = "Argile rouge"
            };
            var material2 = new Material
            {
                Id = 2,
                Label = "Argile blanche"
            };
            idbContext.Materials.AddRange(material1, material2);
            idbContext.SaveChanges();
        }
    }
}
