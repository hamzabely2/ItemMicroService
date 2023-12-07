using Model.DetailsItem;

namespace Service.Interface
{
    public interface ColorIService
    {
        void AddColors();
        Task<List<ColorDto>> GetAllColor();
        Task<ColorDto> CreateColor(ColorDto request);
        Task<ColorDto> DeleteColor(int ColorId);

    }

}
