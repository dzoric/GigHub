using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IQueryable<Attendance> GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
        Attendance GetSingleAttendance(int gigId, string userId);
        bool DoesAttendanceExist(string userId, int gigId);
    }
}