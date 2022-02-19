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

        [HttpGet]
        public IActionResult GetPokemons()
        {
            return Ok(pokemonRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPokemon(string id)
        {
            Pokemon pokemonFromFirebase = pokemonRepository.Get(new Pokemon()
            {
                Id = id
            });

            if (pokemonFromFirebase == null)
                return NotFound();
            return Ok(pokemonFromFirebase);
        }

        [HttpPost]
        public IActionResult CreatePokemon(Pokemon pokemon)
        {
            Pokemon newPokemon = pokemonRepository.Add(pokemon);
            if (newPokemon == null)
                return BadRequest();
            return Ok(newPokemon);
        }

        [HttpPut]
        public IActionResult UpdatePokemon(Pokemon pokemon)
        {
            Pokemon pokemonFromFirebase = pokemonRepository.Get(new Pokemon()
            {
                Id = pokemon.Id
            });

            if (pokemonFromFirebase == null)
                return NotFound();

            if (pokemonRepository.Update(pokemon))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePokemon(string id)
        {
            if (pokemonRepository.Delete(new Pokemon()
            {
                Id = id
            }))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}