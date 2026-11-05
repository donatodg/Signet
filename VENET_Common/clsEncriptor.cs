namespace VENET_Common
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class clsEncriptor
    {
        public static void EncryptString(String sInputString, String OutputFileName, String Key)
        {
            FileStream fsExncrypted = new FileStream(OutputFileName, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            Des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            Des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            ICryptoTransform desencrypt = Des.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsExncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput;
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            bytearrayinput = encoding.GetBytes(sInputString);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
        }
        public static void EncryptFile(String InputFileName, String OutputFileName, String Key)
        {
            FileStream fsInput = new FileStream(InputFileName, FileMode.Open, FileAccess.Read);
            FileStream fsExncrypted = new FileStream(OutputFileName, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            Des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            Des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            ICryptoTransform desencrypt = Des.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsExncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput = new byte[fsInput.Length - 1];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
        }

        public static String DecryptFile(String InputFilename, String Key, String OutputFilename = "")
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(Key);

            FileStream fsread = new FileStream(InputFilename, FileMode.Open, FileAccess.Read);
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            String r = new StreamReader(cryptostreamDecr).ReadToEnd();
            fsread.Flush();
            fsread.Close();
            return r;
        }

    }
}
