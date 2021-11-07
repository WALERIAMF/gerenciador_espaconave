using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StarWars.Models
{
    public class NaveModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Passageiro { get; set; }
        public double Carga { get; set; }
        public string Classe { get; set; }
        [JsonIgnore]
        public virtual PilotoModel Piloto { get; set; }

        [JsonIgnore]
        public virtual List<NavePilotoModel> NavePilotos { get; set; }

    }
}
