using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class PilotoPlanetaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual PilotoModel Nave { get; set; }
        public virtual PlanetaModel Piloto { get; set; }
        public int IdPiloto { get; set; }
        public int IdPlaneta { get; set; }
    }
}
