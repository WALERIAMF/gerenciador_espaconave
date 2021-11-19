using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Dao
{
    public class PlanetaDao : DaoBase
    {
        public async Task InserirPlanetas(List<PlanetaModel> planetas)
         {
            if(!planetas.Any()) return;

            var check = "if (not existis(select 1 from Planetas where Id = {0}))\n";
            var insert = "insert Planetas (Id, Nome, Rotacao, Orbita, Clima, Populacao) values({0}, '{1}', {2}, {3}, {4}, '{5}', {6});\n";
            var comandos = planetas.Select(planeta => string.Format(check, planeta.Id) + string.Format(insert, 
                planeta.Id, 
                planeta.Nome, 
                planeta.Rotacao, 
                planeta.Orbita, 
                planeta.Clima, 
                planeta.Populacao));

         }

    }
}
