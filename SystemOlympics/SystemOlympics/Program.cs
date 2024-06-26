var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowOrigin", builder =>
  {
    //builder.AllowAnyOrigin()
    //       .AllowAnyMethod()
    //       .AllowAnyHeader();

    builder
        .WithOrigins("http://localhost:4200",
                     "http://localhost")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
  });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowOrigin"); // CORS Middleware

app.UseRouting(); // Routing Middleware

app.UseAuthorization();

app.MapControllers();

app.Run();
