using FluentValidation;
using System.Text.RegularExpressions;

namespace NetCoreProject.Services.Contact.Common.Extensions.Validation;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> NotContainsSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder, string specialCharacters)
    {
        return ruleBuilder.Must((rootObject, str, context) =>
        {
            context.MessageFormatter.AppendArgument("SpecialCharacters", specialCharacters);
            return str.checkSpecialCharacters(specialCharacters);
        }).WithMessage("{PropertyName} can not contain {SpecialCharacters}.");
    }

    private static bool checkSpecialCharacters(this string str, string specialCharacters)
    {
        Regex rgx = new Regex($"[{specialCharacters}]");
        return !rgx.IsMatch(str);
    }

    public static IRuleBuilderOptions<T, int> AgeBetween<T>(this IRuleBuilder<T, int> ruleBuilder, int minAge, int maxAge)
    {
        return ruleBuilder.Must((rootObject, age, context) =>
        {
            context.MessageFormatter.AppendArgument("MinAge", minAge);
            context.MessageFormatter.AppendArgument("MaxAge", maxAge);
            return age >= minAge && age <= maxAge;
        }).WithMessage("{PropertyName} must be between {MinAge} - {MaxAge}.");
    }
}
