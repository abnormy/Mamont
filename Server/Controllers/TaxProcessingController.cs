using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;

namespace Server.Controllers
{
    public class TaxProcessingController : BaseController
    {
        public void GetProcessTaxes()
        {
            var manager = new UserManager();
            var user = manager.LoadBySessionKey(SessionId);

            foreach (var tax in user.Taxes)
            {
                user.UpdateBalance(-tax.Cost, string.Format("Tax payment: {0}", tax.Name));
            }
            user.Save();
        }
    }
}
