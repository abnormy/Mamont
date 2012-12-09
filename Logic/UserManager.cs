using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Entities;

namespace Logic
{
    public class UserManager
    {
        public User LoadBySessionKey(string sessionKey)
        {
            var sessionRepo = new SessionRepo();
            var session = sessionRepo.GetAll().FirstOrDefault(s => s.Id == sessionKey);
            var userRepo = new UserRepo();
            var user = userRepo.GetAll().FirstOrDefault(u => u.Id == session.UserId);
            if (user != null)
            {
                if (user.Taxes == null)
                    user.Taxes = new List<Tax>();
            }
            return user;
        }
    }

    public static class UserExtensions
    {
        public static User WithBallanceLog(this User user)
        {
            if (user == null)
            {
                return null;
            }
            var repo = new BalanceLogRepo();
            user.BallanceLog = repo.GetAll().Where(b => b.UserId == user.Id);
            return user;
        }

        public static void UpdateBalance(this User user, double diff, string comment)
        {
            user.Balance += diff;
            var log = new BalanceLog { Amount = diff, UserId = user.Id, Date = DateTime.UtcNow, Comment = comment };
            var repo = new BalanceLogRepo();
            repo.Save(log);
        }

        public static void Save(this User user)
        {
            var userRepo = new UserRepo();
            userRepo.Save(user);
        }
    }
}
