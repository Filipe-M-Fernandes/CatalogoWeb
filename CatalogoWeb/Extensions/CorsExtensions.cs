namespace CatalogoWeb.Api.Extensions
{
    public static class CorsExtensions
    {
        public static void AddDefaultCorsPolicy(this IServiceCollection services, string specification)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(specification, b =>
                {
                    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }
    }
}
