using FluentValidation;
using FluentValidationExample.Dtos;

namespace FluentValidationExample.Validators {
  public class StuffDtoValidator : AbstractValidator<StuffDto> {
    public StuffDtoValidator() {
      RuleFor(x => x.Name).NotEmpty().Length(0, 20);
    }
  }
}
