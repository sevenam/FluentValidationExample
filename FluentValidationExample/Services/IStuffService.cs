using FluentValidationExample.Entities;

namespace FluentValidationExample.Services {
  public interface IStuffService {
    List<Stuff> GetAllTheStuff();
    Stuff? GetStuffById(Guid id);
    bool AddStuff(Stuff stuff);
    bool RemoveStuff(Guid id);
  }
}
