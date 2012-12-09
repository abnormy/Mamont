using Domain;
using Entities;
using Logic;
using NUnit.Framework;

namespace UnitTestss.LogicTests
{
    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public void LoadUserTest()
        {
            var userRepo = new UserRepo();
            var sessionRepo = new SessionRepo();

            var user = new User();
            userRepo.Save(user);
            Assert.IsNotNull(user.Id, "Not saved.");
            var session = new Session { UserId = user.Id };
            sessionRepo.Save(session);

            var manager = new UserManager();
            var loaded = manager.LoadBySessionKey(session.Id);
            Assert.IsNotNull(loaded, "Not loaded");
            Assert.AreEqual(user.Id, loaded.Id, "Loaded incorrectly");
        }
    }
}
