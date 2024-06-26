using DDYDLS_CineClubDAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using DDYDLS_CineClubDAL.Repository;
using DDYDLS_CineClubDAL.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces ;
using DDYDLS_CineClubLocalModel.Services;
using DDYDLS_CineClubApi.Services;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDYDLS_CineClub
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
            services.AddRazorPages();
            services.AddControllers();

            #region Repository
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IMovieRepository<Movie>, MovieRepository>();
            services.AddScoped<IRatingRepository<Ratings>, RatingRepository>();
            services.AddScoped<ICineclubRepository<Cineclub>, CineclubRepository>();
            services.AddDbContext<CineclubContext>(options => options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            #endregion

            #region Services
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IUserService, UserService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IMovieService,MovieService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IRatingService, RatingService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.ICineclubService, CineclubService>();
            #endregion

            #region Config JWToken
            //R�cup�ration de la cl� "secret"
            IConfigurationSection monSecret = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(monSecret);

            //Config de l'authentification

            AppSettings appSettings = monSecret.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //D�finition des autorisations selon les r�les
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User", "Admin"));
            });

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

            services.AddScoped<ITokenService, TokenService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CineclubContext cineclubContext )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                cineclubContext.Database.EnsureCreated();
                Console.WriteLine("Connexion � la base de donn�es r�ussie !");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
