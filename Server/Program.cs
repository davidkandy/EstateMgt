using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Data.DbContexts;
using Server.Extensions;
using Shared.Models.DTOs.Admin;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite("Data Source=./Data/AppDB.db"));

builder.Services.AddDbContext<EstateDBContext>(options => options.UseSqlServer("Data Source=XY0N\\XY0NSQL;User ID=sa;Password=ka1nadaya;Encrypt=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;", b => b.MigrationsAssembly("Server")));

builder.Services.AdminLibrary();

//builder.Services.AddDbContext<EstateDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("EstateDbConnection"), b=> b.MigrationsAssembly("Server")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddRouting(options => options.LowercaseUrls =true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// TODO: Create Profiles for the AutoMapper
//builder.Services.AddAutoMapper(typeof(EstateForUpdate));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    RoleManager<IdentityRole> roleManager = builder.Services.BuildServiceProvider().GetService<RoleManager<IdentityRole>>();
    UserManager<IdentityUser> userManager = builder.Services.BuildServiceProvider().GetService<UserManager<IdentityUser>>();
    SeedAdministratorRoleAndUser.Seed(roleManager, userManager);
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
// Needs to be an exact match with Cors Policy above.
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
