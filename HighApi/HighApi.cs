using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HighApi
{
    public class Api
    {
        private static IWebHostBuilder _webHost;

        private static IWebHostBuilder Initialize()
        {
            return _webHost ??= WebHost.CreateDefaultBuilder();
        }

        public static void Run(Dictionary<string, object> routesObjects = null, int port = 5001)
        {
            if (routesObjects != null) Build(routesObjects);

            _webHost.UseUrls($"https://[::]:{port}").Build().Run();
        }

        public static IWebHostBuilder Build(Dictionary<string, object> routesObjects)
        {
            return Initialize()
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoint =>
                    {
                        foreach (var (route, result) in routesObjects)
                            endpoint.MapGet(route, context => context.Response.WriteAsJsonAsync(result));
                    });
                });
        }
    }
}
