using HubServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7264")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});
builder.Services.AddSignalR();
var app = builder.Build();
app.UseCors();
app.MapHub<ChatHub>("/chathub");
//https://localhost:7096/chathub

app.Run();
