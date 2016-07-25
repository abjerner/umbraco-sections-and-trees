using umbraco.interfaces;

namespace SkriftDemo.Trees.Actions {
    
    public class SkriftPokemonEvolveAction : IAction {

        public char Letter {
            get { return default(char); }
        }

        public bool ShowInNotifier {
            get { return false; }
        }

        public bool CanBePermissionAssigned {
            get { return false; }
        }

        public string Icon {
            get { return "fullscreen"; }
        }

        public string Alias {
            get { return "evolve"; }
        }

        public string JsFunctionName {
            get { return ""; }
        }

        public string JsSource {
            get { return ""; }
        }
    
    }

}