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
            return userRepo.GetAll().FirstOrDefault(u => u.Id == session.UserId);
        }
    }
}
