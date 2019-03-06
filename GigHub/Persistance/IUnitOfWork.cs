using GigHub.Repositories;

namespace GigHub.Persistance
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; set; }
        IFollowingRepository Followings { get; set; }
        IGenreRepository Genres { get; set; }
        IGigRepository Gigs { get; }

        void Complete();
    }
}