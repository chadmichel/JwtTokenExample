using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JwtDemo2
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
            services.AddControllers();
            
            var key = Encoding.ASCII.GetBytes("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImp0aSI6ImQ0OWUwMWI4LTc5YjUtNDViYi1hNmJjLWM0Yzk1OTMyZjUwZSIsImlhdCI6MTU5NjgxMjgwNSwiZXhwIjoxNTk2ODE2NDA1fQ.2h0qCwDIzXtRN87eA36WlQS9evToqkM863veBCmgMT0");  
            services.AddAuthentication(x =>  
                {  
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
                })  
                .AddJwtBearer(x =>  
                {  
                    x.TokenValidationParameters = new TokenValidationParameters  
                    {  
                        IssuerSigningKey = new SymmetricSecurityKey(key),  
                        ValidateIssuer = false,  
                        ValidateAudience = false,  
                        ValidIssuer = "localhost",  
                        ValidAudience = "localhost"  
                    };  
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}