using System.Text;
using BaseModel;
using CredentialBusiness.Interfaces;
using CredentialBusiness.Services;
using CredentialData.Interfaces;
using CredentialData.Services;
using CredentialModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CredentialWebApi
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var jwtTokenSettings = _configuration.GetSection("JwtTokenSettings").Get<JwtTokenSettings>();
            var jwtTokenValidation = _configuration.GetSection("JwtTokenValidation").Get<JwtTokenValidation>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtTokenValidation.ValidIssuer,
                    ValidAudience = jwtTokenValidation.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenValidation.IssuerSigningKey)),
                    ClockSkew = jwtTokenValidation.ClockSkew
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(jwtTokenValidation.AllowedOrigins)
                    .AllowCredentials());
            });

            var connectionString = _configuration.GetConnectionString("Default");
            services.AddScoped<IDLogins>(a => new DLogins(connectionString));
            services.AddScoped<IBLogins, BLogins>();
            services.AddScoped<IBAuthentications>(a => new BAuthentications(jwtTokenSettings, jwtTokenValidation));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors("CORS");

            app.UseMvc();
        }
    }
}
