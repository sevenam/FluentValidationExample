using FluentValidation;
using FluentValidationExample.Entities;

namespace FluentValidationExample.Validators {
  public class StuffValidator : AbstractValidator<Stuff> {
    public StuffValidator() {
      RuleFor(x => x.Name).NotEmpty().Length(0, 20);
    }
  }
}
