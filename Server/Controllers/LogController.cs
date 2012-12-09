using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Logic;

namespace Server.Controllers
{
    public class LogController : BaseController
    {
        public List<BalanceLog> GetBalanceLog()
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId).WithBallanceLog();
            return user.BallanceLog.ToList();
        }
    }
}
