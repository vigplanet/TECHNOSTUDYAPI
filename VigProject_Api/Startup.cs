using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VigProject_Api.Model;
using VigProject_Api.Services;

namespace VigProject_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //NAYEEM PART 2
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.AddHttpContextAccessor();
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes("VIPINLh5n_qbdlNUQrqdHPgp");

            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VigProject_Api", Version = "v1" });
            //    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "basic",
            //        In = ParameterLocation.Header,
            //        Description = "Basic Authorization header using the Bearer scheme."
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //              new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type = ReferenceType.SecurityScheme,
            //                        Id = "basic"
            //                    }
            //                },
            //                new string[] {}
            //        }
            //    });
            //});

            //            services.AddAuthentication("BasicAuthentication")
            //.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Application APIs", Version = "v1" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddAuthorization(AZ =>
            {
                AZ.DefaultPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
            services.AddAuthentication(A =>
            {
                A.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                A.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                A.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ClockSkew = TimeSpan.Zero,// It forces tokens to expire exactly at token expiration time instead of 5 minutes later
                     IssuerSigningKey = new SymmetricSecurityKey(key)
                 };
             });
            services.AddScoped<IUserService, UserService>();
            services.Configure<DBModel>(Configuration.GetSection("ConnectionStrings"));

            services.AddHttpContextAccessor();

            services.AddMemoryCache();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddCors();
            #region New Code
            //            services.AddControllersWithViews()
            //    .AddJsonOptions(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(policy =>
            {
                policy.SetIsOriginAllowed(_ => true);
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
                policy.WithExposedHeaders("X-Auth");
            });
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VigProject_Api v1"));
            }
            else { app.UseHsts(); }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            { await context.Response.WriteAsync("Could not find Anything"); });

            ConnectionString_CastingAPI = Configuration["ConnectionStrings:DbConn_CastingAPI"];
            ConnectionString_gymAPI = Configuration["ConnectionStrings:DbConn_gymAPI"];
            ConnectionString_empAPI = Configuration["ConnectionStrings:DbConn_empAPI"];
            ConnectionString_ExamAPI = Configuration["ConnectionStrings:DbConn_ExamAPI"];
            ConnectionString_VideoAPI = Configuration["ConnectionStrings:DbConn_VideoAPI"];
            ConnectionString_kamemp = Configuration["ConnectionStrings:DbConn_kamemp"];
            ConnectionString_Store = Configuration["ConnectionStrings:DbConn_store"];
            ConnectionString_Payroll = Configuration["ConnectionStrings:DbConn_payroll"];
            ConnectionString_TechOnStudy = Configuration["ConnectionStrings:DbConn_TechOnStudy"];
        }

        public static string ConnectionString_CastingAPI
        {
            get;
            private set;
        }

        public static string ConnectionString_gymAPI
        {
            get;
            private set;
        }
        public static string ConnectionString_empAPI
        {
            get;
            private set;
        }
        public static string ConnectionString_ExamAPI
        {
            get;
            private set;
        }

        public static string ConnectionString_VideoAPI
        {
            get;
            private set;
        }

        public static string ConnectionString_kamemp
        {
            get;
            private set;
        }
        public static string ConnectionString_Store
        {
            get;
            private set;
        }

        public static string ConnectionString_Payroll
        {
            get;
            private set;
        }
        public static string ConnectionString_TechOnStudy
        {
            get;
            private set;
        }
    }
}
