using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Server.Controllers
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var baseController = context.ControllerContext.Controller as BaseController;
            if (baseController != null)
                baseController.OnActionExecuting(context);
        }
    }
}