using FluentValidationExample.Services;

namespace FluentValidationExample.Endpoints {
  public class DeleteStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapDelete("/stuff/{id}", (Guid id, IStuffService stuffService) => {
        return stuffService.RemoveStuff(id);
      }).WithOpenApi(op => new(op) { Summary = "Stuff.Delete" });
    }
  }
}
