using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CatalogoWeb.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Documentação CatalogoWeb",
                    Description = "A documentação tem por objetivo orientar os desenvolvedores sobre como integrar suas aplicações com a API, descrevendo as funcionalidades, métodos a serem utilizados, listando informações a serem enviadas e recebidas, contendo exemplos possibilitando realizar testes de requisições diretamente pela página.",
                    Contact = new OpenApiContact
                    {
                        Name = "Filipe Muller Fernandes",
                        Email = "filipemullerfernandes@gmail.com",
                    }
                });

                // Habilita a leitura dos atributos de descrição
                c.EnableAnnotations();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization usando esquema Bearer.  
                      Digite 'Bearer' [Espaço] e em seguida informe o token no campo a baixo.
                      Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "Bearer Token",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                    });
            });
        }
    }
}
