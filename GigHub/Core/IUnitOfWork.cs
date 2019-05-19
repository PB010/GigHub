﻿using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IFollowingsRepository Followings { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}