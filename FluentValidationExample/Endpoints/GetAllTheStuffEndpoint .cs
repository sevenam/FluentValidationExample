using FluentValidationExample.Services;

namespace FluentValidationExample.Endpoints {
  public class GetAllTheStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapGet("/stuff/", (IStuffService stuffService) => {
        return stuffService.GetAllTheStuff();
      }).WithOpenApi(op => new(op) { Summary = "Stuff.GetAll" });
    }
  }
}
