using GigHub.Core.Models;
using System.Collections.Generic;
using System.Threading;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
        bool GetAttendanceBool(string userId, int gigId);
        Attendance GetSingleAttendance(int id, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}