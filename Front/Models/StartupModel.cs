using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Front.Models
{
    public class StartupModel
    {
        public class LoginModel
        {
            [EmailAddress]
            public string Email { get; set; } = null!;

            public string Password { get; set; } = null!;
        }

        public static bool IsValidEmail(string? email) =>
            email is not null && new EmailAddressAttribute().IsValid(email);


        public static bool IsValidPassword(string? password)
        {
            if (password is null)
            {
                return false;
            }

            if (password.Length < 8 || password.Length > 25)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
