using System.Text;

namespace EfficientReading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filePath = string.Empty;
            const int bufferSize = 30;

            ReadPartOfFile(filePath, bufferSize);
            ReadEntireFile(filePath, bufferSize);
        }

        private static void ReadPartOfFile(string filePath, int bufferSize)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.SequentialScan))
            using (var streamReader = new StreamReader(fileStream))
            {
                char[] buffer = new char[bufferSize];
                int bytesRead;

                if ((bytesRead = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var result = new string(buffer, 0, bytesRead);

                    ///Your Code
                }
            }
        }
        private static void ReadEntireFile(string filePath, int bufferSize)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.SequentialScan))
            using (var streamReader = new StreamReader(fileStream))
            {
                char[] buffer = new char[bufferSize];
                int bytesRead;

                var resultBuilder = new StringBuilder();

                while ((bytesRead = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    resultBuilder.Append(buffer, 0, bytesRead);
                }

                string result = resultBuilder.ToString();
            }
        }
    }
}