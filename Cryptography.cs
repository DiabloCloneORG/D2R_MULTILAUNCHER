using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace D2R_MULTILAUNCHER
{
    
    public static class Cryptography
    {
        public const int ENCRYPTION_KEYSIZE = 256;

        #region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";

        #endregion

        public static string Encrypt(string Data, string Password, string Vector, string Salt)
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(Vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(Salt);
            byte[] valueBytes = UTF8Encoding.UTF8.GetBytes(Data);
            byte[] encrypted = new byte[0];

            using (var aes = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes =
                                    new PasswordDeriveBytes(Password, saltBytes, _hash, _iterations);

                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                aes.Mode = CipherMode.CBC;
                aes.Key = keyBytes;
                aes.IV = vectorBytes;
                aes.Padding = PaddingMode.Zeros;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }

                aes.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        public static byte[] EncryptBytes(byte[] valueBytes, string Password, string Vector, string Salt)
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(Vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(Salt);
            byte[] encrypted = null;

            using (var aes = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes =
                                    new PasswordDeriveBytes(Password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                aes.Mode = CipherMode.CBC;
                aes.Key = keyBytes;
                aes.IV = vectorBytes;
                aes.Padding = PaddingMode.Zeros;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }

                aes.Clear();
            }

            return encrypted;
        }

        public static string Decrypt(string value, string _password, string _vector, string _salt) 
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;

            int decryptedByteCount = 0;

            using (Aes cipher = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(_password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;
                cipher.Key = keyBytes;
                cipher.Padding = PaddingMode.Zeros;
                cipher.IV = vectorBytes;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch 
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }

        public static byte[] DecryptBytes(byte[] valueBytes, string _password, string _vector, string _salt)
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);

            byte[] decrypted;

            int decryptedByteCount = 0;

            using (Aes cipher = Aes.Create())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(_password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;
                cipher.Key = keyBytes;
                cipher.IV = vectorBytes;
                cipher.Padding = PaddingMode.Zeros;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }

                cipher.Clear();
            }
            return decrypted;
        }


    }
}