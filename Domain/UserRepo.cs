using Entities;

namespace Domain
{
    public class UserRepo : BaseRepo<User>
    {
        protected override string CollectionName
        {
            get { return "User"; }
        }
    }
}