﻿using System.Linq;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class FollowingsRepository : IFollowingsRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetFollowing(string artistId, string userId)
        {
            return _context.Follows
                .Any(f => f.FollowedId == artistId && f.FollowerId == userId);
        }
    }
}