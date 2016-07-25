using System.Linq;

namespace SkriftDemo.Models.Animals {

    public class SkriftAnimalsRepository {

        public static readonly SkriftAnimalsRepository Current = new SkriftAnimalsRepository();

        public SkriftAnimal[] GetAll() {

            SkriftAnimal rabbit = new SkriftAnimal {
                Id = 1,
                Name = "Umbraco Rabbit",
                Status = "Alive",
                LastSeen = "Bingo Night at Codegarden 2016",
                Twitter = "UmbracoRabbit",
                Image = "https://pbs.twimg.com/profile_images/609085815382257664/UUPv1wXD_400x400.jpg"
            };

            SkriftAnimal giraffe = new SkriftAnimal {
                Id = 2,
                Name = "Umbraco Giraffe",
                Status = "Killed in action (unconfirmed)",
                LastSeen = "Bingo Night at Codegarden 2016",
                Twitter = "UmbracoGiraffe",
                Image = "https://pbs.twimg.com/profile_images/739882256429387776/lKscySOa_400x400.jpg"
            };

            return new [] { rabbit, giraffe };
        
        }

        public SkriftAnimal GetById(int animalId) {
            return GetAll().FirstOrDefault(x => x.Id == animalId);
        }
    
    }

}