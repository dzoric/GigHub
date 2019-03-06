using GigHub.Persistence;
using GigHub.Core.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core;
using GigHub.Persistence.Repositories;

namespace GigHub.App_Start
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IAttendanceRepository>().To<AttendanceRepository>();
            Bind<IGigRepository>().To<GigRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
            Bind<IFollowingRepository>().To<FollowingRepository>();
        }
    }
}