using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowingsRepository
    {
        void Add(Follow follow);
        void Remove(Follow follow);
        Follow GetSingleFollow(string id, string userId);
        bool GetFollowingBool(string artistId, string userId);
        IEnumerable<ApplicationUser> GetAllFollowings(string userId);
    }
}