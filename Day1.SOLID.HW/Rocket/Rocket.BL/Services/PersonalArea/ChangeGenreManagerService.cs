using FluentValidation;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.BL.Properties;
using Rocket.DAL.Common.UoW;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.BL.Services.PersonalArea
{
    public class ChangeGenreManagerService : BaseService, IGenreManager
    {
        public ChangeGenreManagerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable GetAllMusicGenres()
        {
            return AutoMapper.Mapper.Map<IEnumerable<MusicGenre>>(_unitOfWork.MusicGenreRepository.Get());
        }

        public IEnumerable GetAllTvGenres()
        {
            return AutoMapper.Mapper.Map<IEnumerable<Genre>>(_unitOfWork.GenreRepository.Get());
        }

        /// <summary>
        /// Добавляет музыкальный жанр пользователю.
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="genre">Имя жанра для добавления</param>
        public void AddMusicGenre(string id, string genre)
        {
            var modelUser = _unitOfWork.UserAuthorisedRepository.Get(f => f.DbUser_Id == id).FirstOrDefault()
               ?? throw new ValidationException(Resources.EmptyModel);
            if (_unitOfWork.MusicGenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() == null)
            {
                throw new ValidationException(Resources.GenreWrongName);
            }

            if (modelUser.MusicGenres.Where(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() != null)
            {
                throw new ValidationException(Resources.GenreDuplicate);
            }

            modelUser.MusicGenres.Add(_unitOfWork.MusicGenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault());
            _unitOfWork.UserAuthorisedRepository.Update(modelUser);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Добавляет ТV жанр пользователю
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="genre">Имя жанра для добавления</param>
        public void AddTvGenre(string id, string genre)
        {
            var modelUser = _unitOfWork.UserAuthorisedRepository.Get(f => f.DbUser_Id == id).FirstOrDefault()
                ?? throw new ValidationException(Resources.EmptyModel);
            if (_unitOfWork.GenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() == null)
            {
                throw new ValidationException(Resources.GenreWrongName);
            }

            if (modelUser.Genres.Where(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() != null)
            {
                throw new ValidationException(Resources.GenreDuplicate);
            }

            modelUser.Genres.Add(_unitOfWork.GenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault());
            _unitOfWork.UserAuthorisedRepository.Update(modelUser);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удаляет музыкальный жанр у пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="genre">Имя жанра для удаления</param>
        public void DeleteMusicGenre(string id, string genre)
        {
            var modelUser = _unitOfWork.UserAuthorisedRepository.Get(f => f.DbUser_Id == id).FirstOrDefault() 
                ?? throw new ValidationException(Resources.EmptyModel);
            if (modelUser.MusicGenres.Where(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() != null)
            {
                modelUser.MusicGenres.Remove(_unitOfWork.MusicGenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault());
            }
            else
            {
                throw new ValidationException(Resources.GenreWrongName);
            }

            _unitOfWork.UserAuthorisedRepository.Update(modelUser);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удаляет музыкальный жанр у пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="genre">Имя жанра для удаления</param>
        public void DeleteTvGenre(string id, string genre)
        {
            var modelUser = _unitOfWork.UserAuthorisedRepository.Get(f => f.DbUser_Id == id).FirstOrDefault()
                ?? throw new ValidationException(Resources.EmptyModel);
            if (modelUser.Genres.Where(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault() != null)
            {
                modelUser.Genres.Remove(_unitOfWork.GenreRepository.Get(f => f.Name.ToUpper() == genre.ToUpper()).FirstOrDefault());
            }
            else
            {
                throw new ValidationException(Resources.GenreWrongName);
            }

            _unitOfWork.UserAuthorisedRepository.Update(modelUser);
            _unitOfWork.SaveChanges();
        }
    }
}