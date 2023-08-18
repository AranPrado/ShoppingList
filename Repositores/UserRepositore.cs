using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;
using ShoppingList.Repositores.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Repositores
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRepositore : IUserRepositores
    {

        

        private readonly ShoppingDbContext _dbContext;

        public UserRepositore(ShoppingDbContext shoppingDbContext)
        {
            _dbContext = shoppingDbContext;
        }

        [HttpGet]
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserModel> SearchUserId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<UserModel> CreateNewUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }


        [HttpPut("{id}")]
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await SearchUserId(id);

            if (userId == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            
            userId.Name = user.Name;
            userId.Email = user.Email;

            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                userId.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            }


            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;

        }
        
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await SearchUserId(id);

            if (userId == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}