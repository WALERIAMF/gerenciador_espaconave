using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StarWars.Service
{
    public class SincronizadorService
    {
        private const string URL_PLANETAS = "https://swapi.dev/api/planets/";
        private const string URL_NAVES = "https://swapi.dev/api/starships/";
        private const string URL_PILOTOS = "https://swapi.dev/api/people/";

        public Task Sincronizador()
        {
            var tasks = new List<Task>();

            tasks.Add(SincronizarPlanetas());
            tasks.Add(SincronizarNaves());

            Task.WhenAll(tasks);

            return SincronizarPilotos();
        }

        private async Task SincronizarPlanetas()
        {
            var httpClient = new HttpClient();
            var lista = new List<PlanetaViewModel>();
            ResultadoApi<PlanetaViewModel> resultadoApi = null;

            do
            {
                resultadoApi = await httpClient.GetFromJsonAsync<ResultadoApi<PlanetaViewModel>>(resultadoApi?.Next ?? URL_PLANETAS);
                lista.AddRange(resultadoApi.Next != null);
            } while (resultadoApi.Next != null);

                var planetas = lista.Select(item => new PlanetaModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Clima  = item.Clima,
                    Orbita = item.Orbita,
                    Rotacao = item.Populacao,
                    Populacao = item.Populacao
                }).ToList();
            using (var dao = PlanetaDao())
                await dao.InserirPlanetas(planetas);
            }


        }
    }
}
