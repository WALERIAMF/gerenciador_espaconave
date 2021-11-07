namespace StarWars.Data.Dto.Planeta
{
    public class CreatePlanetaDto
    {
        public string Nome { get; set; }
        public double Rotacao { get; set; }
        public double Orbita { get; set; }
        public double Diametro { get; set; }
        public string Clima { get; set; }
        public long Populacao { get; set; }
    }
}
