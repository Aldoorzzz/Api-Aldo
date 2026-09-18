using Api_Aldo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Api_Aldo.Controllers
{
    public class EpisodesViewController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7154/");

                var episodes = await client.GetFromJsonAsync<List<Episode>>("api/episodes");

                return View(episodes);
            }
        }
    }
}
