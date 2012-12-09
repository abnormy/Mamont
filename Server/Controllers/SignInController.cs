using Logic;
using Server.Models;

namespace Server.Controllers
{
    public class SignInController : BaseController
    {
        [Insecure]
        public string PostSignIn(SignInUpDto credentials)
        {
            var manager = new LoginManager();
            return manager.SignIn(credentials.Email, credentials.Password);
        }
    }
}
