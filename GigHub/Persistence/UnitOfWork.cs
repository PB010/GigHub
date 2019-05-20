using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; }
        public IAttendanceRepository Attendances { get; }
        public IFollowingsRepository Followings { get; }
        public IGenreRepository Genres { get; }
        public INotificationsRepository Notifications { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingsRepository(context);
            Genres = new GenreRepository(context);
            Notifications = new NotificationsRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}