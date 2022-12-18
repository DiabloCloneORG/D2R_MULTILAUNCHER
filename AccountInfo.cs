using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace D2R_MULTILAUNCHER
{
    [Serializable]
    class AccountInfo : ICloneable
    {
        public string ProfileName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string IV { get; set; }

        public void WriteToBinaryFile(string filePath, string masterPassword, string Salt, bool append = false)
        {
            if (this==null) { return; }

            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                AccountInfo ainfo = new AccountInfo
                {
                    ProfileName = this.ProfileName,
                    Password = Cryptography.Encrypt(this.Password, masterPassword, this.IV, Salt),
                    EmailAddress = Cryptography.Encrypt(this.EmailAddress, masterPassword, this.IV, Salt),
                    IV = this.IV
                };

                JsonSerializerOptions jso = new JsonSerializerOptions();
                jso.WriteIndented = true;
                jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                JsonSerializer.Serialize(stream, ainfo, jso);
            }
        }

        public void ReadFromBinaryFile(string filePath, string masterPassword, string Salt)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {

                AccountInfo ainfo = (AccountInfo)JsonSerializer.Deserialize(stream, typeof(AccountInfo));
                this.IV = ainfo.IV;
                this.ProfileName = ainfo.ProfileName;
                this.Password = Cryptography.Decrypt(ainfo.Password, masterPassword, ainfo.IV, Salt).TrimEnd('\0');
                this.EmailAddress = Cryptography.Decrypt(ainfo.EmailAddress, masterPassword, ainfo.IV, Salt).TrimEnd('\0'); ;
                
                System.GC.Collect();
            }
            return;
        }

        public static AccountInfo ReadFromBinaryFile<T>(string filePath, string masterPassword, string Salt)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                AccountInfo ainfo = (AccountInfo)JsonSerializer.Deserialize(stream, typeof(AccountInfo));
                ainfo.Password = Cryptography.Decrypt(ainfo.Password, masterPassword, ainfo.IV, Salt).TrimEnd('\0'); ;
                ainfo.EmailAddress = Cryptography.Decrypt(ainfo.EmailAddress, masterPassword, ainfo.IV, Salt).TrimEnd('\0'); ;

                return ainfo;
            }
        }

        public object Clone() { return this.MemberwiseClone(); }


        public void generateNewIV()
        {
            this.IV = _generateRandomIvString(16);
        }

        private string _generateRandomIvString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "1234567890";
            return _generateRandomIvString(length, alphanumericCharacters.ToCharArray());
        }
        private string _generateRandomIvString(int length, char[] characterArray)
        {
            if (length < 0) { throw new System.ArgumentException("length must not be negative", "length"); }
            if (length > int.MaxValue / 8) { throw new System.ArgumentException("length is too big", "length"); } // 250 million chars should to be enough for anybody :D
            if (characterArray.Length == 0) { throw new System.ArgumentException("characterArray must not be empty", "characterArray"); }

            var bytes = new byte[length * 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = System.BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

    }
}
