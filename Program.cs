using BasicAPI;
using BasicAPI.DBContext;
using BasicAPI.Services.GetService;
using BasicAPI.Services.TokenManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var APIKey = Environment.GetEnvironmentVariable("JWT_Key") ?? throw new SecurityTokenInvalidTypeException("Invalid Token");
var ConnectionString = Environment.GetEnvironmentVariable("Connection_String") ?? throw new InvalidOperationException("Invalid Connection String");

builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddDbContext<ClientDBContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddHealthChecks().AddSqlServer(connectionString: ConnectionString, healthQuery: "SELECT 1;");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).
AddJwtBearer(token =>
{
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(APIKey))
    };
});
builder.Services.AddSingleton<ITokenManager, TokenManager>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsProduction())
{
    app.UseHsts();
}
app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandlingPath = "/api/Main/GlobalExceptionHandler",
    AllowStatusCode404Response = true
});
app.UseHttpsRedirection();
app.UseCors("AllowLocalhost4200");
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = async (context, report) =>
        {
            context.Response.ContentType = "application/json";
            var response = new
            {
                status = report.Status.ToString(),
                totalDuration = report.TotalDuration.ToString(),
                checks = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    description = e.Value.Description,
                    duration = e.Value.Duration.ToString(),
                    data = e.Value.Data
                })
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    });
    endpoints.MapControllers();
});
app.UseAuthentication();
app.MapControllers();
app.Run();