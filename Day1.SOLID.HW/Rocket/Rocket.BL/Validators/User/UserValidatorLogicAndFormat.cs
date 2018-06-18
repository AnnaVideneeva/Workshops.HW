using FluentValidation;
using System;
using Rocket.BL.Properties;

namespace Rocket.BL.Validators.User
{
    /// <summary>
    /// Задаем условия для валидатора данных аккаунта.
    /// </summary>
    internal class UserValidatorLogicAndFormat : AbstractValidator<Common.Models.User.User>
    {
        internal UserValidatorLogicAndFormat()
        {
            // Содержит строку с сообщением и минимальным количеством символов,
            // которые должны быть в пароле.
            string userAccountPasswordLenghtAssembleFullMessage = Resources.USERACCOUNTPASSWORDLENGHT +
                                                                  Resources.USERACCOUNTPASSWORDMINLENGHT +
                                                                  Resources
                                                                     .USERACCOUNTPASSWORDLOGINPARTOFSTRINGFORCOMPOSITION;

            // Содержит строку с сообщением и минимальным количеством символов,
            // которые должны быть в логине.
            string userAccountLoginLenghtAssembleFullMessage = Resources.USERACCOUNTPASSWORDLENGHT +
                                                               Resources.USERACCOUNTPASSWORDMINLENGHT +
                                                               Resources
                                                                  .USERACCOUNTPASSWORDLOGINPARTOFSTRINGFORCOMPOSITION;

            RuleFor(x => x.Login)
               .NotEmpty()
               .WithMessage(Resources.USERACCOUNTLOGINISEMPTY)
               .NotNull()
               .WithMessage(Resources.USERACCOUNTLOGINISEMPTY)
               .MinimumLength(Convert.ToInt32(Resources.USERACCOUNTLOGINMINLENGTH))
               .WithMessage(userAccountLoginLenghtAssembleFullMessage);
            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(Resources.USERACCOUNTPASSWORDISEMPTY)
               .NotNull()
               .WithMessage(Resources.USERACCOUNTPASSWORDISEMPTY)
               .MinimumLength(Convert.ToInt32(Resources.USERACCOUNTPASSWORDMINLENGHT))
               .WithMessage(userAccountPasswordLenghtAssembleFullMessage);
        }
    }
}