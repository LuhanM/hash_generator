using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace hash
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Digite a string para realizar o calculo de hash:");
                string sText = Console.ReadLine();

                Console.WriteLine("MD5: " + GetMD5(sText));
                Console.WriteLine("SHA256: " + GetSHA256(sText));
                Console.WriteLine("SHA512: " + GetSHA512(sText));
                Console.WriteLine("SHA1: " + GetSHA1(sText));
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static string GetMD5(string input)
        {
            using (MD5 hash = MD5.Create())
            {
                return GetHash(hash, input);
            }
        }
        static string GetSHA256(string input)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return GetHash(hash, input);
            }
        }
        static string GetSHA512(string input)
        {
            using (SHA512 hash = SHA512.Create())
            {
                return GetHash(hash, input);
            }
        }
        static string GetSHA1(string input)
        {
            using (SHA1 hash = SHA1.Create())
            {
                return GetHash(hash, input);
            }
        }
        static string GetHash(HashAlgorithm hash, string input)
        {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
