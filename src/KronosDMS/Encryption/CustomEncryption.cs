using System;
using System.Security.Cryptography;
using System.Text;

namespace KronosDMS.Encryption
{
    public class CustomEncryption
    {
		private static string key = "eKR8U5ErQR0pRv4CKhgytusm32kcmbiN";

		public static string Encrypt(byte[] inputBytes)
		{
			try
			{
				byte[] array = null;
				array = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
				return Convert.ToBase64String(new TripleDESCryptoServiceProvider
				{
					Key = array,
					Mode = CipherMode.ECB
				}.CreateEncryptor().TransformFinalBlock(inputBytes, 0, inputBytes.Length));
			}
			catch (Exception ex)
			{
				_ = ex.Message;
				throw;
			}
		}

		public static string Encrypt(string plainText)
		{
			return Encrypt(Encoding.ASCII.GetBytes(plainText));
		}

		public static string Decrypt(string encrypted)
		{
			byte[] array = null;
			try
			{
				array = Convert.FromBase64String(encrypted);
				byte[] array2 = null;
				array2 = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
				TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
				tripleDESCryptoServiceProvider.Key = array2;
				tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
				return Encoding.ASCII.GetString(tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length));
			}
			catch (FormatException)
			{
				return encrypted;
			}
			catch (Exception ex2)
			{
				_ = ex2.Message;
				throw;
			}
		}
	}
}
