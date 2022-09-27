using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile($"Configuration/Ocelot/ocelot.json");
//builder.Configuration.AddJsonFile($"Configuration/Ocelot/ocelot.SwaggerEndPoints.json");
builder.Services.AddOcelot(builder.Configuration);
//builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/ClassroomSwagger/swagger/v1/swagger.json", "Classroom");
    options.SwaggerEndpoint("/ContactSwagger/swagger/v1/swagger.json", "Contacts");
});
//app.UseSwaggerForOcelotUI(opt =>
//{
//    opt.PathToSwaggerGenerator = "/swagger/docs";
//});


app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
