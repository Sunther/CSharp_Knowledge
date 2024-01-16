using System.Buffers;

namespace EfficientSearchValue
{
    public class Constants
    {
        const string _base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static char[] Base64 = [.. _base64Chars];
        public static SearchValues<char> Base64SearchValues = SearchValues.Create(_base64Chars);
    }
}
