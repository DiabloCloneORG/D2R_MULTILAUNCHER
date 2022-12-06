using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R_MULTILAUNCHER
{
    [Serializable]
    class AccountInfo : ICloneable
    {
        public string ProfileName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public byte[] GameRegistryData { get; set; }
        public byte[] BamRegistryData { get; set; }

        public string IV { get; set; }

        public static void WriteToBinaryFile<T>(string filePath, string masterPassword, string Salt, AccountInfo objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                AccountInfo ainfo = new AccountInfo
                {
                    ProfileName = objectToWrite.ProfileName,
                    IV = objectToWrite.IV,
                    Password = Cryptography.Encrypt(objectToWrite.Password, masterPassword, objectToWrite.IV, Salt),
                    EmailAddress = Cryptography.Encrypt(objectToWrite.EmailAddress, masterPassword, objectToWrite.IV, Salt),
                    GameRegistryData = Cryptography.EncryptBytes(objectToWrite.GameRegistryData, masterPassword, objectToWrite.IV, Salt),
                    BamRegistryData = Cryptography.EncryptBytes(objectToWrite.BamRegistryData, masterPassword, objectToWrite.IV, Salt)
                };
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ainfo);
            }
        }

        public void WriteToBinaryFile(string filePath, string masterPassword, string Salt, bool append = false)
        {
            if (this==null) { return; }

            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                AccountInfo ainfo = new AccountInfo
                {
                    ProfileName = this.ProfileName,
                    IV = this.IV,
                    Password = Cryptography.Encrypt(this.Password, masterPassword, this.IV, Salt),
                    EmailAddress = Cryptography.Encrypt(this.EmailAddress, masterPassword, this.IV, Salt),
                    GameRegistryData = this.GameRegistryData == null ? null : Cryptography.EncryptBytes(this.GameRegistryData, masterPassword, this.IV, Salt),
                    BamRegistryData = this.BamRegistryData == null ? null : Cryptography.EncryptBytes(this.BamRegistryData, masterPassword, this.IV, Salt)
                };
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ainfo);
            }
        }

        public void ReadFromBinaryFile(string filePath, string masterPassword, string Salt)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                AccountInfo ainfo = (AccountInfo)binaryFormatter.Deserialize(stream);
                this.IV = ainfo.IV;
                this.ProfileName = ainfo.ProfileName;
                this.Password = Cryptography.Decrypt(ainfo.Password, masterPassword, ainfo.IV, Salt);
                this.EmailAddress = Cryptography.Decrypt(ainfo.EmailAddress, masterPassword, ainfo.IV, Salt);
                this.GameRegistryData = Cryptography.DecryptBytes(ainfo.GameRegistryData, masterPassword, ainfo.IV, Salt);
                this.BamRegistryData = Cryptography.DecryptBytes(ainfo.BamRegistryData, masterPassword, ainfo.IV, Salt);
                ainfo = null;

                System.GC.Collect();
            }
            return;
        }

        public static AccountInfo ReadFromBinaryFile<T>(string filePath, string masterPassword, string Salt)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                AccountInfo ainfo = (AccountInfo)binaryFormatter.Deserialize(stream);
                ainfo.Password = Cryptography.Decrypt(ainfo.Password, masterPassword, ainfo.IV, Salt);
                ainfo.EmailAddress = Cryptography.Decrypt(ainfo.EmailAddress, masterPassword, ainfo.IV, Salt);
                ainfo.GameRegistryData = Cryptography.DecryptBytes(ainfo.GameRegistryData, masterPassword, ainfo.IV, Salt);
                ainfo.BamRegistryData = Cryptography.DecryptBytes(ainfo.BamRegistryData, masterPassword, ainfo.IV, Salt);

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
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(bytes);
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
