using System;

namespace Domain.Model
{
    public class Session : Entity
    {
        public string UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}