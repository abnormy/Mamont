using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MongoDB.Bson;

namespace Server.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController : ApiController
    {
        protected ObjectId SessionId { get; private set; }

        internal virtual void OnActionExecuting()
        {
            //TODO: parse authenticatiuon header here
        }
    }
}