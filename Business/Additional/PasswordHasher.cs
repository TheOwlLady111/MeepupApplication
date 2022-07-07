using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace Business.Additional
{
    public class PasswordHasher
    {
        private readonly IConfiguration _configuration;

        public PasswordHasher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GeneratePasswordHash(string password)
        {
            byte[] passwordBytes = Encoding.Default.GetBytes(password + _configuration.GetSection("Salt").Value);
            var hashBytes = SHA256.Create().ComputeHash(passwordBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
