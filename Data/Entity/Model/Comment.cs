using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Item_Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
