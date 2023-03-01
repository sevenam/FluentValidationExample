using AutoMapper;
using FluentValidationExample.Dtos;
using FluentValidationExample.Entities;
using FluentValidationExample.Services;
using FluentValidationExample.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Endpoints {
  public class AddStuffEndpoint : IEndpoint {
    public void MapEndpoint(WebApplication app) {
      app.MapPost("/stuff/", ([FromBody] StuffDto stuffDto, [FromServices] IStuffService stuffService, [FromServices] IMapper mapper, [FromServices] StuffDtoValidator validator) => {
        var validationResult = validator.Validate(stuffDto);
        if(validationResult.IsValid) {
          var stuff = mapper.Map<Stuff>(stuffDto);
          stuffService.AddStuff(stuff);
          return $"Added some new stuff with name: {stuff.Name}";
        } else {
          return string.Join(string.Empty, validationResult.Errors);
        }
      }).WithOpenApi(op => new(op) { Summary = "Stuff.Add" });
    }
  }
}
