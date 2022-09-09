using FluentValidation;
using NetCoreProject.Services.Contact.Common.Extensions.Validation;
using NetCoreProject.Services.Contact.Data.Interfaces;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Add;

namespace NetCoreProject.Services.Contact.Business.Operation.Commands.AddContact;

public class AddContactCommandValidator : AbstractValidator<AddContactRequestModel>
{
    private readonly IContactValidationConstantsStore _contactValidationConstants;
    public AddContactCommandValidator(IContactValidationConstantsStore contactValidationConstants)
    {
        _contactValidationConstants = contactValidationConstants;

        RuleFor(contact => contact.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .NotContainsSpecialCharacters(_contactValidationConstants.SpecialCharacters);

        RuleFor(contact => contact.Surname)
              .NotEmpty().WithMessage("{PropertyName} can not be empty.")
              .NotContainsSpecialCharacters(_contactValidationConstants.SpecialCharacters);

        RuleFor(contact => contact.Age)
            .AgeBetween(_contactValidationConstants.MinAge, _contactValidationConstants.MaxAge);
    }
}
