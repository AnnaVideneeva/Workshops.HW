using System;

namespace Rocket.BL.Common.Services.ReleaseList
{
    public interface ISubscriptionService : IDisposable
    {
    void Subscribe(string userId, int id);

    void Unsubscribe(string userId, int id);
    }
}
