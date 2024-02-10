using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;
using Weather.NET;
using Weather.NET.Enums;

namespace MinimalApi_EfficientSendFile.Controllers
{
    public static class WeatherForecastController
    {
        private const string Category = "Weather";

        /// <summary>
        /// Populates the Controller with methods to consult Weather work related
        /// </summary>
        public static void AddWeatherController(this WebApplication app)
        {
            app.MapGet($"/{Category}/Get", async () =>
                {
                    try
                    {
                        var client = new WeatherClient("Your API key");
                        var forecasts = await client.GetForecastAsync("London", 8, Measurement.Metric, Language.Spanish);

                        return Results.Ok(forecasts);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest(ex.ToString());
                    }
                })
            .WithTags(Category)
            .WithMetadata(new SwaggerOperationAttribute("Summary", "Description"));

            app.MapPost($"/{Category}/Post", async (string filePath) =>
                {
                    var file = new FileInfo(filePath);
                    int bufferSize = 2048;
                    using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.Asynchronous))
                    {
                        using (var streamContent = new StreamContent(fileStream, bufferSize))
                        {
                            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            var request = new HttpRequestMessage(HttpMethod.Post, "Endpoint")
                            {
                                Content = GetHttpContent(streamContent, file)
                            };

                            _ = await SendAsync(request);
                        }
                    }
                })
            .WithTags(Category)
            .WithMetadata(new SwaggerOperationAttribute("Category", "Description"));

        }

        private async static Task<HttpResponse> SendAsync(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        private static HttpContent GetHttpContent(StreamContent streamContent, FileInfo file)
        {
            return new MultipartFormDataContent
                {
                    { new StringContent(file.Name), nameof(file.Name) },
                    { new StringContent(DateTime.Now.ToString()), "UploadTime" },
                    { streamContent, nameof(File), file.Name }
                };
        }
    }
}
