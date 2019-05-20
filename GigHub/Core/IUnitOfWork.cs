using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IFollowingsRepository Followings { get; }
        IGenreRepository Genres { get; }
        INotificationsRepository Notifications { get; }
        void Complete();
    }
}