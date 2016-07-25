using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkriftDemo.Models.Pokemon;
using Umbraco.Web.WebApi;

namespace SkriftDemo.Controllers.Api {

    public class SkriftPokemonController : UmbracoAuthorizedApiController {

        [HttpGet]
        public object GetPokemon(string pokemonId) {

            SkriftPokemon pokemon = SkriftPokemonRepository.Current.GetById(pokemonId);

            if (pokemon == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Pokémon not found");

            return pokemon;
        
        }

        [HttpGet]
        public object Evolve(string pokemonId) {

            SkriftPokemon pokemon = SkriftPokemonRepository.Current.GetById(pokemonId);

            if (pokemon == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Pokémon not found");
            if (!pokemon.CanEnvolve) return Request.CreateResponse(HttpStatusCode.BadRequest);

            pokemon.Envolve();

            return pokemon;
        
        }

    }

}