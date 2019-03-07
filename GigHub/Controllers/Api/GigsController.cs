using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using Ninject;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public GigsController()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            _unitOfWork = kernel.Get<IUnitOfWork>();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigFromArtist(id, userId);            

            if (gig.IsCanceled)
            {
                return NotFound();
            }

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
