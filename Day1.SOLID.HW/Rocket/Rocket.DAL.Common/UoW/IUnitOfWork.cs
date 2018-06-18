using System;
using Rocket.DAL.Common.DbModels;
using Rocket.DAL.Common.DbModels.Notification;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.ReleaseList;
using Rocket.DAL.Common.DbModels.Subscription;
using Rocket.DAL.Common.Repositories;
using Rocket.DAL.Common.Repositories.IDbPersonalAreaRepository;
using Rocket.DAL.Common.Repositories.IDbUserRoleRepository;
using Rocket.DAL.Common.Repositories.Notification;
using Rocket.DAL.Common.Repositories.User;

namespace Rocket.DAL.Common.UoW
{
    /// <summary>
    /// Представляет общий интерфейс unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Возвращает репозиторий для emails.
        /// </summary>
        IDbEmailRepository EmailRepository { get; }

        /// <summary>
        /// Репозиторий для работы с пользователями.
        /// </summary>
        IDbUserRepository UserRepository { get; }

        /// <summary>
        /// Репозиторий для работы со странами.
        /// </summary>
        IDbCountryRepository CountryRepository { get; }

        /// <summary>
        /// Репозиторий для работы с уровнями аккаунтов пользователей.
        /// </summary>
        IDbAccountLevelRepository AccountLevelRepository { get; }

        /// <summary>
        /// Репозиторий для работы со статусами аккаунтов пользователей.
        /// </summary>
        IDbAccountStatusRepositary AccountStatusRepositary { get; }

        /// <summary>
        /// Репозиторий для работы с адресами детальной информации пользователей.
        /// </summary>
        IDbAddressRepositary AddressRepositary { get; }

        /// <summary>
        /// Репозиторий для работы с адресами электронной почты пользователей.
        /// </summary>
        IDbEmailAddressRepositary EmailAddressRepositary { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями половой принадлежности пользователей.
        /// </summary>
        IDbGenderRepository GenderRepository { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о том, как обращаться к пользователям.
        /// </summary>
        IDbHowToCallRepository HowToCallRepository { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о языках детальной информации пользователей.
        /// </summary>
        IDbLanguageRepositary LanguageRepositary { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о телефонных номерах детальной информации пользователей.
        /// </summary>
        IDbPhoneNumberRepository PhoneNumberRepository { get; }

        /// <summary>
        /// Репозиторий для работы с детальной информацией пользователей.
        /// </summary>
        IDbUserDetailRepository UserDetailRepository { get; }

        /// <summary>
        /// Репозиторий для работы с ролями.
        /// </summary>
        IDbRoleRepository RoleRepository { get; }

        /// <summary>
        /// Репозиторий для работы с ролями.
        /// </summary>
        IDbUserRoleRepository UserRoleRepository { get; }

        /// <summary>
        /// Репозиторий для работы с пермишенами.
        /// </summary>
        IDbPermissionRepository PermissionRepository { get; }

        /// <summary>
        /// Репозиотрий для работы с пользователями личного кабинета.
        /// </summary>
        IDbUserProfileRepository UserAuthorisedRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для музыкального релиза
        /// </summary>
        IBaseRepository<DbMusic> MusicRepository { get; }

        /// <summary>
        /// Репозиторий настроек парсера
        /// </summary>
        IBaseRepository<ParserSettingsEntity> ParserSettingsRepository { get; }

        /// <summary>
        /// Репозиторий ресурса
        /// </summary>
        IBaseRepository<ResourceEntity> ResourceRepository { get; }

        /// <summary>
        /// Репозиторий элемента ресурса
        /// </summary>
        IBaseRepository<ResourceItemEntity> ResourceItemRepository { get; }

        /// <summary>
        /// Репозиторий музыкального жанра
        /// </summary>
        IBaseRepository<DbMusicGenre> MusicGenreRepository { get; }

        /// <summary>
        /// Репозиторий музыкального трека
        /// </summary>
        IBaseRepository<DbMusicTrack> MusicTrackRepository { get; }

        /// <summary>
        /// Репозиторий музыканта
        /// </summary>
        IBaseRepository<DbMusician> MusicianRepository { get; }

        IBaseRepository<CategoryEntity> CategoryRepository { get; }

        IBaseRepository<EpisodeEntity> EpisodeRepository { get; }

        IBaseRepository<GenreEntity> GenreRepository { get; }

        IBaseRepository<PersonEntity> PersonRepository { get; }

        IBaseRepository<PersonTypeEntity> PersonTypeRepository { get; }

        IBaseRepository<SeasonEntity> SeasonRepository { get; }
        
        /// <summary>
        /// Возвращает репозиторий для сообщений произвольного содержания
        /// </summary>
        IDbCustomMessageRepository CustomMessageRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для шаблонов email сообщений
        /// </summary>
        IDbEmailTemplateRepository EmailTemplateRepository { get; }

        IBaseRepository<TvSeriasEntity> TvSeriasRepository { get; }
        
        /// <summary>
        /// Возвращает репозиторий для сообщений с информацией
        /// о совершенном гостем донате
        /// </summary>
        IDbGuestBillingMessageRepository GuestBillingMessageRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для пользователей, являющихся получателями сообщений
        /// </summary>
        IDbReceiverRepository ReceiverRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для сообщений о релизе
        /// </summary>
        IDbReleaseMessageRepository ReleaseMessageRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для сообщений с информацией о совершенных
        /// пользователем платежах на сайте (покупка премиум аккаунта, донат)
        /// </summary>
        IDbUserBillingMessageRepository UserBillingMessageRepository { get; }

        /// <summary>
        /// Репозиторий лога нотификации
        /// </summary>
        IBaseRepository<NotificationsLogEntity> NotificationsLogRepository { get; }

        /// <summary>
        /// Репозиторий платежей пользователя
        /// </summary>
        IBaseRepository<DbUserPayment> UserPaymentRepository { get; }

        /// <summary>
        /// Репозиторий настроек сервиса нотификации
        /// </summary>
        IBaseRepository<NotificationsSettingsEntity> NotificationSettingsRepository { get; }

        IBaseRepository<SubscribableEntity> SubscribableRepository { get; }

        /// <summary>
        /// Сохраняет изменения в хранилище данных
        /// </summary>
        /// <returns> int </returns>
        int SaveChanges();
    }
}