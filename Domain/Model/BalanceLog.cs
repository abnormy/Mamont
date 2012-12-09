namespace Domain.Model
{
    public class BalanceLog : Entity
    {
        public string UserId { get; set; }
        public string Operation { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
    }
}