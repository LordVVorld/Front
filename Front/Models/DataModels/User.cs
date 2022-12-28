using System.Collections.Generic;

namespace Front.Models
{
    public class User
    {
        public string? Id { get; set; }

        public List<UserSubscribe> Subscribes { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[] PasswordHash { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        public string AccessToken { get; set; } = null!;

        public string IconLink { get; set; } = null!;

        public decimal? Vallet { get; set; } = null!;
    }
}
