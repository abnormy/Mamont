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
            return user == null ? null : user.Taxes.ToList();
        }

        public void Save(Tax tax)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}