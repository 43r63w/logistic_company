namespace Application.Configuring.Hasher
{
    public static class PasswordHash
    {
        public static string HashPassword(string password) 
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        
        public static bool CheckPassword(string password, string hash) 
           => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}
