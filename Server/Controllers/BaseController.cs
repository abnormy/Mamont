using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController : ApiController
    {
        protected string SessionId { get; private set; }

        internal virtual void OnActionExecuting()
        {
            //TODO: parse authenticatiuon header here
        }
    }
}