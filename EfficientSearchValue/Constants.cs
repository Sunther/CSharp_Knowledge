using System.Buffers;
using System.Collections.Frozen;

namespace EfficientSearchValue
{
    public static class Constants
    {
        private const string _base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        public static char[] Base64 = [.. _base64Chars];
        public static SearchValues<char> Base64SearchValues = SearchValues.Create(_base64Chars);

        public static readonly FrozenSet<char> Base64Frozen = Base64.ToFrozenSet();
    }
}
