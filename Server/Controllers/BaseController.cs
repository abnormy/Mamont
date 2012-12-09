using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Logic;

namespace Server.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController : ApiController
    {
        private const string AuthenticationHeaderName = "AuthKey";
        protected string SessionId { get; private set; }        internal virtual void OnActionExecuting(HttpActionContext context)
        {
            IEnumerable<string> values;
            context.Request.Headers.TryGetValues(AuthenticationHeaderName, out values);
            if (values != null && values.Any())
            {
                SessionId = values.First();
            }

            var insecure = context.ActionDescriptor.GetFilters().FirstOrDefault(f => f.GetType() == typeof (InsecureAttribute));
            if (SessionId == null && insecure == null)
            {
                throw new InvalidOperationException("You won't hack me!");
            }
            if (SessionId != null && insecure == null)
            {
                var manager = new LoginManager();
                if (!manager.ValidateSession(SessionId))
                {
                    throw new NotImplementedException("Session key is invalid.");
                }
            }
        }
    }
}