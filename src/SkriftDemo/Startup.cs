using SkriftDemo.Constants;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace SkriftDemo {
    
    public class Startup : ApplicationEventHandler {
        
        protected override void ApplicationStarted(UmbracoApplicationBase umbraco, ApplicationContext context) {
            
            // Gets a reference to the section (if already added)
            Section section = context.Services.SectionService.GetByAlias(SkriftConstants.SkriftSectionAlias);
            if (section != null) return;

            // Add a new "Skrift Demo" section
            context.Services.SectionService.MakeNew("Skrift Demo", SkriftConstants.SkriftSectionAlias, "icon-newspaper");

            // Grant all existing users access to the new section
            context.Services.UserService.AddSectionToAllUsers(SkriftConstants.SkriftSectionAlias);

        }
    
    }

}