using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class Adress
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int? Code { get; set; } = 0!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<AdressUser> Adresses_Users { get; set; }
    }
}
