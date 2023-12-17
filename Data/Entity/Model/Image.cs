using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Image
    {
        [Key]
        public int? Id { get; set; }
        public string? FrontImage { get; set; }
        public string? FullImage { get; set; }
        public string? SideImage { get; set; }
        public virtual ICollection<ImageItem> ImagesItems { get; set; } = new List<ImageItem>();


    }
}
