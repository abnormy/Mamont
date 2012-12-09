using System;
using System.Web.Http;

namespace Server.Controllers
{
    public class UserController : BaseController
    {
        [Insecure]
        public string PostSignUp(string email, string password)
        {
            return "123";
        }

        [Insecure]
        public string PostSignIn(string email, string password)
        {
            return (email ?? "<no email>") + (password ?? "<no password>");
        }
    }
}