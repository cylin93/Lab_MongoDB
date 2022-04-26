using Lab_MongoDB_API.Infrastructure;
using Lab_MongoDB_API.Interfaces.Dao;
using Lab_MongoDB_API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab_MongoDB_API.Dao
{
    public class UserDao: IUserDao
    {
        private readonly IMongoCollection<UserModel> _mongoCollection;
        public UserDao(MongoDBHelper mongoDBHelper)
        {
            _mongoCollection = mongoDBHelper.MongoDatabase.GetCollection<UserModel>("User");
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _mongoCollection.AsQueryable().ToListAsync();
        }

        public async Task<UserModel> GetUser(FilterDefinition<UserModel> filter)
        {

            return await _mongoCollection.FindAsync<UserModel>(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<UserModel> UpdateUser(FilterDefinition<UserModel> filter, UpdateDefinition<UserModel> update)
        {
            return await _mongoCollection.FindOneAndUpdateAsync<UserModel>(filter,update);
        }

        public async Task InsertUser(UserModel model)
        {
             await _mongoCollection.InsertOneAsync(model);
        }

        public async Task<UserModel> DeleteUser(FilterDefinition<UserModel> filter)
        {
            return await _mongoCollection.FindOneAndDeleteAsync<UserModel>(filter);
        }
    }
}
