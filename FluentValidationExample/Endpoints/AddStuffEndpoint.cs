using AutoMapper;
using FluentValidationExample.Dtos;
using FluentValidationExample.Entities;
using FluentValidationExample.Services;
using FluentValidationExample.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Endpoints {
  public class AddStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapPost("/stuff/", ([FromBody] StuffDto stuffDto, [FromServices] IStuffService stuffService, [FromServices] IMapper mapper, [FromServices] StuffValidator stuffValidator) => {
        var stuff = mapper.Map<Stuff>(stuffDto);
        var validationResult = stuffValidator.Validate(stuff);
        if(validationResult.IsValid) {
          stuffService.AddStuff(stuff);
          return $"Added some new stuff with name: {stuff.Name}";
        } else {
          return validationResult.Errors.First().ToString();
        }
      }).WithOpenApi(op => new(op) { Summary = "Stuff.Add" });
    }
  }
}
