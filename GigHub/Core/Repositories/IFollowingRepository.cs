using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        IQueryable<Following> GetFollowing(string userId, string artistId);
    }
}