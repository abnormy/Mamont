using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using Logic;
using Server.Models;

namespace Server.Controllers
{
    public class TaxesController : BaseController
    {
        public List<Tax> GetTaxes()
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);
            return user == null ? null : (user.Taxes ?? new List<Tax>()).ToList();
        }

        public void PutTax(Tax tax)
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);
            var taxes = user.Taxes.ToList();
            taxes.Add(tax);
            user.Taxes = taxes;
            user.Save();
        }

        public void DeleteTax(string name)
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);
            var taxes = user.Taxes.ToList();
            taxes.RemoveAll(t => t.Name == name);
            user.Taxes = taxes;
            user.Save();
        }
    }
}