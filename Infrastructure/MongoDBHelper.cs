using MongoDB.Driver;
using System.Linq.Expressions;

namespace Lab_MongoDB_API.Infrastructure
{
    public class MongoDBHelper
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _mongoDatabase;
        public IMongoDatabase MongoDatabase { get { return _mongoDatabase; } }
        public MongoDBHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectingStr = _configuration["MongoDatabaseSettings:ConnectionString"];
            var connectingUser = _configuration["MongoDatabaseSettings:UserAccount"];
            var connectingPwd = _configuration["MongoDatabaseSettings:Password"];
            var connectingDBName = _configuration["MongoDatabaseSettings:DatabaseName"];
            string connecting = string.Format(connectingStr, connectingUser, connectingPwd, connectingDBName);
            _connectionString = connecting;
            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            _mongoDatabase = client.GetDatabase(connectingDBName);
        }
    }
}
