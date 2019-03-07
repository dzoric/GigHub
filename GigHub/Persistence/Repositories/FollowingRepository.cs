using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public bool DoesFollowingExist(string userId, string foloweeId)
        {
            return _context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == foloweeId);
        }

        public IQueryable<Following> GetFollowing(string userId, string artistId)
        {
            return _context.Followings.Where(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }

        public Following GetSingleFollowing(string userId, string followeeId)
        {
           return _context.Followings
                            .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == followeeId);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}