using System.Text;

namespace FileSearcher.Model.EncodingDetection
{
    internal interface IEncodingFactory
    {
        Encoding[] DetectEncoding(byte[] firstBytes);
    }
}
