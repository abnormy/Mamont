using System;

namespace Entities
{
    public class BalanceLog : Entity
    {
        public string UserId { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}