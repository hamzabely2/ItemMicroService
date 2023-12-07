using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
