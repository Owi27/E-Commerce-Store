using E_CommerceAPI.Data;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace E_CommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecKey"];

                // Add services to the container.
                builder.Services.AddCors(options => options.AddPolicy("ReactECommerce", policy => policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()));
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddAutoMapper(typeof(Program).Assembly);
                builder.Services.AddScoped<IProductService, Services.ProductService>();
                builder.Services.AddScoped<IUserService, UserService>();
                builder.Services.AddScoped<ICheckoutService, CheckoutService>();
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            }

            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseHttpsRedirection();
                app.Use((ctx, next) =>
                {
                    ctx.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:5173";
                    return next();
                });
                app.UseCors("ReactECommerce");
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
        }
    }
}