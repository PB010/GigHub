namespace GigHub.Core.Repositories
{
    public interface IFollowingsRepository
    {
        bool GetFollowing(string artistId, string userId);
    }
}