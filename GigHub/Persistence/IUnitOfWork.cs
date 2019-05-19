using GigHub.Repositories;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IFollowingsRepository Followings { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}