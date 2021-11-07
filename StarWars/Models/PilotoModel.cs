using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StarWars.Models
{
    public class PilotoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public DateTime AnoNascimento { get; set; }
        [JsonIgnore]
        public virtual List<NaveModel> Naves {get; set;}
        [JsonIgnore]
        public virtual List<PlanetaModel> Planetas { get; set; }
        [JsonIgnore]
        public virtual List<NavePilotoModel> NavePilotos { get; set; }
        [JsonIgnore]
        public virtual List<PilotoPlanetaModel> PilotoPlanetas { get; set; }

    }
}
