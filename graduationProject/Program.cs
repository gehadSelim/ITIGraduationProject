
using graduationProject.Bl.Managers;
using graduationProject.Bl.Managers.CityManager;
using graduationProject.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using graduationProject.DAL.Data.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using graduationProject.Filters;
using graduationProject.Bl.AutoMapping;
using graduationProject.Bl.Managers.OrderManager;
using System.Security.Claims;
using graduationProject.MiddleWares;

namespace graduationProject
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                WebRootPath = "wwwroot"
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(map => map.AddProfile(new DomainProfile()));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("p", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IOrderManager, OrderManager>();
            builder.Services.AddScoped<IStateManager, StateManager>();
            builder.Services.AddScoped<ICityManager,CityManger>();
            builder.Services.AddScoped<IBranchManager, BranchManager>();
            builder.Services.AddScoped<IShippingTypeManager, ShippingTypeManager>();
            builder.Services.AddScoped<ISettingsManager, SettingsManager>();
            builder.Services.AddScoped<IPrivilegeManger, PrivilegeManager>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
            builder.Services.AddScoped<IRepresentativeManager, RepresentativeManager>();
            builder.Services.AddScoped<ITraderManager, TraderManager>();
            builder.Services.AddScoped<IRolesManager, RolesManager>();
            builder.Services.AddScoped<IUsersManger, UsersManger>();
            builder.Services.AddScoped<RoleManager<Role>>();
            builder.Services.AddScoped<ValidatePermissionAttribute>();

            #region DataBase 
            var connectionString = builder.Configuration.GetConnectionString("Cs");
            builder.Services.AddDbContext<ShippingSystemContext>(
                options => options.UseSqlServer(connectionString));
            #endregion

            #region Identity Manager
            builder.Services
                   .AddIdentity<ApplicationUser, Role>(options =>
                   {
                       options.Password.RequireUppercase = false;
                       options.Password.RequireLowercase = false;
                       options.Password.RequireNonAlphanumeric = false;
                       options.Password.RequireDigit = true;
                       options.Password.RequiredLength = 8;
                       options.User.RequireUniqueEmail = true;
                       options.User.AllowedUserNameCharacters = options.User.AllowedUserNameCharacters +
                                                                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+*?^$()[]{}|/اأإآبتثجحخهعغفقصضطكمنيئسشدظزوةىرؤءذل~!#%=";

                   })
                   .AddEntityFrameworkStores<ShippingSystemContext>();
            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
                .AddJwtBearer("Cool", options =>
                {
                    string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                    var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                    var key = new SymmetricSecurityKey(keyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("TradersOnly", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Trader")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("RepresentativeOnly", policy => policy
                    .RequireClaim(ClaimTypes.Role, "Representative")
                    .RequireClaim(ClaimTypes.NameIdentifier));
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("p");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}