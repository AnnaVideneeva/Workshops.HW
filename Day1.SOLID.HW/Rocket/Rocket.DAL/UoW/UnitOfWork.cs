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
using Rocket.DAL.Common.UoW;
using Rocket.DAL.Context;

namespace Rocket.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private RocketContext _rocketContext;
        private bool _disposed;

        /// <summary>
        /// Unit of Work для RocketConext
        /// </summary>
        /// <param name="rocketContext">Контекст данных</param>
        /// <param name="musicRepository">Репозиторий релиза</param>
        /// <param name="parserSettingsRepository">Репозиторий настроек парсера</param>
        /// <param name="resourceRepository">Репозиторий ресурса</param>
        /// <param name="resourceItemRepository">Репозиторий элемента ресурса</param>
        /// <param name="musicGenreRepository">Репозиторий жанра</param>
        /// <param name="musicTrackRepository">Репозиторий трека</param>
        /// <param name="musicianRepository">Репозиторий исполнителя</param>
        /// <param name="notificationsLogRepository">Репозиторий лога сервиса нотификации</param>
        /// <param name="notificationsSettingsRepository">Репозиторий настроек сервиса нотификации</param>
        /// <param name="categoryRepository">Репозиторий категорий</param>
        /// <param name="episodeRepository">Репозиторий серий</param>
        /// <param name="genreRepository">Репозиторий жанров</param>
        /// <param name="personRepository">Репозиторий людей - актеров, режиссеров</param>
        /// <param name="personTypeRepository">Репозиторий типов людей</param>
        /// <param name="seasonRepository">Репозиторий сезонов</param>
        /// <param name="tvSeriasRepository">Репозиторий сериалов</param>
        /// <param name="dbEmailRepository">Репозиторий email</param>
        /// <param name="dbUserRepository">Репозиторий пользователей</param>
        /// <param name="dbCountryRepository">Репозиторий стран.</param>
        /// <param name="dbAccountLevelRepository">Репозиторий уровней аккаунта детальной информации пользователей.</param>
        /// <param name="dbAccountStatusRepositary">Репозиторий уровней статуса детальной информации пользователей.</param>
        /// <param name="dbAddressRepositary">Репозиторий адресов детальной информации пользователей.</param>
        /// <param name="dbEmailAddressRepositary">Репозиторий адресов электронной почты детальной информации пользователей.</param>
        /// <param name="dbGenderRepository">Репозиторий сведений о половой принадлежности пользователей.</param>
        /// <param name="dbHowToCallRepository">Репозиторий сведений о том, как обращаться к пользователям.</param>
        /// <param name="dbLanguageRepositary">Репозиторий языков (общения) пользователей.</param>
        /// <param name="dbPhoneNumberRepository">Репозиторий номеров телефонов детяльной информации пользователей.</param>
        /// <param name="dbUserDetailRepository">Репозиторий детальной информации пользователей.</param>
        /// <param name="dbRoleRepository">Репозиторий ролей</param>
        /// <param name="dbPermissionRepository">Репозиторий разрешений</param>
        /// <param name="dbAuthorisedUserRepository">Репозиторий авторизованных пользователей</param>
        /// <param name="dbCustomMessageRepository">Репозиторий сообщений произвольного содержания</param>
        /// <param name="dbEmailTemplateRepository">Репозиторий шаблонов email сообщений</param>
        /// <param name="dbGuestBillingMessageRepository">Репозиторий донатов гостя</param>
        /// <param name="dbReceiverRepository">Репозиторий получателей нотификации</param>
        /// <param name="dbReleaseMessageRepository">Репозиторий сообщений о релизе</param>
        /// <param name="dbUserBillingMessageRepository">Репозиторий сообщений о платежах пользователя</param>
        /// <param name="userPaymentRepository">Репозиторий платежей пользователя</param>
        /// <param name="subscribableRepository">Репозиторий ресурсов для подписки</param>
        
        public UnitOfWork(
            RocketContext rocketContext,
            IBaseRepository<DbMusic> musicRepository,
            IBaseRepository<ParserSettingsEntity> parserSettingsRepository,
            IBaseRepository<ResourceEntity> resourceRepository,
            IBaseRepository<ResourceItemEntity> resourceItemRepository,
            IBaseRepository<DbMusicGenre> musicGenreRepository,
            IBaseRepository<DbMusicTrack> musicTrackRepository,
            IBaseRepository<DbMusician> musicianRepository,
            IBaseRepository<CategoryEntity> categoryRepository,
            IBaseRepository<EpisodeEntity> episodeRepository,
            IBaseRepository<GenreEntity> genreRepository,
            IBaseRepository<PersonEntity> personRepository,
            IBaseRepository<PersonTypeEntity> personTypeRepository,
            IBaseRepository<SeasonEntity> seasonRepository,
            IBaseRepository<TvSeriasEntity> tvSeriasRepository,
            IDbEmailRepository dbEmailRepository,
            IDbUserRepository dbUserRepository,
            //IDbCountryRepository dbCountryRepository,
            //IDbAccountLevelRepository dbAccountLevelRepository,
            //IDbAccountStatusRepositary dbAccountStatusRepositary,
            //IDbAddressRepositary dbAddressRepositary,
            //IDbEmailAddressRepositary dbEmailAddressRepositary,
            //IDbGenderRepository dbGenderRepository,
            //IDbHowToCallRepository dbHowToCallRepository,
            //IDbLanguageRepositary dbLanguageRepositary,
            //IDbPhoneNumberRepository dbPhoneNumberRepository,
            //IDbUserDetailRepository dbUserDetailRepository,
            IDbRoleRepository dbRoleRepository,
            IDbPermissionRepository dbPermissionRepository,
            IDbUserProfileRepository dbAuthorisedUserRepository,
            IDbCustomMessageRepository dbCustomMessageRepository,
            IBaseRepository<NotificationsLogEntity> notificationsLogRepository,
            IBaseRepository<NotificationsSettingsEntity> notificationsSettingsRepository,
            IDbEmailTemplateRepository dbEmailTemplateRepository,
            IDbGuestBillingMessageRepository dbGuestBillingMessageRepository,
            IDbReceiverRepository dbReceiverRepository,
            IDbReleaseMessageRepository dbReleaseMessageRepository,
            IDbUserBillingMessageRepository dbUserBillingMessageRepository,
            IBaseRepository<DbUserPayment> userPaymentRepository,
            IBaseRepository<SubscribableEntity> subscribableRepository)
        {
            _rocketContext = rocketContext;
            MusicRepository = musicRepository;
            ParserSettingsRepository = parserSettingsRepository;
            ResourceRepository = resourceRepository;
            ResourceItemRepository = resourceItemRepository;
            MusicGenreRepository = musicGenreRepository;
            MusicTrackRepository = musicTrackRepository;
            MusicianRepository = musicianRepository;
            CategoryRepository = categoryRepository;
            EpisodeRepository = episodeRepository;
            GenreRepository = genreRepository;
            PersonRepository = personRepository;
            PersonTypeRepository = personTypeRepository;
            SeasonRepository = seasonRepository;
            TvSeriasRepository = tvSeriasRepository;
            EmailRepository = dbEmailRepository;
            UserRepository = dbUserRepository;
            //CountryRepository = dbCountryRepository;
            //AccountLevelRepository = dbAccountLevelRepository;
            //AccountStatusRepositary = dbAccountStatusRepositary;
            //AddressRepositary = dbAddressRepositary;
            //EmailAddressRepositary = dbEmailAddressRepositary;
            //GenderRepository = dbGenderRepository;
            //HowToCallRepository = dbHowToCallRepository;
            //LanguageRepositary = dbLanguageRepositary;
            //PhoneNumberRepository = dbPhoneNumberRepository;
            //UserDetailRepository = dbUserDetailRepository;
            RoleRepository = dbRoleRepository;
            PermissionRepository = dbPermissionRepository;
            UserAuthorisedRepository = dbAuthorisedUserRepository;
            CustomMessageRepository = dbCustomMessageRepository;
            NotificationsLogRepository = notificationsLogRepository;
            NotificationSettingsRepository = notificationsSettingsRepository;
            EmailTemplateRepository = dbEmailTemplateRepository;
            GuestBillingMessageRepository = dbGuestBillingMessageRepository;
            ReceiverRepository = dbReceiverRepository;
            ReleaseMessageRepository = dbReleaseMessageRepository;
            UserBillingMessageRepository = dbUserBillingMessageRepository;
            UserPaymentRepository = userPaymentRepository;
            SubscribableRepository = subscribableRepository;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Возвращает репозиторий для музыкального релиза
        /// </summary>
        public IBaseRepository<DbMusic> MusicRepository { get; }

        /// <summary>
        /// Репозиторий настроек парсера
        /// </summary>
        public IBaseRepository<ParserSettingsEntity> ParserSettingsRepository { get; }

        /// <summary>
        /// Репозиторий ресурса
        /// </summary>
        public IBaseRepository<ResourceEntity> ResourceRepository { get; }

        /// <summary>
        /// Репозиторий элемента ресурса
        /// </summary>
        public IBaseRepository<ResourceItemEntity> ResourceItemRepository { get; }

        /// <summary>
        /// Репозиторий музыкального жанра
        /// </summary>
        public IBaseRepository<DbMusicGenre> MusicGenreRepository { get; }

        /// <summary>
        /// Репозиторий музыкального трека
        /// </summary>
        public IBaseRepository<DbMusicTrack> MusicTrackRepository { get; }

        /// <summary>
        /// Репозиторий музыканта
        /// </summary>
        public IBaseRepository<DbMusician> MusicianRepository { get; }

        public IBaseRepository<CategoryEntity> CategoryRepository { get; }

        public IBaseRepository<EpisodeEntity> EpisodeRepository { get; }

        /// <summary>
        /// Репозиторий жанра
        /// </summary>
        public IBaseRepository<GenreEntity> GenreRepository { get; }

        public IBaseRepository<PersonEntity> PersonRepository { get; }

        public IBaseRepository<PersonTypeEntity> PersonTypeRepository { get; }

        public IBaseRepository<SeasonEntity> SeasonRepository { get; }

        public IBaseRepository<TvSeriasEntity> TvSeriasRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для emails.
        /// </summary>
        public IDbEmailRepository EmailRepository { get; }

        /// <summary>
        /// Репозиторий для работы с пользователями.
        /// </summary>
        public IDbUserRepository UserRepository { get; }

        /// <summary>
        /// Репозиторий для работы со странами.
        /// </summary>
        public IDbCountryRepository CountryRepository { get; }

        /// <summary>
        /// Репозиторий для работы с уровнями аккаунтов пользователей.
        /// </summary>
        public IDbAccountLevelRepository AccountLevelRepository { get; }

        /// <summary>
        /// Репозиторий для работы со статусами аккаунтов пользователей.
        /// </summary>
        public IDbAccountStatusRepositary AccountStatusRepositary { get; }

        /// <summary>
        /// Репозиторий для работы с адресами детальной информации пользователей.
        /// </summary>
        public IDbAddressRepositary AddressRepositary { get; }

        /// <summary>
        /// Репозиторий для работы с адресами электронной почты пользователей.
        /// </summary>
        public IDbEmailAddressRepositary EmailAddressRepositary { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями половой принадлежности пользователей.
        /// </summary>
        public IDbGenderRepository GenderRepository { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о том, как обращаться к пользователям.
        /// </summary>
        public IDbHowToCallRepository HowToCallRepository { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о языках детальной информации пользователей.
        /// </summary>
        public IDbLanguageRepositary LanguageRepositary { get; }

        /// <summary>
        /// Репозиторий для работы со сведениями о телефонных номерах детальной информации пользователей.
        /// </summary>
        public IDbPhoneNumberRepository PhoneNumberRepository { get; }

        /// <summary>
        /// Репозиторий для работы с детальной информацией пользователей.
        /// </summary>
        public IDbUserDetailRepository UserDetailRepository { get; }

        /// <summary>
        /// Репозиторий для работы с ролями.
        /// </summary>
        public IDbRoleRepository RoleRepository { get; }

        /// <summary>
        /// Репозиторий для работы с ролями.
        /// </summary>
        public IDbUserRoleRepository UserRoleRepository { get; }

        /// <summary>
        /// Репозиторий для работы с пермишенами.
        /// </summary>
        public IDbPermissionRepository PermissionRepository { get; }

        /// <summary>
        /// Репозиотрий для работы с пользователями личного кабинета.
        /// </summary>
        public IDbUserProfileRepository UserAuthorisedRepository { get; }

        /// <summary>
        /// Возвращает репозиторий для сообщений произвольного содержания
        /// </summary>
        public IDbCustomMessageRepository CustomMessageRepository { get; }

        /// <inheritdoc />
        /// <summary>
        /// Репозиторий лога нотификации
        /// </summary>
        public IBaseRepository<NotificationsLogEntity> NotificationsLogRepository { get; }

        /// <inheritdoc />
        /// <summary>
        /// Репозиторий настроек сервиса нотификации
        /// </summary>
        public IBaseRepository<NotificationsSettingsEntity> NotificationSettingsRepository { get; }

        /// <summary>
        /// Возвращает репозиторий шаблонов email сообщений
        /// </summary>
        public IDbEmailTemplateRepository EmailTemplateRepository { get; }

        /// <summary>
        /// Возвращает репозиторий донатов гостя
        /// </summary>
        public IDbGuestBillingMessageRepository GuestBillingMessageRepository { get; }

        /// <summary>
        /// Возвращает репозиторий получателей нотификации
        /// </summary>
        public IDbReceiverRepository ReceiverRepository { get; }

        /// <summary>
        /// Возвращает репозиторий сообщений о релизе
        /// </summary>
        public IDbReleaseMessageRepository ReleaseMessageRepository { get; }

        /// <summary>
        /// Возвращает репозиторий сообщений о платежах пользователя
        /// </summary>
        public IDbUserBillingMessageRepository UserBillingMessageRepository { get; }

        /// <summary>
        /// Репозиторий платежей пользователя
        /// </summary>
        public IBaseRepository<DbUserPayment> UserPaymentRepository { get; }

        public IBaseRepository<SubscribableEntity> SubscribableRepository { get; }

        /// <summary>
        /// Освобождает управляемые ресурсы.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <returns> int </returns>
        public int SaveChanges()
        {
            return _rocketContext.SaveChanges();
        }
        
        /// <summary>
        /// Освобождает управляемые ресурсы.
        /// </summary>
        /// <param name="disposing">Указывает вызван ли этот метод из метода Dispose() или из финализатора.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            _rocketContext?.Dispose();
            _rocketContext = null;
            _disposed = true;
        }
    }
}
