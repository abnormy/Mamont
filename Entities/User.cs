﻿using System.Collections.Generic;

namespace Entities
{
    public class User : Entity
    {
        public Auth Auth { get; set; }
        public double Balance { get; set; }
        public IEnumerable<Tax> Taxes { get; set; }
        public IEnumerable<BalanceLog> BallanceLog { get; set; }

        public User()
        {
           Taxes = new List<Tax>();
        }
    }
}