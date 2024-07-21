using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using POSSystem.DataContext.DataContext;
using POSSystem.WebServices.Helpers;
using POSSystem.WebServices.Infrastructure.Interface;
using POSSystem.WebServices.Infrastructure.Repository;
using System.Text;

namespace POSSystem.WebServices;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		POSHelper.POS_CONNECTION_STRING = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("POSConnection");
		POSHelper.POS_DB_PASSWORD = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("DbPassword");

		POSHelper.JWT_KEY = builder.Configuration.GetSection("JwtConfiguration").GetValue<string>("Key");
		POSHelper.JWT_ISSUER = builder.Configuration.GetSection("JwtConfiguration").GetValue<string>("Issuer");
		POSHelper.JWT_AUDIENCE = builder.Configuration.GetSection("JwtConfiguration").GetValue<string>("Audience");


		// Add services to the container.
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddHttpContextAccessor();
		builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

		builder.Services.AddCors(opt =>
		{
			opt.AddPolicy("PolicyCors", p =>
			{
				p.AllowAnyOrigin();
				p.AllowAnyHeader();
				p.AllowAnyMethod();
			});
		});

		builder.Services.AddDbContext<PossystemContext>(options =>
		{
			string decryptPlainText = SandevLibrary.SecurityAlgorithm.AESAlgorithm.DecryptTextWithSalt(POSHelper.POS_DB_PASSWORD);
			options.UseNpgsql(POSHelper.POS_CONNECTION_STRING + $"Password={decryptPlainText};");
		});

		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = POSHelper.JWT_ISSUER,
				ValidAudience = POSHelper.JWT_AUDIENCE,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(POSHelper.JWT_KEY))
			};
		});
		builder.Services.AddSession(options =>
		{
			options.Cookie.HttpOnly = false;
			options.Cookie.IsEssential = true;
		});

		builder.Services.AddScoped<PossystemContext>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<ITokenService, TokenService>();

		builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		var app = builder.Build();
		app.UseSwagger();
		app.UseSwaggerUI();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			
		}

		app.UseSession();
		app.UseCors();

		app.Use(async (context, next) =>
		{
			string? token = context.Session.GetString("access_token");
			if (!string.IsNullOrEmpty(token))
			{
				context.Request.Headers.Add("Authorization", "Bearer " + token);
			}
			await next();
		});

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();
		app.UseAuthentication();

		app.MapControllers();

		app.Run();
	}
}
