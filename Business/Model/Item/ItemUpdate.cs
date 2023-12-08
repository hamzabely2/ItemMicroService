using System.ComponentModel.DataAnnotations;

namespace Model.Item
{
    public class ItemUpdate
    {
        [Required(ErrorMessage = "Veuillez entrer un nom")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un desciption")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le prix")]
        public float? Price { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la disponibilité")]
        public bool? Stock { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un color")]
        public int? Color { get; set; }

        [Required(ErrorMessage = "Veuillez entrer le type de material")]
        public int? Material { get; set; }

        [Required(ErrorMessage = "Veuillez entrer la categoty")]
        public int? Category { get; set; }

        [Required(ErrorMessage = "Veuillez un image")]
        public string? FrontImage { get; set; }

        [Required(ErrorMessage = "Veuillez un image")]
        public string? FullImage { get; set; }

        [Required(ErrorMessage = "Veuillez un image")]
        public string? SideImage { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}
