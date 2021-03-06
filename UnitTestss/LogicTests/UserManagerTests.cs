﻿using System;
using System.Linq;
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
            var balanceRepo = new BalanceLogRepo();

            var user = new User();
            userRepo.Save(user);
            Assert.IsNotNull(user.Id, "Not saved.");
            var session = new Session { UserId = user.Id };
            sessionRepo.Save(session);

            var date = DateTime.UtcNow;

            balanceRepo.Save(new BalanceLog { UserId = user.Id, Amount = 3, Comment = "comment", Date = date });

            var manager = new UserManager();
            var loaded = manager.LoadBySessionKey(session.Id).WithBallanceLog();
            Assert.IsNotNull(loaded, "Not loaded");
            Assert.AreEqual(user.Id, loaded.Id, "Loaded incorrectly");
            Assert.IsNotNull(loaded.BallanceLog, "Balance log is null.");
            Assert.AreEqual(1, loaded.BallanceLog.Count(), "Balance log count incorrect.");
            var balance = loaded.BallanceLog.First();
            Assert.AreEqual(3, balance.Amount, "Amount incorrect.");
            Assert.AreEqual("comment", balance.Comment, "Comment incorrect.");
            Assert.AreEqual(date, balance.Date, "Date incorrect.");
        }

        [Test]
        public void UpdateBalanceTest()
        {
            var userRepo = new UserRepo();

            var user = new User();
            userRepo.Save(user);

            user.UpdateBalance(40, "Salary ;(");
            user.Save();

            var loaded = userRepo.GetAll().Single(u => u.Id == user.Id).WithBallanceLog();
            Assert.AreEqual(40, loaded.Balance, "Balance not loaded.");
            Assert.AreEqual(1, loaded.BallanceLog.Count(), "Log is incorrect.");
            Assert.AreEqual(40, loaded.BallanceLog.First().Amount, "Amount is incorrect.");
            Assert.AreEqual("Salary ;(", loaded.BallanceLog.First().Comment, "Comment is incorrect");
        }
    }
}
