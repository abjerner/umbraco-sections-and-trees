using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using SkriftDemo.Constants;
using SkriftDemo.Models.Pokemon;
using SkriftDemo.Trees.Actions;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace SkriftDemo.Controllers.Api {

    [Tree(SkriftConstants.SkriftSectionAlias, "pokemon", "Pokémon")]
    [PluginController("SkriftDemo")]
    public class SkriftPokemonTreeController : TreeController {
        
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings) {

            TreeNodeCollection nodes = new TreeNodeCollection();

            if (id == "-1") {

                // Get all types of Pokémon in our repository so we can group them
                foreach (string type in SkriftPokemonRepository.Current.GetAll().SelectMany(x => x.Type).Distinct()) {
                    
                    // Add a node/item for the group (the last parameter indicates that this node has children)
                    nodes.Add(CreateTreeNode(type, id, queryStrings, type, "icon-playing-cards", true));
                
                }

            } else if (id.Length < 36) {

                // Get all Pokémon of the requested type
                foreach (SkriftPokemon pokemon in SkriftPokemonRepository.Current.GetAll().Where(x => x.Type.Contains(id))) {

                    // Add a node/item for the Pokémon (red icon by default, green icon if envolved)
                    nodes.Add(CreateTreeNode(pokemon.Id, id, queryStrings, pokemon.Name, "icon-disc " + (pokemon.IsEvolved ? "color-green" : "color-red")));

                }

            }

            return nodes;

        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings) {

            MenuItemCollection collection = new MenuItemCollection();

            if (id.Length == 36) {

                // Get a reference to the Pokémon
                SkriftPokemon pokemon = SkriftPokemonRepository.Current.GetById(id);

                // Add a "Evolve" menu item if the Pokémon hasn't yet been evolved
                if (pokemon != null && pokemon.CanEnvolve) {
                    collection.Items.Add<SkriftPokemonEvolveAction>("Evolve");
                }
            
            } else {
                
                // Add a "Reload" menu item
                collection.Items.Add<RefreshNode, ActionRefresh>(Localize("actions/" + ActionRefresh.Instance.Alias));
            
            }

            return collection;

        }

        private string Localize(string key) {
            return ApplicationContext.Services.TextService.Localize(key, CultureInfo.CurrentCulture);
        }
    
    }

}