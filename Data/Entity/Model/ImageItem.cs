using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class ImageItem
    {
        [Key]
        public int? Id { get; set; }
        public int? ImageId { get; set; }
        public int? ItemId { get; set; }
        public virtual Item? Items { get; set; } = null!;
        public virtual Image? Images { get; set; } = null!;

    }
}
