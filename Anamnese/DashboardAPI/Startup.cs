using ESS.Amanse.BLL.Collection;
using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;
namespace DashboardAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(
                                          "https://localhost:3000",
                                          "http://localhost:3000",
                                          "http://localhost:3002",
                                          "https://localhost:3001",
                                          "http://localhost:3001",
                                          "https://anamnesedashboard.surge.sh",
                                          "https://anamnesehome.surge.sh",
                                          "https://anamneseaditor.surge.sh",
                                          "https://anamneselearning.surge.sh"
                                                          ).AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AmanseHomeContext>(o => o.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(Startup));


            services.AddTransient<ITemplates, Templates>();
            services.AddTransient<IProfile, Profile>();
            services.AddTransient<ICommons, Commons>();
            services.AddTransient<IDocument, Document>();
            services.AddTransient<IPatient, Patient>();
            services.AddTransient<IPractice, Practice>();
            services.AddTransient<IMedicalHistory, ESS.Amanse.BLL.Collection.MedicalHistory>();
            services.AddTransient<IAnamnesisAtHomeFlows, AnamnesisAtHomeFlows>();
            services.AddTransient<IAnamneseHome, AnamneseHomeCollection>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Issuer"],
                  };
              });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors("MyPolicy");
            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "UploadImages")),
                RequestPath = "/UploadImages"
            });
            //Enable directory browsing
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //                Path.Combine(Directory.GetCurrentDirectory(), "UploadImages")),
            //    RequestPath = "/UploadImages"
            //});


            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
