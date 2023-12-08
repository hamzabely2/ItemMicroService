using Entity.Model;

namespace Repository.Interface
{
    public interface MaterialIRepository : GenericIRepository<Material>
    {
        Task<Material> GetMaterialByName(string label);

    }
}
