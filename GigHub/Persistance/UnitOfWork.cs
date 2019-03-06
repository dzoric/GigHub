using GigHub.Models;
using GigHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }

        public IAttendanceRepository Attendances { get; set; }

        public IGenreRepository Genres { get; set; }

        public IFollowingRepository Followings { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}