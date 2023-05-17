using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VigProject_Api.Utility
{
    public class CryptorEngine
    {
        private static byte[] _keyByte = { };
        //Default Key
        private static string _key = "Pass@1803#";
        //Default initial vector
        private static byte[] _ivByte = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "VIGPLANET @1803$";
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "VIGPLANET @1803$";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }



        #region SHA 512  Key Generation
        public static string GenerateSHA512String(string inputString, int length)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash, length);
        }

        private static string GetStringFromHash(byte[] hash, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
        #endregion
        public static byte[] EncryptAES(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }
        public static string DecryptAES(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                //aes.Mode = CipherMode.CBC;
                //aes.Padding = PaddingMode.PKCS7;
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (System.IO.MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        public static string generateIV(int length)
        {
            string hex = "";
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var aesKey = new byte[16];
            provider.GetBytes(aesKey);
            StringBuilder result = new StringBuilder();
            foreach (byte x in aesKey)
            {
                // hex += String.Format("{0:x2}", x);
                result.Append(String.Format("{0:x2}", x));
            }

            if (length > result.ToString().Length)
            {
                hex = result.ToString();
            }
            else
            {
                hex = result.ToString().Substring(0, length);
            }
            return hex;
        }



        #region SHA 256 Testing For Android
        public static string GetSha256FromString(string strData, int length)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            StringBuilder result = new StringBuilder();
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                // hex += String.Format("{0:x2}", x);
                result.Append(String.Format("{0:x2}", x));
            }

            if (length > result.ToString().Length)
            {
                hex = result.ToString();
            }
            else
            {
                hex = result.ToString().Substring(0, length);
            }
            return hex;
        }

        public static string generateIV256(int length)
        {
            string hex = "";
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var aesKey = new byte[16];
            provider.GetBytes(aesKey);
            StringBuilder result = new StringBuilder();
            foreach (byte x in aesKey)
            {
                // hex += String.Format("{0:x2}", x);
                result.Append(String.Format("{0:x2}", x));
            }

            if (length > result.ToString().Length)
            {
                hex = result.ToString();
            }
            else
            {
                hex = result.ToString().Substring(0, length);
            }
            return hex;
        }
        #endregion

    }
}
