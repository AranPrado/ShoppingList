using BCrypt.Net;

namespace ShoppingList.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public Guid guid{ get; set; } = Guid.NewGuid();

        public required string Name { get; set; }

        public required string Email { get; set; }

       private string _passwordHash;
        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value); // Usando BCrypt para gerar o hash
        }

        public string? Privilege { get; set; }

    }
}