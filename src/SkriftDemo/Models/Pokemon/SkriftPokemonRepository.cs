using System.Collections.Generic;
using System.Linq;

namespace SkriftDemo.Models.Pokemon {
    
    public class SkriftPokemonRepository {

        public static readonly SkriftPokemonRepository Current = new SkriftPokemonRepository();

        private readonly List<SkriftPokemon> _pokemon = new List<SkriftPokemon>();

        public SkriftPokemonRepository() {
            _pokemon.Add(new SkriftPokemon("aa10b0bd-f968-4e3d-9628-268d2052274d", SkriftPokemonKind.Rattata));
            _pokemon.Add(new SkriftPokemon("f96a88a1-9d48-40ce-ad4d-fb0e5a12d047", SkriftPokemonKind.Rattata));
            _pokemon.Add(new SkriftPokemon("40a778c0-9251-4135-9b54-e34be2a8e7fa", SkriftPokemonKind.Rattata));
            _pokemon.Add(new SkriftPokemon("ab66834a-089c-4c16-9f20-17a339033f90", SkriftPokemonKind.Spearow));
            _pokemon.Add(new SkriftPokemon("2903399f-a251-4f32-8405-5bb40058ff88", SkriftPokemonKind.Goldeen));
            _pokemon.Add(new SkriftPokemon("2ed17f2e-b0ac-4a1b-88b0-c847edae293c", SkriftPokemonKind.Seel));
        }

        public SkriftPokemon[] GetAll() {
            return _pokemon.ToArray();
        }

        public SkriftPokemon GetById(string pokemonId) {
            return GetAll().FirstOrDefault(x => x.Id == pokemonId);
        }

    }

}