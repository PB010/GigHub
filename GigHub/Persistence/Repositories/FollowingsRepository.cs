using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class FollowingsRepository : IFollowingsRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Follow follow)
        {
            _context.Follows.Add(follow);
        }

        public void Remove(Follow follow)
        {
            _context.Follows.Remove(follow);
        }

        public Follow GetSingleFollow(string id, string userId)
        {
            return _context.Follows.Single(
                f => f.FollowerId == userId
                     && f.FollowedId == id);
        }

        public bool GetFollowingBool(string artistId, string userId)    
        {
            return _context.Follows
                .Any(f => f.FollowedId == artistId && f.FollowerId == userId);
        }

        public IEnumerable<ApplicationUser> GetAllFollowings(string userId)
        {
            return _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followed)
                .ToList();
        }
    }
}