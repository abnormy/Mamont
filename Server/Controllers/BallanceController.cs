using System.Collections.Generic;
using System.Linq;
using Entities;
using Logic;
using Server.Models;

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

        public void PostBalance(BalanceLogDto balance)
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);
            user.UpdateBalance(balance.Diff, balance.Comment);
            user.Save();
        }
    }
}
