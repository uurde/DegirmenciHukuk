using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Core.Encryption
{
    public interface IEncryption
    {
        string Encrypt(string openStr);
        string Decrypt(string encryptedStr);
    }
}
