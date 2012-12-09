using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return null;
            /*var userRepo
            session.UserId*/
        }
    }
}
