namespace Lab_MongoDB_API.Models.ConfigModel
{
    public class MongoDBConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string UserAccount { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
