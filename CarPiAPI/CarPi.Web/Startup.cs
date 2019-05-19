using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using DataAccess.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CarPi.Validations.Validation;
using CarPi.DataAccess.Repositories;

namespace CarPi.Api
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

            services.AddMvc()
                .AddXmlSerializerFormatters() // We add the XML support for the API reponse
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .AddFluentValidation(fv => // We configure the validators
                {
                });

            // We configure the dependency injection for the DB context
            services.AddDbContext<CarPiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CarPi"))
            );

            // We add automapper as a service
            services.AddAutoMapper(typeof(Startup));

            // Repository DI
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleByUserRepository, RoleByUserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            // Validators DI
            services.AddScoped<AbstractValidator<User>, UserValidator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorsOnlyAllowed", policy =>
                {
                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.RequireAssertion(context =>
                    {
                        var stringRoleId = ((int)CarPi.Enums.Enums.Role.Admin).ToString();

                        return context.User.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == "1");
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
