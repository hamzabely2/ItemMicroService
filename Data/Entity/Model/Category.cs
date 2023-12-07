using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public partial class Category
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public virtual ICollection<Item>? Items { get; set; }
    }
}
