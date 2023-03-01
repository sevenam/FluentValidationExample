using FluentValidationExample.Dtos;
using FluentValidationExample.Entities;
using FluentValidationExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Endpoints {
  public class AddStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapPost("/stuff/", ([FromBody] Stuff stuff, [FromServices] IStuffService stuffService) => {
        return stuffService.AddStuff(stuff);
      }).WithOpenApi(op => new(op) { Summary = "Stuff.Add" });
    }
  }
}
