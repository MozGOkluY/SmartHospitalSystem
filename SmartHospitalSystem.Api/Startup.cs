using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartHospitalSystem.Api.Helpers;
using SmartHospitalSystem.Core.Configurations;
using SmartHospitalSystem.Core.Interfaces.Configurations;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Managers;
using SmartHospitalSystem.Core.Models;
using SmartHospitalSystem.Core.Repositories;

namespace SmartHospitalSystem.Api
{
    /// <summary>
	/// Startup class
	/// </summary>
    public class Startup
    {
        /// <summary>
		/// Ctor for startup class
		/// </summary>
		/// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
		/// Gets or set configuration
		/// </summary>
        public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var tokenConfiguration = new TokenConfiguration(Configuration);

            // common
            services.AddTransient<IPasswordHasher<UserProfile>, PasswordHasher<UserProfile>>();

            // configurations
            services.AddSingleton<IDbConfiguration, MongoDbConfiguration>();
            services.AddSingleton<ITokenConfiguration, TokenConfiguration>();

            // repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IBedRepository, BedRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // managers
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IBedManager, BedManager>();
            services.AddScoped<IPatientManager, PatientManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IAuthorizationManager, AuthorizationManager>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            var authPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();


            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters.ValidateIssuer = true;
                o.TokenValidationParameters.ValidIssuer = tokenConfiguration.Issuer;
                o.TokenValidationParameters.ValidateIssuerSigningKey = true;
                o.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret));
                o.TokenValidationParameters.ValidateAudience = false;
                o.TokenValidationParameters.ValidateLifetime = true;
                o.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth => auth.AddPolicy("Bearer", authPolicy));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(SwaggerHelper.ConfigureSwaggerGen);
        }

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();

            app.UseSwagger(SwaggerHelper.ConfigureSwagger);
            app.UseSwaggerUI(SwaggerHelper.ConfigureSwaggerUi);
        }
    }
}
