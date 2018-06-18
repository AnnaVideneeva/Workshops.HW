using FluentValidation;
using Rocket.BL.Common.Models.PersonalArea;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.BL.Properties;
using Rocket.DAL.Common.DbModels.DbPersonalArea;
using Rocket.DAL.Common.UoW;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rocket.BL.Services.PersonalArea
{
    public class ChangeEmailManagerService : BaseService, IEmailManager
    {
        private string _pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        public ChangeEmailManagerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Метод для добавления email.
        /// </summary>
        /// <param name="id">Id авторизованного пользователь, инициировавшего смену</param>
        /// <param name="email">Email, который необходимо добавить.</param>
        /// <returns>Id добавленного e-mail</returns>
        public int AddEmail(string id, Email email)
        {
            if (_unitOfWork.EmailRepository.Get()
                    .FirstOrDefault(c => c.Name == email.Name) != null)
            {
                throw new ValidationException(Resources.EmailDuplicate);
            }
            if (!Regex.IsMatch(email.Name, _pattern, RegexOptions.IgnoreCase))
                throw new ValidationException(Resources.WrongEmailFormat);
             var emails = new DbEmail() { Name = email.Name, DbUserProfileId = id };
            _unitOfWork.EmailRepository.Insert(emails);
            _unitOfWork.SaveChanges();
            return emails.Id;
        }

        /// <summary>
        /// Метод для удаления email.
        /// </summary>
        /// <param name="id">Id email, который необходимо удалить</param>
        public void DeleteEmail(int id)
        {
            var model = _unitOfWork.EmailRepository.GetById(id);
            if (model == null)
            {
                throw new ValidationException(Resources.UndefinedEmail);
            }

            _unitOfWork.EmailRepository.Delete(model);
            _unitOfWork.SaveChanges();
        }
    }
}