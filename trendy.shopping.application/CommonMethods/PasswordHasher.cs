using System.Security.Cryptography;

namespace trendy.shopping.application.CommonMethods
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string RequestPassword);
    }
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 128 / 8;
        private const int Iteration = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delimiter = ';';

        public string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, _hashAlgorithmName, KeySize);

            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Verify(string passwordHash, string RequestPassword)
        {
            var elements = passwordHash.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hsah = Convert.FromBase64String(elements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(RequestPassword, salt, Iteration, _hashAlgorithmName, KeySize);

            return CryptographicOperations.FixedTimeEquals(hsah, hashInput);
        }
    }
}
