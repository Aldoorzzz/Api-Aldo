using Api_Aldo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Aldo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly EpisodeService _episodeService;

        public EpisodesController(EpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisode(int id)
        {
            var episode = await _episodeService.GetEpisode(id);

            if (episode == null)
            {
                return NotFound(new
                {
                    message = "El episodio no existe."
                });
            }

            return Ok(episode);
        }
    }
}
