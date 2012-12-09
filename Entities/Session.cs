using System;

namespace Entities
{
    public class Session : Entity
    {
        public string UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}