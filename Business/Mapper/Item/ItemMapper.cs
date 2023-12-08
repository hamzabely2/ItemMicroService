
using Entity.Model;
using Model.DetailsItem;
using Model.Item;

namespace Mapper.Item
{
    public class ItemMapper
    {
        public static Entity.Model.Item TransformDtoAdd(ItemAdd item)
        {
            return new Entity.Model.Item()
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Stock = item.Stock,
                CategoryId = item.Category,
                ColorId = item.Color,
                MaterialId = item.Material,
                ImagesItems = new List<ImageItem>
                 {
                    new ImageItem
                    {
                        Images = new Image { FrontImage = item.FrontImage, FullImage = item.FullImage, SideImage = item.SideImage }
                    }
                 },
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
        }


        public static ItemDetailsDto TransformDtoExitWithDetails(Entity.Model.Item item)
        {
            if (item == null)
            {
                return null;
            }
            return new ItemDetailsDto
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Stock = item.Stock,
                Categories = new CategoryDto
                {
                    Label = item.Categories?.Label ?? "N/A"
                },
                Colors = new ColorDto
                {
                    Label = item.Colors?.Label ?? "N/A"
                },
                Materials = new MaterialDto
                {
                    Label = item.Materials?.Label ?? "N/A"
                },
                Images = item.ImagesItems?.Select(imageItem => new ImageDto
                {
                    FrontImage = imageItem.Images?.FrontImage ?? "N/A",
                    FullImage = imageItem.Images?.FullImage ?? "N/A",
                    SideImage = imageItem.Images?.SideImage ?? "N/A"
                }).ToList() ?? new List<ImageDto>()


            };
        }

        public static Entity.Model.Item TransformDtoUpdate(ItemUpdate request, Entity.Model.Item uniteGet, Image image)
        {

            uniteGet.Name = request.Name;
            uniteGet.Description = request.Description;
            uniteGet.Price = request.Price;
            uniteGet.Stock = request.Stock;
            uniteGet.MaterialId = request.Material;
            uniteGet.ColorId = request.Color;
            uniteGet.CategoryId = request.Category;
            uniteGet.UpdateDate = DateTime.Now;
            image.FrontImage = request.FrontImage;
            image.FullImage = request.FullImage;
            image.SideImage = request.SideImage;
            return uniteGet;

        }
    }
}
