using Microsoft.Extensions.Hosting;
using System.Text;

namespace BlazorServerApp
{
    public class WebServer
    {
        public async void StartServer<T>(string[] args) where T : class
        {
            try
            {
                var builder = Host.CreateDefaultBuilder();

                // Add services to the container.

                builder.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://localhost:1234");
                    webBuilder.UseStartup<T>();
                    webBuilder.UseStaticWebAssets();
                });

                var app = builder.Build();

                await app.RunAsync();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{DateTime.Now}: {ex.ToString()}");
                File.AppendAllText("log.txt", sb.ToString());
                sb.Clear();
            }
        }
    }
}
