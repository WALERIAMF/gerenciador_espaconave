using System.Collections.Generic;

namespace StarWars_WinFormsApp.ViewModel
{
    public class ResultadoApi<ViewModel>
    {
        public string Next { get; set; }
        public IReadOnlyList<ViewModel> Results { get; set; }
    }
}
