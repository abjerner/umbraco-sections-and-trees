using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkriftDemo.Models.Animals;
using Umbraco.Web.WebApi;

namespace SkriftDemo.Controllers.Api {
    
    public class SkriftAnimalsController : UmbracoAuthorizedApiController {

        [HttpGet]
        public object GetAnimal(int animalId) {

            SkriftAnimal animal = SkriftAnimalsRepository.Current.GetById(animalId);

            if (animal == null) return Request.CreateResponse(HttpStatusCode.NotFound);

            return animal;

        }

    }

}