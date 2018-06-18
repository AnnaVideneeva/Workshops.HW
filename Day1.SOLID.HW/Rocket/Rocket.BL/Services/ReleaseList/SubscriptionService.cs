using Rocket.BL.Common.Services.ReleaseList;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Common.UoW;
using System.Linq;

namespace Rocket.BL.Services.ReleaseList
{
    public class SubscriptionService : BaseService, ISubscriptionService
    {
        public SubscriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Subscribe(string userId, int id)
        {
            var user = unitOfWork.UserRepository.Get(f => f.Id == userId, includeProperties: $"{nameof(DbUser.Subscriptions)}")
                .FirstOrDefault();
            var subscription = unitOfWork.SubscribableRepository.GetById(id);
            if (user != null && subscription != null && !user.Subscriptions.Contains(subscription))
            {
                user.Subscriptions.Add(subscription);
            }

            unitOfWork.SaveChanges();
        }

        public void Unsubscribe(string userId, int id)
        {
            var user = unitOfWork.UserRepository.Get(f => f.Id == userId, includeProperties: $"{nameof(DbUser.Subscriptions)}")
                .FirstOrDefault();
            var subscription = unitOfWork.SubscribableRepository.GetById(id);
            if (user != null && subscription != null && user.Subscriptions.Contains(subscription))
            {
                user.Subscriptions.Remove(subscription);
            }

            unitOfWork.SaveChanges();
        }
    }
}
