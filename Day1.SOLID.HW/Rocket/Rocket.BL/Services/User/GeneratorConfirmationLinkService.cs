using Rocket.BL.Common.Services.User;

namespace Rocket.BL.Services.User
{
    public class GeneratorConfirmationLinkService : IGeneratorConfirmationLink
    {
        /// <summary>
        /// После добавление пользователя в репозитарий
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        public string CreateConfirmationLink(Common.Models.User.User user)
        {
            // todo надо сделать реализацию, после того, как "прорастут" вьюхи.
            return string.Empty;
        }
    }
}
