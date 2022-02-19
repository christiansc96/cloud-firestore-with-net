using cloud_firestore_with_net.Models;
using cloud_firestore_with_net.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cloud_firestore_with_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonRepository pokemonRepository;

        public PokemonController(PokemonRepository _pokemonRepository)
        {
            pokemonRepository = _pokemonRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetSpeaker(string id)
        {
            return Ok(pokemonRepository.Get(new Pokemon()
            {
                Id = id
            }));
        }
    }
}