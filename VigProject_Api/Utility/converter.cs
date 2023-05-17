using System;
using System.Data;
using System.Configuration;
using System.Web;
using  System.IO;
using  System.Xml;
using  System.Text;
using System.Security.Cryptography;


/// <summary>
/// Summary description for converter
/// </summary>
public class converter
{
	public converter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool CheckDate()
    {
        string CheckDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
        string EndDate = "30-Apr-2012";
        string StartDate = "20-Apr-2010";
        if (CheckDate.CompareTo(EndDate) == -1)
        {
            if (CheckDate.CompareTo(StartDate) == -1)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
    public static string Decrypt(string TextToBeDecrypted)
    {

        RijndaelManaged RijndaelCipher = new RijndaelManaged();
        string Password = "CSC";
        string DecryptedData;
        try
        {
            byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            //Making of the key for decryption
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric Rijndael decryptor object.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            //Defines the cryptographics stream for decryption.THe stream contains decrpted data
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
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


    public static string Encrypt(string TextToBeEncrypted)
    {
        RijndaelManaged RijndaelCipher = new RijndaelManaged();
        string Password = "CSC";
        byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
        //Creates a symmetric encryptor object. 
        ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
        MemoryStream memoryStream = new MemoryStream();
        //Defines a stream that links data streams to cryptographic transformations
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(PlainText, 0, PlainText.Length);
        //Writes the final state and clears the buffer
        cryptoStream.FlushFinalBlock();
        byte[] CipherBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        string EncryptedData = Convert.ToBase64String(CipherBytes);
        return EncryptedData;

    }


   
}
