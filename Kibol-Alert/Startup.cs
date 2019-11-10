using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Kibol_Alert.Database;
using Microsoft.AspNetCore.Mvc;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Services;
using Kibol_Alert.Responses.Wrappers.Factories;
using Microsoft.AspNetCore.Identity;
using Kibol_Alert.Models;
using NSwag.Generation.Processors.Security;
using NSwag;

namespace Kibol_Alert
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument();

            services.AddDbContext<Kibol_AlertContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Kibol_Alert")));

            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<Kibol_AlertContext>();

            services.AddSwaggerDocument(document =>
            {
                document.Title = "toDo";
                document.DocumentName = "swagger";
                document.OperationProcessors.Add(new OperationSecurityScopeProcessor("jwt"));
                document.DocumentProcessors.Add(new SecurityDefinitionAppender("jwt", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "JWT Token - remember to add 'Bearer ' before the token",
                }));
            });
           
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseOpenApi(options =>
            {
                options.DocumentName = "swagger";
                options.Path = "/swagger/v1/swagger.json";
                options.PostProcess = (document, _) =>
                {
                    document.Schemes.Add(OpenApiSchema.Https);
                };
            });

            app.UseSwaggerUi3(options =>
            {
                options.DocumentPath = "/swagger/v1/swagger.json";
            });

            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                ExceptionHandler = new Middleware.JsonExceptionMiddleware().Invoke
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
