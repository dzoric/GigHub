using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Following> GetFollowing(string userId, string artistId)
        {
            return _context.Followings.Where(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }
    }
}