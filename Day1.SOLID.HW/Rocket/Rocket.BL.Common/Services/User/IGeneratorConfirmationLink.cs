namespace Rocket.BL.Common.Services.User
{
    public interface IGeneratorConfirmationLink 
    {
        /// <summary>
        /// После добавление пользователя в репозитарий 
        /// генерирует ссылку, по которой пользователь
        /// в случае получения уведомлении об активации, может 
        /// активировать аккаунт.
        /// </summary>
        /// <param name="user">Экземпляр пользователя.</param>
        /// <returns>Ссылку для активации аккаунта.</returns>
        string CreateConfirmationLink(Models.User.User user);
    }
}