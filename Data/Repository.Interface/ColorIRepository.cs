using Entity.Model;

namespace Repository.Interface
{
    public interface ColorIRepository : GenericIRepository<Color>
    {
        Task<Color> GetColorByName(string label);
    }
}
