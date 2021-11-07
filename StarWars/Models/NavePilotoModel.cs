using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class NavePilotoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual NaveModel Nave { get; set; }
        public virtual PilotoModel Piloto { get; set; }
        public int IdNave { get; set; }
        public int IdPiloto { get; set; }
    }
}
