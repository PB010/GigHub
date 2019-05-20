using GigHub.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGig(int gigId);
        IEnumerable<Gig> GigsToList();
        Gig GetGigWithAttendees(int gigId, string userId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IQueryable<Gig> GetAllUpcomingGigs();
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
    }
}