namespace Jubanlabs.JubanShared.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using LZ4;
    using Murmur;

    public class CommonHelper
    {
        private HashAlgorithm murmur128;

        public static byte[] CompressSmallString(string str)
        {
            byte[] input = Encoding.UTF8.GetBytes(str);
            return CompressSmallString(input);
        }

        public static string UncompressSmallString(byte[] input)
        {
            return Encoding.UTF8.GetString(UncompressSmallStringToByteArray(input));
        }

        public static byte[] CompressSmallString(byte[] input)
        {
            if (input == null)
            {
                return null;
            }

            return LZ4Codec.Wrap(input, 0, input.Length);
        }

        public static byte[] UncompressSmallStringToByteArray(byte[] input)
        {
            return LZ4Codec.Unwrap(input);
        }

        public uint GetHash(string str)
        {
            if (this.murmur128 == null)
            {
                this.murmur128 = MurmurHash.Create32(managed: false);
            }

            return BitConverter.ToUInt32(this.murmur128.ComputeHash(Encoding.UTF8.GetBytes(str)), 0);
        }
    }
}