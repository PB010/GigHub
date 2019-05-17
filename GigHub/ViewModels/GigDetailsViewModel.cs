using GigHub.Models;
using System;
using System.Linq;

namespace GigHub.ViewModels
{
    public class GigDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; private set; }
        public string Artist { get; private set; }
        public string Venue { get; private set; }
        public bool IsAttending { get; private set; }
        public bool IsFollowing { get; set; }



        public void Details(Gig gig, string userId)
        {
            DateTime = gig.DateTime;
            Artist = gig.Artist.Name;
            Venue = gig.Venue;

            if (gig.Attendances.Any(u => u.AttendeeId == userId))
                IsAttending = true;




        }
    }
}