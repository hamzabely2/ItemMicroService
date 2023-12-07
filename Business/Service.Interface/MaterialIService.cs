using Model.DetailsItem;

namespace Service.Interface
{
    public interface MaterialIService
    {
        void AddMaterials();
        Task<List<MaterialDto>> GetAllMaterial();
        Task<MaterialDto> CreateMaterial(MaterialDto request);
        Task<MaterialDto> DeleteMaterial(int materialId);
    }
}
