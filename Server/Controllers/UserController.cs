using System;
using System.Web.Http;

namespace Server.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        [Insecure]
        public string SignUp(string email, string password)
        {
            throw new NotImplementedException();
        }

        [Insecure]
        public string SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}