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
            var result = manager.SignUp(credentials.Email, credentials.Password);

            return result ? manager.SignIn(credentials.Email, credentials.Password) : null;
        }
    }
}
