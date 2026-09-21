using Microsoft.AspNetCore.Mvc;
using RickMortyWeb.Models;

namespace RickMortyWeb.Controllers
{
    public class EpisodesController : Controller
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
