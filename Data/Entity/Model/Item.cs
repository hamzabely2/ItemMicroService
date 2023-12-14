using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Item
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public bool? Stock { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? CategoryId { get; set; }
        public int? ColorId { get; set; }
        public int? MaterialId { get; set; }
        public virtual Color? Colors { get; set; } = null!;
        public virtual Material? Materials { get; set; } = null!;
        public virtual Category? Categories { get; set; } = null!;
        public virtual ICollection<ImageItem> ImagesItems { get; set; } = new List<ImageItem>();

    }
}
