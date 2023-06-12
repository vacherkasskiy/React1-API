using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        config =>
        {
            config.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithExposedHeaders("Access-Control-Allow-Origin");
        });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // options.Cookie.HttpOnly = true;
        // options.Cookie.SameSite = SameSiteMode.None;
        // options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("AllowLocalhost3000");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Комментируем перенаправление на HTTPS

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();