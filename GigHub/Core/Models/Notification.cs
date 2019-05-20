using System;

namespace GigHub.Core.Models
{
    public class Notification
    {
        public int Id { get;  private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }

        private Notification(Gig gig, NotificationType type)
        {
            DateTime = DateTime.Now;
            Gig = gig ?? throw new ArgumentNullException("gig");
            Type = type;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
        public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue)
        {
            return new Notification(newGig, NotificationType.GigUpdated)
            {
                OriginalVenue = originalVenue,
                OriginalDateTime = originalDateTime
            };
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }

    }
}