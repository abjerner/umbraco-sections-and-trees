using Newtonsoft.Json;

namespace SkriftDemo.Models.Pokemon {
    
    public class SkriftPokemon {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string[] Type { get; set; }

        [JsonIgnore]
        public SkriftPokemonKind Kind { get; set; }

        [JsonProperty("kind")]
        protected string KindStr {
            get { return Kind + ""; }
        }

        [JsonProperty("isEvolved")]
        public bool IsEvolved {
            get { return !CanEnvolve; }
        }

        [JsonProperty("canEvolve")]
        public bool CanEnvolve {
            get {
                return (
                    Kind == SkriftPokemonKind.Rattata
                    ||
                    Kind == SkriftPokemonKind.Spearow
                    ||
                    Kind == SkriftPokemonKind.Goldeen
                    ||
                    Kind == SkriftPokemonKind.Seel
                );
            }
        }

        public SkriftPokemon(string id, SkriftPokemonKind kind) {
            Id = id;
            Name = kind + "";
            Kind = kind;
            Type = GetTypes(kind);
        }

        public void Envolve() {

            switch (Kind) {
                case SkriftPokemonKind.Rattata:
                    Kind = SkriftPokemonKind.Raticate;
                    if (Name == SkriftPokemonKind.Rattata + "") Name = SkriftPokemonKind.Raticate + "";
                    Type = GetTypes(Kind);
                    break;
                case SkriftPokemonKind.Spearow:
                    Kind = SkriftPokemonKind.Fearow;
                    if (Name == SkriftPokemonKind.Spearow + "") Name = SkriftPokemonKind.Fearow + "";
                    Type = GetTypes(Kind);
                    break;
                case SkriftPokemonKind.Goldeen:
                    Kind = SkriftPokemonKind.Seaking;
                    if (Name == SkriftPokemonKind.Goldeen + "") Name = SkriftPokemonKind.Seaking + "";
                    Type = GetTypes(Kind);
                    break;
                case SkriftPokemonKind.Seel:
                    Kind = SkriftPokemonKind.Dewgong;
                    if (Name == SkriftPokemonKind.Seel + "") Name = SkriftPokemonKind.Dewgong + "";
                    Type = GetTypes(Kind);
                    break;
            }

        }

        private string[] GetTypes(SkriftPokemonKind kind) {

            switch (kind) {

                case SkriftPokemonKind.Rattata:
                case SkriftPokemonKind.Raticate:
                    return new[] { "Normal" };

                case SkriftPokemonKind.Spearow:
                case SkriftPokemonKind.Fearow:
                    return new[] { "Normal", "Flying" };

                case SkriftPokemonKind.Goldeen:
                case SkriftPokemonKind.Seaking:
                case SkriftPokemonKind.Seel:
                    return new[] { "Water" };

                case SkriftPokemonKind.Dewgong:
                    return new[] { "Water", "Ice"};

                default:
                    return new[] { "Unknown" };

            }

        }

    }

}