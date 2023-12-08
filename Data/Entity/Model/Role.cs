using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<RoleUser> Roles_Users { get; set; }

    }
}
