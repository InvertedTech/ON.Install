using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ON.Crypto
{
    public static class AesHelper
    {
        public static void Decrypt(in byte[] key, in byte[] iv, in byte[] encryptedMessage, out byte[] plaintextMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = iv;

                // Encrypt the message
                using (MemoryStream plaintext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                    cs.Close();
                    plaintextMessage = plaintext.ToArray();
                }
            }
        }

        public static void Encrypt(in byte[] key, out byte[] iv, in byte[] plaintextMessage, out byte[] encryptedMessage)
        {
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                iv = aes.IV;

                // Encrypt the message
                using (MemoryStream ciphertext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                    cs.Close();
                    encryptedMessage = ciphertext.ToArray();
                }
            }
        }
    }
}
