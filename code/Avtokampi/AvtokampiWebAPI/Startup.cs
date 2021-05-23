using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Models.AuthAggregate;
using AvtokampiWebAPI.Repositories.Camps;
using AvtokampiWebAPI.Repositories.Reservations;
using AvtokampiWebAPI.Repositories.Users;
using AvtokampiWebAPI.Services.Auth;
using AvtokampiWebAPI.Services.Camps;
using AvtokampiWebAPI.Services.Reservations;
using AvtokampiWebAPI.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AvtokampiWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            // DB models service
            services.AddEntityFrameworkNpgsql().AddDbContext<avtokampiContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Avtokampi"))
            );


            // JWT Token services
            services.Configure<TokenManagementDto>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagementDto>();
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret));

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //what to validate
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        //setup validate data
                        IssuerSigningKey = secret,
                        ValidIssuer = token.Issuer,
                        ValidAudience = token.Audience,
                    };
                });


            // Services logic
            services.AddScoped<IUporabnikiService, UporabnikiService>();
            services.AddScoped<IRezervacijeService, RezervacijeService>();
            services.AddScoped<IAvtokampiService, AvtokampiService>();
            services.AddScoped<IAuthService, AuthService>();

            // Repository services
            services.AddScoped<IUporabnikiRepository, UporabnikiRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAvtokampiRepository, AvtokampiRepository>();
            services.AddScoped<IKampirnaMestaRepository, KampirnaMestaRepository>();
            services.AddScoped<IRezervacijeRepository, RezervacijeRepository>();
            services.AddScoped<IStoritveKampaRepository, StoritveKampaRepository>();


            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Avtokampi",
                    Version = "v1",
                    Description = "Web API aplikacije za kampiranje in avtokampe."
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avtokampi");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}