namespace GigHub.Repositories
{
    public interface IFollowingsRepository
    {
        bool GetFollowing(string artistId, string userId);
    }
}