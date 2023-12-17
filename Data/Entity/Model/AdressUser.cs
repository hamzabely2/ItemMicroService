using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class AdressUser
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public virtual Adress? Adress { get; set; } = null!;
        public virtual User? Users { get; set; } = null!;
    }
}
