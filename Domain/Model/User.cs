using System.Collections.Generic;

namespace Domain.Model
{
    public class User : Entity
    {
        public Auth Auth { get; set; }
        public int Balance { get; set; }
        public IEnumerable<Tax> Taxes { get; set; }
    }
}