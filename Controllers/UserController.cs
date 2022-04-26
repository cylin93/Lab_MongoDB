using Lab_MongoDB_API.Dao;
using Lab_MongoDB_API.Infrastructure;
using Lab_MongoDB_API.Interfaces.Dao;
using Lab_MongoDB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lab_MongoDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDao _dao;
        public UserController(IUserDao userDao)
        {
            _dao = userDao;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<List<UserModel>> GetUsers()
        {
            var result = _dao.GetUsers();
            return result;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public Task<UserModel> GetUserById(string id)
        {
            var objId = new ObjectId(id);
            FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq("_id", objId);
            var result = _dao.GetUser(filter);

            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> AddUser(UserModel user)
        {
            await _dao.InsertUser(user);
            return user.Id;
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<UserModel> UpdateUser(string id, [FromBody] UserModel user)
        {
            var objId = new ObjectId(id);
            FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq("_id", objId);
            UpdateDefinition<UserModel> update = Builders<UserModel>.Update.Set(s => s.Name, user.Name);
            return await _dao.UpdateUser(filter, update);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<string> DeleteUser(string id)
        {
            var objId = new ObjectId(id);
            FilterDefinition<UserModel> filter = Builders<UserModel>.Filter.Eq("_id", objId);
            var result = await _dao.DeleteUser(filter);
            return result.Id;
        }

    }
}
