

using Entity.Model;
using Model.DetailsItem;

namespace Mapper.DetailsItem
{
    public class DatailsItemMapper
    {
        /// <summary>
        /// DTO for color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ColorDto TransformExiteColor(Color color)
        {
            return new ColorDto
            {
                Label = color.Label,
            };
        }
        public static Color TransformCreateColor(ColorDto request)
        {
            return new Color
            {
                Label = request.Label,
            };
        }

        /// <summary>
        /// DTO fot category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryDto TransformExiteCategory(Category category)
        {
            return new CategoryDto
            {
                Label = category.Label,
            };
        }
        public static Category TransformCreateCategory(CategoryDto request)
        {
            return new Category
            {
                Label = request.Label,
            };
        }

        /// <summary>
        /// DTO fot material
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static MaterialDto TransformExiteMaterial(Material material)
        {
            return new MaterialDto
            {
                Label = material.Label,
            };
        }
        public static Material TransformCreateMaterial(MaterialDto request)
        {
            return new Material
            {
                Label = request.Label,
            };
        }
    }
}
