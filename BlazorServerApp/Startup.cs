using BlazorServerApp.Data;
using System.Reflection;

namespace BlazorServerApp
{
    [Obfuscation(Feature = "renaming", Exclude = true)]
    public class Startup
    {
        private string defaultAnswer = "42";
        public IConfiguration Configuration { get; set; }

        private string test = "";

        protected int test2 = 0;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddServerSideBlazor().AddHubOptions(o => o.MaximumReceiveMessageSize = 102400000);
            services.AddSingleton<WeatherForecastService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(enpints =>
            {
                enpints.MapBlazorHub();
                enpints.MapFallbackToPage("/_Host");
            });
            Console.WriteLine(defaultAnswer);
        }
    }
}
