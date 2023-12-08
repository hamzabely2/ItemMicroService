using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<AdressUser> Adresses_Users { get; set; }
        public virtual ICollection<RoleUser> Roles_Users { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
