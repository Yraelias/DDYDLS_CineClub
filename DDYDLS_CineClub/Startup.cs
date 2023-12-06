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
            services.AddScoped<IGenreRepository<Genre>, GenreRepository>();
            services.AddScoped<IPersonRepository<Person>, PersonRepository>();
            services.AddScoped<IRoleRepository<Role>, RoleRepository>();
            services.AddScoped<IMovieRepository<Movie>, MovieRepository>();
            services.AddScoped<IRatingRepository<Rating>, RatingRepository>();
            #endregion

            #region Services
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IUserService, UserService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IGenreService, GenreService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IPersonService, PersonService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IRoleService, RoleService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IMovieService,MovieService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IRatingService, RatingService>();
            #endregion

            #region Config JWToken
            //Récupération de la clé "secret"
            IConfigurationSection monSecret = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(monSecret);

            //Config de l'authentification

            AppSettings appSettings = monSecret.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Définition des autorisations selon les rôles
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
