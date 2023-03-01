using FluentValidationExample.Entities;

namespace FluentValidationExample.Services {
  public class StuffService : IStuffService {
    private readonly List<Stuff> listOfStuff;

    public StuffService() {
      listOfStuff = new List<Stuff>();
    }

    public List<Stuff> GetAllTheStuff() {
      return listOfStuff;
    }

    public Stuff? GetStuffById(Guid id) {
      var singlestuff = listOfStuff.SingleOrDefault(x => x.Id.Equals(id));
      return singlestuff;
    }

    public bool AddStuff(Stuff stuff) {
      listOfStuff.Add(stuff);
      return true;
    }

    public bool RemoveStuff(Guid id) {
      var result = listOfStuff.Remove(listOfStuff.Single(x => x.Id.Equals(id)));
      return result;
    }

  }
}
