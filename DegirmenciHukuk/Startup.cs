using DH.Business.Abstracts;
using DH.Business.Business;
using DH.Core.Encryption;
using DH.DataAccess.Abstracts;
using DH.DataAccess.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DegirmenciHukuk
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
            #region Dependencies

            services.AddScoped<IBlogCategoryBusiness, BlogCategoryBusiness>();
            services.AddScoped<IBlogCategoryDal, BlogCategoryDal>();

            services.AddScoped<IBlogCommentBusiness, BlogCommentBusiness>();
            services.AddScoped<IBlogCommentDal, BlogCommentDal>();

            services.AddScoped<IBlogPostBusiness, BlogPostBusiness>();
            services.AddScoped<IBlogPostDal, BlogPostDal>();

            services.AddScoped<IBlogTagBusiness, BlogTagBusiness>();
            services.AddScoped<IBlogTagDal, BlogTagDal>();

            services.AddScoped<IMailBusiness, MailBusiness>();
            services.AddScoped<IMailDal, MailDal>();

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddScoped<IEncryption, Encryption>();

            #endregion

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Admin/Account/Login/";
                });
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
