using ApiProject.WebApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle

builder.Services.AddDbContext<ApiContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
var app = builder.Build();

// Pipeline yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();