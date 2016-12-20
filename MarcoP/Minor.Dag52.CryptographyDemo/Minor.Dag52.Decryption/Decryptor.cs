using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Minor.Dag52.Decryption
{
    public class Decryptor
    {
        public static void Main(string[] args)
        {
            //byte[] key = { 0x01, 0x23, 0x45, 0x67, 0x89, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xAB, 0xCD, 0xEF, 0x01, 0xCD, 0xEF };
            //byte[] IV = { 0x67, 0x89, 0xAB, 0xAB, 0xCD, 0x01, 0x23, 0x45, 0x67, 0x89, 0x23, 0x45, 0xEF, 0x01, 0xCD, 0xEF };

            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(IV);
            rng.GetBytes(salt);
            string password = "geheim";
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, salt);
            byte[] key = hasher.GetBytes(16);

            using (FileStream inputStream = File.OpenRead(@"..\Encryptor.bin"))
            using (Aes algorithm = Aes.Create())
            using (CryptoStream decryptingStream = new CryptoStream(
                                inputStream,
                                algorithm.CreateDecryptor(key, IV),
                                CryptoStreamMode.Read))
            using (StreamReader reader = new StreamReader(decryptingStream))
            {
                using (FileStream outputStream = File.Create(@"EncryptorDecrypted.cs"))
                using (StreamWriter writer = new StreamWriter(outputStream))
                {
                    writer.Write(reader.ReadToEnd());
                }
            }
            Console.WriteLine("You have been decrypted.");
        }
    }
}
