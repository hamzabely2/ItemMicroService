using Entity.Model;

namespace Repository.Interface
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorByName(string label);
    }
}
