using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Repositores.Interfaces
{
    public interface IUserRepositores
    {
        Task<List<UserModel>> SearchAllUsers();

        Task<UserModel> SearchUserId(int id);

        Task<UserModel> CreateNewUser(UserModel user);

        Task<UserModel> UpdateUser (UserModel user, int id);

        Task<bool> DeleteUser (int id);
    }
}