using Lab_MongoDB_API.Models;
using MongoDB.Driver;

namespace Lab_MongoDB_API.Interfaces.Dao
{
    public interface IUserDao
    {
        public Task<List<UserModel>> GetUsers();

        public Task<UserModel> GetUser(FilterDefinition<UserModel> filter);

        public Task<UserModel> UpdateUser(FilterDefinition<UserModel> filter, UpdateDefinition<UserModel> update);

        public Task InsertUser(UserModel model);

        public Task<UserModel> DeleteUser(FilterDefinition<UserModel> filter);

    }
}
