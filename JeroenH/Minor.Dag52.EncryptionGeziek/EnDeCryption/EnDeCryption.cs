using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EnDeCryption
{
    public class EnDeCryption
    {
        public static void Main(string[] args)
        {
            if(args[0]=="encrypt")
            {
                Encrypt(args);
            }
            else if(args[0] == "decrypt")
            {
                Decrypt(args);
            }
            else
            {
                Console.WriteLine("Not sure what you want me to do...");
            }           
        }



        private static void Encrypt(string[] args)
        {
            Console.WriteLine("encrypt");
            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(IV);
            rng.GetBytes(salt);

            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(args[3], salt);
            byte[] key = hasher.GetBytes(16);
            using (FileStream keyFile = File.Create(@"key.txt"))
            using (StreamWriter keyWriter = new StreamWriter(keyFile))
            {
                keyWriter.Write(key);

                using (FileStream inputStream = File.OpenRead(args[1]))
                using (StreamReader reader = new StreamReader(inputStream))
                {
                    Console.WriteLine("I Got Here!");


                    using (FileStream outputStream = File.Create(args[2]))
                    using (StreamWriter startWriter = new StreamWriter(outputStream))
                    {

                        startWriter.WriteLine(salt);
                        startWriter.WriteLine(IV);

                        Console.WriteLine("I Got Here!");

                    }
                    using (FileStream EncryptedFile = File.OpenWrite(args[2]))

                    using (Aes algorithm = Aes.Create())
                    using (CryptoStream encryptedStream = new CryptoStream(
                        EncryptedFile,
                        algorithm.CreateEncryptor(key, IV),
                        CryptoStreamMode.Write))
                    using (StreamWriter writer = new StreamWriter(encryptedStream))
                    {
                        Console.WriteLine("I Got Here!");



                        writer.Write(reader.ReadToEnd());
                    }
                    
                }
            }
            Console.WriteLine("You have been encrypted.");
        }

        private static void Decrypt(string[] args)
        {
            Console.WriteLine("decrypt");

            using (FileStream inputStream = File.OpenRead(args[1]))
            using (StreamReader reader = new StreamReader(inputStream))
            {


                string saltstring = reader.ReadLine();

                byte[] salt = new byte[saltstring.Length * sizeof(char)];
                System.Buffer.BlockCopy(saltstring.ToCharArray(), 0, salt, 0, salt.Length);



                string IVstring = reader.ReadLine();
                Console.WriteLine(IVstring);

                byte[] IV = new byte[IVstring.Length * sizeof(char)];

                System.Buffer.BlockCopy(IVstring.ToCharArray(), 0, IV, 0, IV.Length);

                Console.WriteLine("I Got Here!");


                Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(args[3], salt);
                byte[] key = hasher.GetBytes(16);

                using (Aes algorithm = Aes.Create())
                using (CryptoStream decryptingStream = new CryptoStream(
                                    inputStream,
                                    algorithm.CreateDecryptor(key, IV),
                                    CryptoStreamMode.Read))
                using (StreamReader readerDecrypt = new StreamReader(decryptingStream))
                {
                    using (FileStream outputStream = File.Create(args[2]))
                    using (StreamWriter writer = new StreamWriter(outputStream))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
            }
            Console.WriteLine("You have been decrypted.");
        }
    }
}
