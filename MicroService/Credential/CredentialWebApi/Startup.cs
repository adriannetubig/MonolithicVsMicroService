using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        // This method gets called by the runtime. Use this method to add services to the container.
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

            var connectionString = _configuration.GetSection("ConnectionString").Value;
            services.AddScoped<IDLogin>(a => new DLogin(connectionString));
            services.AddScoped<IBLogin, BLogin>();
            services.AddScoped<IBAuthentication>(a => new BAuthentication(jwtTokenSettings, jwtTokenValidation));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
