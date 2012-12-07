using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Web.Http;
using Server.Models;

namespace Server.Controllers
{
    public class ValuesController : ApiController
    {
        // GET /api/values
        public string Get()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("Mamont");
            var collection = database.GetCollection<Greet>("greet");
            return collection.FindOne().Text;
        }
    }
}