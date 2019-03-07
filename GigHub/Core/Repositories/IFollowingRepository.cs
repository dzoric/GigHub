using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        IQueryable<Following> GetFollowing(string userId, string artistId);
        bool DoesFollowingExist(string userId, string foloweeId);
        void Add(Following following);
        void Remove(Following following);
        Following GetSingleFollowing(string userId, string followeeId);
    }
}