using GigHub.Core.Repositories;
using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                            .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                            .ToList();
        }

        public IQueryable<Attendance> GetAttendance(int gigId, string userId)
        {
            return _context.Attendances.Where(a => a.GigId == gigId && a.AttendeeId == userId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public Attendance GetSingleAttendance(int gigId, string userId)
        {
            return _context.Attendances.SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);
        }

        public bool DoesAttendanceExist(string userId, int gigId)
        {
            return _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId);
        }
    }
}