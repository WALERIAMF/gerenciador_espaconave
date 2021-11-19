using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.ViewModel
{
    public class PlanetaViewModel
    {
        public string Nome { get; set; }
        public string Rotation_Period { get; set; }
        public string Orbital_Period { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Population { get; set; }
        public string Url { get; set; }

        public double Rotacao
        {
            get
            {
                double.TryParse(Rotation_Period, out var retorno);
                return retorno;
            }
        }

        public double Orbita
        {
            get
            {
                double.TryParse(Orbital_Period, out var retorno);
                return retorno;
            }
        }

        public double Diametro
        {
            get
            {
                double.TryParse(Diameter, out var retorno);
                return retorno;
            }
        }

        public double Clima
        {
            get
            {
                double.TryParse(Climate, out var retorno);
                return retorno;
            }
        }

        public double Populacao
        {
            get
            {
                long.TryParse(Population, out var retorno);
                return retorno;
            }
        }
    }

}
