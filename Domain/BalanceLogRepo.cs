using Entities;

namespace Domain
{
    public class BalanceLogRepo : BaseRepo<BalanceLog>
    {
        protected override string CollectionName
        {
            get { return "BalanceLog"; }
        }
    }
}