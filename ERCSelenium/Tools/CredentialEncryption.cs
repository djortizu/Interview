using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERC.Selenium.Tools
{
    public class CredentialEncryption
    {
        public static byte[] GetHashKey(string hashKey)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            string salt = "I am a nice little salt";
            byte[] saltBytes = encoder.GetBytes(salt);
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            return rfc.GetBytes(16);
        }

        public static string Encrypt(string dataToEncrypt)
        {
            AesManaged encryptor = new AesManaged();
            encryptor.Key = GetHashKey("Key");
            encryptor.IV = GetHashKey("IV");
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }

        public static string Decrypt(string encryptedString)
        {
            try
            {
                AesManaged decryptor = new AesManaged();
                byte[] encryptedData = Convert.FromBase64String(encryptedString);
                decryptor.Key = GetHashKey("Key");
                decryptor.IV = GetHashKey("IV");
                using (MemoryStream decryptionStream = new MemoryStream())
                {
                    using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        decrypt.Write(encryptedData, 0, encryptedData.Length);
                        decrypt.Flush();
                        decrypt.Close();
                        byte[] decryptedData = decryptionStream.ToArray();
                        return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Environment.Exit(1);
                return null;
            }
        }
    }
}
