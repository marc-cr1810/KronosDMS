using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Utils
{
	public class Base64
	{
		public static string To(byte[] data)
		{
			return Convert.ToBase64String(data);
		}

		public static byte[] From(string base64Text)
		{
			return Convert.FromBase64String(base64Text);
		}
	}
}
