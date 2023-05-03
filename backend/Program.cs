var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddCors(opt => {
    opt.AddPolicy("CrosPolicy", policy => {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();
app.UseCors("CrosPolicy");
app.MapControllers();
// app.MapGet("/", () => "Hello World!");

app.Run();
