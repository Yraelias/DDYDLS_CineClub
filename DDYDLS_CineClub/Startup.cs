using DDYDLS_CineClubDAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DDYDLS_CineClubDAL.Repository;
using DDYDLS_CineClubDAL.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces ;
using DDYDLS_CineClubLocalModel.Services;

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
            #endregion

            #region Services
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IUserService, UserService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IGenreService, GenreService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IPersonService, PersonService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IRoleService, RoleService>();
            services.AddScoped<DDYDLS_CineClubLocalModel.Services.Interfaces.IMovieService,MovieService>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers ();
            });
        }
    }
}
