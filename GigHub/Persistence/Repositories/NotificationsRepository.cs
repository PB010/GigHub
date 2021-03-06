﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNotificationsForCurrentUser(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead) 
                .Select(un => un.Notification)
                .Include(n => n.Gig)
                .Include(n => n.Gig.Artist)
                .ToList();
        }

        public List<UserNotification> GetUnreadNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}