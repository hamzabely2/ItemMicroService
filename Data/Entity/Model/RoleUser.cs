using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class RoleUser
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User? Users { get; set; } = null!;
        public virtual Role? Roles { get; set; } = null!;

    }
}
