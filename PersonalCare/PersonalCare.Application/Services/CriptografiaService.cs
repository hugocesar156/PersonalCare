using System.Security.Cryptography;
using System.Text;

namespace PersonalCare.Application.Services
{
    public class CriptografiaService
    {
        public static (string senhaHash, string salt) CriptografarSenha(string senha)
        {
            byte[] saltBytes = GerarSalt();
            string salt = Convert.ToBase64String(saltBytes);

            using SHA256 sha256 = SHA256.Create();

            byte[] combinedBytes = CombinarBytes(Encoding.UTF8.GetBytes(senha), saltBytes);
            byte[] hashedBytes = sha256.ComputeHash(combinedBytes);

            var builder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                builder.Append(hashedBytes[i].ToString("x2"));

            return (builder.ToString(), salt);
        }

        public static bool VerificarSenha(string senha, string salt, string senhaHash)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using SHA256 sha256 = SHA256.Create();

            byte[] combinedBytes = CombinarBytes(Encoding.UTF8.GetBytes(senha), saltBytes);
            byte[] hashedBytes = sha256.ComputeHash(combinedBytes);

            var builder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                builder.Append(hashedBytes[i].ToString("x2"));

            return builder.ToString() == senhaHash;
        }

        private static byte[] CombinarBytes(byte[] bytes1, byte[] bytes2)
        {
            byte[] bytes = new byte[bytes1.Length + bytes2.Length];

            Buffer.BlockCopy(bytes1, 0, bytes, 0, bytes1.Length);
            Buffer.BlockCopy(bytes2, 0, bytes, bytes1.Length, bytes2.Length);

            return bytes;
        }

        private static byte[] GerarSalt()
        {
            byte[] salt = new byte[16];

            RandomNumberGenerator.Create().GetBytes(salt);
            return salt;
        }
    }
}
