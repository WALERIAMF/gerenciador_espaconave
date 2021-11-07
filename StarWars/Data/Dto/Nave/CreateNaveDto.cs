namespace StarWars.Data.Dto.Nave
{
    public class CreateNaveDto
    {
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Passageiro { get; set; }
        public double Carga { get; set; }
        public string Classe { get; set; }
    }
}
