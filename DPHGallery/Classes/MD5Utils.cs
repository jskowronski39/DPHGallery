using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DPHGallery.Classes
{
	public class MD5Utils
	{
		/// <summary>
		/// Returns MD5 hash byte array from given data stream.
		/// </summary>
		/// <param name="stream">Data stream</param>
		/// <returns>MD5 hash byte array</returns>
		public static byte[] GetMD5ByteHashFromStream(Stream stream)
		{
			stream.Position = 0; // Just to be sure...

			BinaryReader br = new BinaryReader(stream);
			byte[] buffer = br.ReadBytes((int)stream.Length);

			MD5 md5 = MD5.Create();
			return md5.ComputeHash(buffer);
		}

		/// <summary>
		/// Converts MD5 hash byte array to it's string representation.
		/// 
		/// Shamelessly taken from MS docs
		/// https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=netframework-4.7.2
		/// </summary>
		/// <param name="md5Hash">MD5 hash byte array</param>
		/// <returns>MD5 hash string</returns>
		public static string MD5ByteHashToString(byte[] md5Hash)
		{
			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < md5Hash.Length; i++)
			{
				sBuilder.Append(md5Hash[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}
	}
}