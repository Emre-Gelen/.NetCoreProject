using FluentValidation;
using NetCoreProject.Services.Classroom.Data.Interfaces;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;

namespace NetCoreProject.Services.Classroom.Business.Operation.Commands.AddLesson;

public class AddLessonCommandValidator : AbstractValidator<AddLessonRequestModel>
{
    private readonly ILessonValidationConstants _lessonValidationConstants;
    public AddLessonCommandValidator(ILessonValidationConstants lessonValidationConstants)
    {
        _lessonValidationConstants = lessonValidationConstants;
        int minNameLength = _lessonValidationConstants.MinNameLength;

        RuleFor(model => model.Name)
            .MinimumLength(minNameLength).WithMessage("{PropertyName} must have at least " + minNameLength + " character.")
            .NotEmpty().WithMessage("{PropertyName} can not be empty.");
    }
}
