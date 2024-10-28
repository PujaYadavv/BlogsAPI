using BlogsServices.Core.Interfaces;
using BlogsServices.Repository;
using BlogsServices.service.JsonImplementation;
using BlogsServices.service.SQLServerImplementation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging(config =>
{ 
Log.Logger = new LoggerConfiguration()
.MinimumLevel.Warning()
.WriteTo.File("C:\\Users\\Puja.Kumari\\source\\repos\\Logs\\BlogsLogs.txt", rollingInterval: RollingInterval.Minute, flushToDiskInterval: new TimeSpan(1, 30, 0))
.CreateLogger();
config.AddSerilog();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IBlogsServices, BlogServices>();
//builder.Services.AddTransient<IWriterServices, WriterServices>();

builder.Services.AddTransient<IBlogsServices, BlogsServicesSQL>();
builder.Services.AddTransient<IWriterServices, WriterServicesSQL>();
builder.Services.AddScoped<IBlogsWriterRepositroy, BlogsWriterRepository>();
//for providng dependency if server error comes.
var app = builder.Build();

app.UseExceptionHandler("/error/puja");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
