using System.Text;
using api.DAL;
using api.DAL.code;
using api.DAL.data;
using api.DAL.Implementations;
using api.DAL.Interfaces;
using AutoMapper;
using Cardiohelp.data.Implementations;
using Cardiohelp.data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace api
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
            services.TryAddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, HttpContextAccessor>(); 

            // services.AddDbContext<dataContext>(x => x.UseMySql(Configuration.GetConnectionString("SQLconnection")));

           

            var _connectionString = Configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<dataContext>(
                options => options.UseMySql(_connectionString,ServerVersion.AutoDetect(_connectionString),
                options => options.EnableRetryOnFailure(
                     maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null
                )
                )
            );

        

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IRegistryRepository, RegistryRepository>();
            services.AddScoped<IElementaryStatistics, ElementaryStatistics>();
          
            services.AddScoped<Dropdownlists>();
            services.AddScoped<SpecialMaps>();
            services.AddScoped<CSVProducer>();

            services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddCors(options =>
                       {
                           options.AddPolicy("CorsPolicy",
                           builder =>
                           {
                               builder.WithOrigins("http://localhost:4200")
                                                   .AllowAnyHeader()
                                                   .AllowCredentials()
                                                   .AllowAnyMethod();
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

            //app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index","Fallback");
            });
        }
    }
}
