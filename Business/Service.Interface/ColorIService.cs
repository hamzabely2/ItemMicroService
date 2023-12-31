﻿using Model.DetailsItem;

namespace Service.Interface
{
    public interface IColorService
    {
        void AddColors();
        Task<List<ColorDto>> GetAllColor();
        Task<ColorDto> CreateColor(ColorDto request);
        Task<ColorDto> DeleteColor(int ColorId);

    }

}
