using FluentValidation;
using Rocket.BL.Properties;

namespace Rocket.BL.Validators.User
{
    /// <summary>
    /// Задаем условия для валидатора данных о человеке.
    /// </summary>
    public class UserValidatorCheckRequiredFields : AbstractValidator<Common.Models.User.User>
    {
        public UserValidatorCheckRequiredFields()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage(Resources.USERPERSONFIRSTNAMEISEMPTY)
                .NotNull()
                .WithMessage(Resources.USERPERSONFIRSTNAMEISEMPTY);
            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage(Resources.USERPERSONSECONDNAMEISEMPTY)
                .NotNull()
                .WithMessage(Resources.USERPERSONSECONDNAMEISEMPTY);
        }
    }
}