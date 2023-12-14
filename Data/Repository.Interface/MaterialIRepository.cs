using Entity.Model;

namespace Repository.Interface
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<Material> GetMaterialByName(string label);

    }
}
