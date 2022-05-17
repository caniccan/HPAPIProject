using HP.Business;
using HPAPI.Middlewares;

namespace HPAPI.Extensions
{
    public static class ApplicationExtension
    {
        public static void UseCheckIE(this IApplicationBuilder app)
        {
            app.UseMiddleware<CheckBrowserIsIEMiddleware>();
            app.UseMiddleware<ResponseEditingMiddleware>();
            app.UseMiddleware<RedirectMiddleware>();
        }
        public static IApplicationBuilder UseCharacterIsExistTestPage(this IApplicationBuilder app)
        {
            app.Map("/test", middleBuilder =>
            {
                middleBuilder.Run(async (ctx) =>
                {
                    if (ctx.Request.Query.ContainsKey("id"))
                    {
                        int id = int.Parse(ctx.Request.Query["id"]);
                        await ctx.Response.WriteAsync($"{id} degeri, middleware'a geldi");
                        using var scope = middleBuilder.ApplicationServices.CreateScope();
                        var characterService = scope.ServiceProvider.GetRequiredService<ICharacterService>();
                        if (await characterService.IsCharacterExists(id))
                        {
                            await ctx.Response.WriteAsync($"{id} degeri, db'de var");
                        }
                        else
                        {
                            await ctx.Response.WriteAsync($"{id} degeri, db'de yok");
                        }
                    }
                    else
                    {
                        await ctx.Response.WriteAsync("id degeri, middleware'a gelmedi!");
                    }
                });
            });
            return app;
        }
    }
}
