using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TrainMe.Data.Common.Repositories;
using TrainMe.Data;
using TrainMe.Data.Repositories;
using TrainMe.Services.Data;
using TrainMe.Data.Seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TrainMe.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;

namespace TrainMe.WebAPI
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
            services.AddDbContext<TrainMeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TrainMe")));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            // Application services
            services.AddTransient<IProgramInstanceService, ProgramInstanceService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProgramService, ProgramService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IExerciseInstanceService, ExerciseInstanceService>();
            services.AddTransient<IExerciseResourceService, ExerciseResourceService>();
            services.AddTransient<IResourceService, ResourceService>();

            services.AddControllers()
                 .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = Configuration["Auth0:Audience"];
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("read:programs", policy => policy.Requirements.Add(new HasScopeRequirement("read:programs", domain)));
                //options.AddPolicy("create:programs", policy => policy.Requirements.Add(new HasScopeRequirement("create:programs", domain)));
                //options.AddPolicy("delete:programs", policy => policy.Requirements.Add(new HasScopeRequirement("delete:programs", domain)));
                //options.AddPolicy("update:programs", policy => policy.Requirements.Add(new HasScopeRequirement("update:programs", domain)));

                options.AddPolicy("create:programs", policy => policy.RequireClaim("permissions", "create:programs"));
                options.AddPolicy("read:programs", policy => policy.RequireClaim("permissions", "read:programs"));
                options.AddPolicy("delete:programs", policy => policy.RequireClaim("permissions", "delete:programs"));
                options.AddPolicy("update:programs", policy => policy.RequireClaim("permissions", "update:programs"));

                options.AddPolicy("read:users", policy => policy.RequireClaim("permissions", "read:users"));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TrainMeContext>();
                dbContext.Database.Migrate();
                new TrainMeContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}