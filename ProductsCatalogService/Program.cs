
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductsCatalogService.Data;

namespace ProductsCatalogService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlSerializerFormatters().AddNewtonsoftJson();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Add Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddOData();

            builder.Services.AddDbContext<ProductsDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });


            //builder.Services.AddIdentity<IdentityUser, IdentityRole>();
            //.AddEntityFrameworkStores<ProductsDbContext>()
            //.AddDefaultTokenProviders()
            //.AddSignInManager();


            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ProductsDbContext>();

            builder.Services.AddAuthorization();


            // Step 1: Create CORS Policy

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy1", builder =>
                {
                    //builder.WithOrigins("http://one.com, http://two.com"); // for specific clients
                    builder.AllowAnyOrigin(); // for all clients
                    //builder.AllowAnyHeader();
                    //builder.AllowAnyMethod();
                    //builder.WithMethods("GET,POST");
                });
            });


            var app = builder.Build();

            // use CORS middleware
            //app.UseCors("policy1");
            app.UseCors();

            app.UseResponseCaching();

            app.MapIdentityApi<IdentityUser>(); // for registration, login etc endpoints



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().MaxTop(100).Count().SkipToken().Expand();
                endpoints.MapControllers();
            });


            //app.MapControllers();

            app.Run();
        }
    }
}
