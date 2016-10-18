using System.Text;

namespace FileSearcher.Model.EncodingDetection
{
    internal class EncodingDetector : IEncodingFactory
    {
        public Encoding[] DetectEncoding(byte[] firstBytes)
        {
            /*
                FE FF = UTF16 (BIG), every char 2 bytes
                FF FE = UTF16 (little), every char 2 bytes
                EF BB BF = UTF8 with BOM
             */

            // Return as ANSII by default
            Encoding encoding = null;
            int b;

            // UTF8 with BOM
            if (firstBytes.Length >= 3)
            {
                b = (firstBytes[0] << 16) | (firstBytes[1] << 8) | firstBytes[2];
                if ((b & 0x00FFFFFF) == 0x00EFBBBF)
                    encoding = Encoding.UTF8;
            }
            // UTF16
            if (encoding == null && firstBytes.Length >= 2)
            {
                b = (firstBytes[0] << 8) | firstBytes[1];
                if ((b & 0x0000FFFF) == 0x0000FFFE)
                    encoding = Encoding.Unicode;
                else if ((b & 0x0000FFFF) == 0x0000FEFF)
                    encoding = Encoding.BigEndianUnicode;
            }
            return new[] { encoding ?? Encoding.Default };
        }
    }
}
