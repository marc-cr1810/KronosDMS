using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Utils
{
    public class WSHelper
    {
        /// <summary>
        /// Compresses and outputs a base64 format of the byte data
        /// </summary>
        /// <param name="bytes">The byte data to wrap</param>
        /// <returns>A base64 string</returns>
        public static string Wrap(byte[] bytes)
        {
            return Base64.To(LZMAHelper.CompressLZMA(bytes));
        }

        /// <summary>
        /// Converts from base64 and decompresses the byte data
        /// </summary>
        /// <param name="data">The base64 data to unwrap</param>
        /// <returns></returns>
        public static byte[] UnWrap(string data)
        {
            return LZMAHelper.DecompressLZMA(Base64.From(data));
        }
    }
}
