using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;
using NUnit.Framework;

namespace UnitTestss.LogicTests
{
    [TestFixture]
    public class LoginManagerTests
    {
        [Test]
        public void SignUpTest()
        {
            var manager = new LoginManager();
            Assert.Throws<InvalidOperationException>(() => manager.SignIn(Guid.NewGuid() + "lol@lol.com", "ttt"));
            var email = Guid.NewGuid() + "lol@lol.com";
            manager.SignUp(email, "ttt");
            var sid = manager.SignIn(email, "ttt");
            Assert.IsNotEmpty(sid);
        }
    }
}
