using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DPHGallery.Classes
{
	public class Base64Utils
	{
		public static string Encode(string input)
		{
			return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
		}

		public static string Decode(string input)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(input));
		}
	}
}