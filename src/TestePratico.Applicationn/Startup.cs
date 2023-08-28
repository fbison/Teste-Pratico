using TestePratico.Infra.Data.Context;
using Destructurama;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using TestePratico.Infra.CrossCutting;
using TestePratico.Application.Filters;
using System.Text;
using TestePratico.Domain.Models;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;

namespace TestePratico.Applicationn
{
    public class Startup
    {
        private const string APP_NAME = "Teste Pratico";
        private const string CORS_PROD = "_cors_prod";
        private const string CORS_DEV = "_cors_dev";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                        .Destructure.UsingAttributes()
                        .ReadFrom.Configuration(configuration)
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .MinimumLevel.Override("System", LogEventLevel.Warning)
                        .CreateLogger();
        }

        public IConfiguration Configuration { get; }
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //this function is used to allow an aplicatication running on the same server (ex: localhost) to makes api call
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_PROD, builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
                options.AddPolicy(name: CORS_DEV, builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            var KeyTokenLogin = Configuration.GetSection("UserConfig:KeyTokenLogin").Value;
            var key = Encoding.ASCII.GetBytes(KeyTokenLogin);
            services.AddControllers();

            var returnDetailsException = Configuration.GetSection("ReturnDetailsException").Value;

            services.AddMvc(
                options =>
            {
                options.Filters.Add(new DefaultExceptionFilterAttribute(returnDetailsException));
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }
            );

            services.AddAutoMapper(AssemblyUteis.GetCurrentAssemblies());

            services.AddResolvedorDeDependencias();

            services.AddDbContext<DataDbContext>(options => options.UseSqlServer(
                                                        Configuration.GetConnectionString("DefaultConnection"),
                                                        sqlServerOptions => sqlServerOptions.CommandTimeout(120)));

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = APP_NAME,
                    Description = $"API para {APP_NAME}",
                });
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                xmlFiles.ToList().ForEach(f => c.IncludeXmlComments(f));
                //autenticação para testes pelo swagger
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Digite 'Bearer' e o seu token de usuario Ex: \"Bearer 0000-token-\"",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
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
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    });
            });
            #endregion
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
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


            //Config
            services.Configure<UserConfig>(Configuration.GetSection(nameof(UserConfig)));
            //services.Configure<RepositoryConfig>(Configuration.GetSection(nameof(RepositoryConfig)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(CORS_DEV);
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestePratico.Application v1"));
            }
            else
            {
                app.UseCors(CORS_PROD);
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            //app.UseSerilogRequestLogging();

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", APP_NAME);
            });
        }

    }
}
