
using Model.DetailsItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Item
{
    public class ItemDetailsDto
    {
        public string Name { get; set; } = null!;
        public float? Price { get; set; }
        public bool? Stock { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        // Propriétés de détails
        public CategoryDto Categories { get; set; }
        public ColorDto Colors { get; set; }
        public MaterialDto Materials { get; set; }

        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
