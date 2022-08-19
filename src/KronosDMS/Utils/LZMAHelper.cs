using System;
using System.IO;
using SevenZip;
using SevenZip.Compression.LZMA;

namespace KronosDMS.Utils
{
    public static class LZMAHelper
    {
        private static readonly int dictionary = 65536;

        private static readonly bool eos = true;

        private static readonly CoderPropID[] propIDs = new CoderPropID[8]
        {
            CoderPropID.DictionarySize,
            CoderPropID.PosStateBits,
            CoderPropID.LitContextBits,
            CoderPropID.LitPosBits,
            CoderPropID.Algorithm,
            CoderPropID.NumFastBytes,
            CoderPropID.MatchFinder,
            CoderPropID.EndMarker
        };

        private static readonly object[] properties = new object[8] { dictionary, 2, 3, 0, 2, 8, "bt4", eos };

        public static byte[] CompressLZMA(byte[] inputBytes)
        {
            MemoryStream memoryStream2 = new MemoryStream(inputBytes);
            MemoryStream memoryStream = new MemoryStream();
            Encoder encoder = new Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(memoryStream);
            long length = memoryStream2.Length;
            for (int i = 0; i < 8; i++)
            {
                memoryStream.WriteByte((byte)(length >> 8 * i));
            }
            encoder.Code(memoryStream2, memoryStream, -1L, -1L, null);
            return memoryStream.ToArray();
        }

        public static byte[] CompressLZMAStream(MemoryStream inStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            Encoder encoder = new Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(memoryStream);
            long length = inStream.Length;
            for (int i = 0; i < 8; i++)
            {
                memoryStream.WriteByte((byte)(length >> 8 * i));
            }
            encoder.Code(inStream, memoryStream, -1L, -1L, null);
            return memoryStream.ToArray();
        }

        public static byte[] DecompressLZMA(byte[] inputBytes)
        {
            Decoder decoder = new Decoder();
            try
            {
                MemoryStream memoryStream = new MemoryStream(inputBytes);
                memoryStream.Seek(0L, SeekOrigin.Begin);
                MemoryStream memoryStream2 = new MemoryStream();
                byte[] array = new byte[5];
                if (memoryStream.Read(array, 0, 5) != 5)
                {
                    throw new Exception("Decompression Error");
                }
                long num = 0L;
                for (int i = 0; i < 8; i++)
                {
                    int num2 = memoryStream.ReadByte();
                    num |= (long)((ulong)(byte)num2 << 8 * i);
                }
                decoder.SetDecoderProperties(array);
                long inSize = memoryStream.Length - memoryStream.Position;
                decoder.Code(memoryStream, memoryStream2, inSize, num, null);
                memoryStream.Dispose();
                return memoryStream2.ToArray();
            }
            catch
            {
                throw;
            }
        }

        public static MemoryStream DecompressLZMAStream(byte[] inputBytes)
        {
            Decoder decoder = new Decoder();
            try
            {
                MemoryStream memoryStream = new MemoryStream(inputBytes);
                memoryStream.Seek(0L, SeekOrigin.Begin);
                MemoryStream memoryStream2 = new MemoryStream();
                byte[] array = new byte[5];
                if (memoryStream.Read(array, 0, 5) != 5)
                {
                    throw new Exception("Decompression Error");
                }
                long num = 0L;
                for (int i = 0; i < 8; i++)
                {
                    int num2 = memoryStream.ReadByte();
                    num |= (long)((ulong)(byte)num2 << 8 * i);
                }
                decoder.SetDecoderProperties(array);
                long inSize = memoryStream.Length - memoryStream.Position;
                decoder.Code(memoryStream, memoryStream2, inSize, num, null);
                return memoryStream2;
            }
            catch
            {
                throw;
            }
        }
    }
}