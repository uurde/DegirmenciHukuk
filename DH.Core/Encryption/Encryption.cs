using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DH.Core.Encryption
{
    public class Encryption : IEncryption
    {
        private string _key;
        private byte[] _salt;

        public Encryption(string key, byte[] salt)
        {
            _key = key;
            _salt = salt;
        }

        public Encryption()
        {
            _key = "xx&b[m-u797B*YMe/L+YPhKa#(g^g_@fO8Ai|*M:LY#q8>K+YijTItAIa{s7(%]w9aS\\]22_z=34.L+'6Tg(vz{wBXBnt\\FKyxBVU";
            _salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        }

        public string Encrypt(string openStr)
        {
            byte[] clearData = Encoding.Unicode.GetBytes(openStr);
            byte[] encryptedData = EncryptInternal(clearData, _key, _salt);
            var encryptedStr = Convert.ToBase64String(encryptedData);
            return encryptedStr;
        }

        public string Decrypt(string encryptedString)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedString);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(_key,
            new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Encoding.Unicode.GetString(decryptedData);
        }

        private byte[] EncryptInternal(byte[] clearData, string key, byte[] salt)
        {
            using (PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(key, salt))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Rijndael alg = Rijndael.Create();
                    alg.Key = passwordDeriveBytes.GetBytes(32);
                    alg.IV = passwordDeriveBytes.GetBytes(16);
                    using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearData, 0, clearData.Length);
                        cs.Close();
                        byte[] encryptedData = ms.ToArray();
                        return encryptedData;
                    }
                }
            }
        }

        public byte[] Decrypt(byte[] cipherData, byte[] key, byte[] salt)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = salt;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }
    }
}
