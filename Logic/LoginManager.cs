using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Domain.Model;

namespace Logic
{
    public class LoginManager
    {
        private readonly UserRepo userRepo = new UserRepo();
        private readonly SessionRepo sessionRepo = new SessionRepo();

        public string SignIn(string email, string password)
        {
            var user = userRepo.GetAll().FirstOrDefault(u => u.Auth.Login == email && u.Auth.Pass == password);
            if (user == null)
            {
                return null;
            }
            var session = new Session { UserId = user.Id, ExpirationDate = DateTime.Now.AddHours(2) };
            sessionRepo.Save(session);
            return session.Id;
        }

        public void SignUp(string email, string password)
        {
            var user = new User {Auth = new Auth {Login = email, Pass = password}};
            userRepo.Save(user);
        }

        public bool ValidateSession(string sessionId)
        {
            return sessionRepo.GetAll().Any(s => s.Id == sessionId);
        }
    }
}
