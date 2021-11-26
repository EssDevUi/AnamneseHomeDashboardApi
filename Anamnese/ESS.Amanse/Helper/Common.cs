using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ESS.Amanse.Helper
{
    public static class Common
    {
        //public readonly IConfiguration _configuration;
        //public Common(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public static string UploadPdf(byte[] pdfFile,string filename)
        {
            string path = "PatientsPdfForms";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string uniqeFileName = filename + ".pdf";
            string FilePath = Path.Combine(path, uniqeFileName);
            File.WriteAllBytes(FilePath, pdfFile);


            return uniqeFileName;

        }
        public static String Encryption(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            String Password = "CSC";
            Byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            Byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            Byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            String EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }
        public static String Decryption(string TextToBeDecrypted)
        {
            TextToBeDecrypted = TextToBeDecrypted.Replace(" ", "+");
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            String Password = "CSC";
            String DecryptedData;
            try
            {
                Byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);
                Byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                Byte[] PlainText = new Byte[EncryptedData.Length];
                Int32 DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }
            return DecryptedData;
        }

        public static string EncryptPassword(string Password)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] hashedPassword = mySHA256.ComputeHash(encoder.GetBytes(Password));
            return Convert.ToBase64String(hashedPassword);
        }

        public static string RandomDigits(int length)
        {
            //var random = new Random();
            //string s = string.Empty;
            //for (int i = 0; i < length; i++)
            //    s = String.Concat(s, random.Next(10).ToString());
            //return s;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
   
        public class DropdownList
        {
            public long Value { get; set; }
            public string Text { get; set; }
        }
        public class DropdownListForText
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
       
    }
}
