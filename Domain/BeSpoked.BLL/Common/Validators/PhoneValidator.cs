using System.Text.RegularExpressions;
using FluentValidation;

namespace BeSpoked.Common.Validators;

public class PhoneNumberValidator: AbstractValidator<string>
{
    private static readonly Regex USPhoneNumberStandardFormat = new ("^[0-9]{10}$", RegexOptions.Compiled);

    public PhoneNumberValidator()
    {
        RuleFor(phoneNumber => phoneNumber).NotEmpty()
            .When(PhoneNumberLengthInvalid).WithMessage("Phone number incomplete")
            .Matches(USPhoneNumberStandardFormat).WithMessage("Phone number must be formatted as +1##########");
    }

    private static bool PhoneNumberLengthInvalid(string phoneNumber)
    {
        if (phoneNumber.StartsWith("+1"))
            return phoneNumber.Length != 12;
        return phoneNumber.Length != 10;
    }
}

