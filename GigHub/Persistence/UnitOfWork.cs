using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public GigRepository Gigs { get; }
        public AttendanceRepository Attendances { get; }
        public FollowingsRepository Followings { get; }
        public GenreRepository Genres { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingsRepository(context);
            Genres = new GenreRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}