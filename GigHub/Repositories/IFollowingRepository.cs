using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        IQueryable<Following> GetFollowing(string userId, string artistId);
    }
}