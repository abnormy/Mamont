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
        public string SignIn(string email, string password)
        {
            var repo = new UserRepo();
            var user = repo.GetAll().FirstOrDefault(u => u.Auth.Login == email && u.Auth.Pass == password);
            if (user == null)
            {
                return null;
            }
            var sessionRepo = new SessionRepo();
            var session = new Session { UserId = user.Id, ExpirationDate = DateTime.Now.AddHours(2) };
            sessionRepo.Save(session);
            return session.Id;
        }

        public void SignUp(string email, string password)
        {
            var repo = new UserRepo();
            var user = new User {Auth = new Auth {Login = email, Pass = password}};
            repo.Save(user);
        }
    }
}
