using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StarWars.Models
{
    public class PlanetaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public double Rotacao { get; set; }
        public double Orbita { get; set; }
        public double Diametro { get; set; }
        public string Clima { get; set; }
        public long Populacao { get; set; }
        [JsonIgnore]
        public virtual PilotoModel Piloto { get; set; }
        [JsonIgnore]
        public virtual List<PilotoPlanetaModel> PilotoPlanetas { get; set; }
    }
}
