using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Material
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public virtual ICollection<Item>? Items { get; set; }
    }
}
