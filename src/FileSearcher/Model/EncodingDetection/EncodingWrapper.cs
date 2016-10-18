using System.Text;

namespace FileSearcher.Model.EncodingDetection
{
    internal class EncodingWrapper : IEncodingFactory
    {
        private readonly Encoding[] _encodings;

        public EncodingWrapper(Encoding[] encodings)
        {
            _encodings = encodings;
        }

        public Encoding[] DetectEncoding(byte[] firstBytes)
        {
            return _encodings;
        }
    }
}
