using NSwag;
using NSwag.Generation.Processors.Contexts;
using NSwag.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
using Auth0.ManagementApi.Models;

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
            services.AddDbContext<Kibol_AlertContext>(opt =>
               opt.UseSqlServer("Kibol_Alert"));

            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<Kibol_AlertContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("Kibol_Alert")));
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<Kibol_AlertContext>();
            services.AddSwaggerDocument();

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
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
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
