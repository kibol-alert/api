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
using Microsoft.AspNetCore.Identity;
using Kibol_Alert.Models;
using AutoWrapper;
using NSwag;
using NSwag.Generation.Processors.Security;
using AutoWrapper.Wrappers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Kibol_Alert.Helpers;

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
            services.AddCors();
            services.AddSwaggerDocument();
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<Kibol_AlertContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Kibol-Alert")));
            
            
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Kibol_AlertContext>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);



            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBrawlService, BrawlService>();
            services.AddScoped<IClubService, ClubService>();


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

            //services.AddAuthentication().AddFacebook(o =>
            //{
            //    o.AppId = this.Configuration["Authentication:CoderPro:Facebook:AppId"];
            //    o.AppSecret = this.Configuration["Authentication:CoderPro:Facebook:AppSecret"];
            //});
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

            app.UseApiResponseAndExceptionWrapper();

            app.UseOpenApi(options =>
            {
                options.DocumentName = "swagger";
                options.Path = "/swagger/v1/swagger.json";
                options.PostProcess = (document, _) =>
                {
                    document.Schemes.Add(OpenApiSchema.Https);
                };
            });
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwaggerUi3(options =>
            {
                options.DocumentPath = "/swagger/v1/swagger.json";
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
