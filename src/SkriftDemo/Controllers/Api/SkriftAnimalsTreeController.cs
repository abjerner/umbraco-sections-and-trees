using System.Net.Http.Formatting;
using SkriftDemo.Constants;
using SkriftDemo.Models.Animals;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace SkriftDemo.Controllers.Api {

    [Tree(SkriftConstants.SkriftSectionAlias, "animals", "Umbraco Animals")]
    [PluginController("SkriftDemo")]
    public class SkriftAnimalsTreeController : TreeController {
        
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings) {

            TreeNodeCollection nodes = new TreeNodeCollection();

            if (id == "-1") {
                foreach (SkriftAnimal animal in SkriftAnimalsRepository.Current.GetAll()) {
                    nodes.Add(CreateTreeNode(animal.Id + "", id, queryStrings, animal.Name, "icon-bird"));
                }
            }

            return nodes;

        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings) {
            
            return new MenuItemCollection();

        }
    
    }

}