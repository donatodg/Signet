namespace VENET_Common
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class Encriptor
    {
        public static void EncryptString(string sInputString, string OutputFileName, string Key)
        {
            FileStream fsExncrypted = new FileStream(OutputFileName, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            Des.Key = Encoding.ASCII.GetBytes(Key);
            Des.IV = Encoding.ASCII.GetBytes(Key);
            ICryptoTransform desencrypt = Des.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsExncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput;
            UTF8Encoding encoding = new UTF8Encoding();
            bytearrayinput = encoding.GetBytes(sInputString);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
        }
        public static void EncryptFile(string InputFileName, string OutputFileName, string Key)
        {
            FileStream fsInput = new FileStream(InputFileName, FileMode.Open, FileAccess.Read);
            FileStream fsExncrypted = new FileStream(OutputFileName, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider Des = new DESCryptoServiceProvider();
            Des.Key = Encoding.ASCII.GetBytes(Key);
            Des.IV = Encoding.ASCII.GetBytes(Key);
            ICryptoTransform desencrypt = Des.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsExncrypted, desencrypt, CryptoStreamMode.Write);
            byte[] bytearrayinput = new byte[fsInput.Length - 1];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
        }

        public static string DecryptFile(string InputFilename, string Key, string OutputFilename = "")
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = Encoding.ASCII.GetBytes(Key);
            DES.IV = Encoding.ASCII.GetBytes(Key);

            FileStream fsread = new FileStream(InputFilename, FileMode.Open, FileAccess.Read);
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            string r = new StreamReader(cryptostreamDecr).ReadToEnd();
            fsread.Flush();
            fsread.Close();
            return r;
        }

        public static string EncryptCadena(string Cadena)
        {
            string Key = ((char)78).ToString() + ((char)100).ToString() + ((char)74).ToString() + ((char)100).ToString() + ((char)73).ToString() + ((char)97).ToString() + ((char)85).ToString() + ((char)100).ToString();

            byte[] Llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.

            byte[] Arreglo = Encoding.UTF8.GetBytes(Cadena); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            Llave = Md5.ComputeHash(Encoding.UTF8.GetBytes(Key));
            Md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider Tripledes = new TripleDESCryptoServiceProvider();
            Tripledes.Key = Llave;
            Tripledes.Mode = CipherMode.ECB;
            Tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform Convertir = Tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] Resultado = Convertir.TransformFinalBlock(Arreglo, 0, Arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            Tripledes.Clear();

            return Convert.ToBase64String(Resultado, 0, Resultado.Length); // Convertimos la cadena y la regresamos.
        }

        // Función para descifrar una cadena.
        public static string DecryptCadena(string Cadena)
        {
            string Key = ((char)78).ToString() + ((char)100).ToString() + ((char)74).ToString() + ((char)100).ToString() + ((char)73).ToString() + ((char)97).ToString() + ((char)85).ToString() + ((char)100).ToString();

            byte[] Llave;

            byte[] Arreglo = Convert.FromBase64String(Cadena); // Arreglo donde guardaremos la cadena descovertida.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            Llave = Md5.ComputeHash(Encoding.UTF8.GetBytes(Key));
            Md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider Tripledes = new TripleDESCryptoServiceProvider();
            Tripledes.Key = Llave;
            Tripledes.Mode = CipherMode.ECB;
            Tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform Convertir = Tripledes.CreateDecryptor();
            byte[] Resultado = Convertir.TransformFinalBlock(Arreglo, 0, Arreglo.Length);
            Tripledes.Clear();

            return Encoding.UTF8.GetString(Resultado); // Obtenemos la cadena
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }

        //public static string Encrypt(string toEncrypt, bool useHashing)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

        //    // Get the key from config file
        //    string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        //    //System.Windows.Forms.MessageBox.Show(key);
        //    //If hashing use get hashcode regards to your key
        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //Always release the resources and flush data
        //        // of the Cryptographic service provide. Best Practice

        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes.
        //    //We choose ECB(Electronic code Book)
        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)

        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    //transform the specified region of bytes array to resultArray
        //    byte[] resultArray =
        //      cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor
        //    tdes.Clear();
        //    //Return the encrypted data into unreadable string format
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}

        //public static string Decrypt(string cipherString, bool useHashing)
        //{
        //    byte[] keyArray;
        //    //get the byte code of the string

        //    byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        //    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        //    //Get your key from config file to open the lock!
        //    string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

        //    if (useHashing)
        //    {
        //        //if hashing was used get the hash code with regards to your key
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //release any resource held by the MD5CryptoServiceProvider

        //        hashmd5.Clear();
        //    }
        //    else
        //    {
        //        //if hashing was not implemented get the byte code of the key
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);
        //    }

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes. 
        //    //We choose ECB(Electronic code Book)

        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)
        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor                
        //    tdes.Clear();
        //    //return the Clear decrypted TEXT
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}
    }
}
