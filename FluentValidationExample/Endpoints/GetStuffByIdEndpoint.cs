using FluentValidationExample.Services;

namespace FluentValidationExample.Endpoints {
  public class GetStuffByIdEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapGet("/stuff/{id}", (Guid id, IStuffService stuffService) => {
        return stuffService.GetStuffById(id);
      }).WithOpenApi(op => new(op) { Summary = "Stuff.GetById" });
    }
  }
}
