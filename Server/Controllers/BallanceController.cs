using System.Collections.Generic;
using System.Linq;
using Entities;
using Logic;

namespace Server.Controllers
{
    public class BallanceController : BaseController
    {
        public double GetBallance()
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);
            return user.Balance;
        }
    }
}
