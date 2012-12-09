using Domain.Model;

namespace Domain
{
    public class SessionRepo:BaseRepo<Session>
    {
        protected override string CollectionName
        {
            get { return "Session"; }
        }
    }
}