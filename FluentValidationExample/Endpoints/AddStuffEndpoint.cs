using AutoMapper;
using FluentValidationExample.Dtos;
using FluentValidationExample.Entities;
using FluentValidationExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Endpoints {
  public class AddStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapPost("/stuff/", ([FromBody] StuffDto stuffDto, [FromServices] IStuffService stuffService, [FromServices] IMapper mapper) => {
        var stuff = mapper.Map<Stuff>(stuffDto);
        return stuffService.AddStuff(stuff);
      }).WithOpenApi(op => new(op) { Summary = "Stuff.Add" });
    }
  }
}
