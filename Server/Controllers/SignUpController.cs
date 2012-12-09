using System.Net;
using System.Net.Http;
using Logic;
using Server.Models;

namespace Server.Controllers
{
    public class SignUpController : BaseController
    {
        [Insecure]
        public string PostSignUp(SignInUpDto credentials)
        {
            var manager = new LoginManager();
            manager.SignUp(credentials.Email, credentials.Password);
            return manager.SignIn(credentials.Email, credentials.Password);
        }
    }
}
