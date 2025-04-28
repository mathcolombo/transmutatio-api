using Transmutatio.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database connection


#region IOC configuration
builder.Services.AddAbstractions();
builder.Services.AddInfrastructureRepositories();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapperConfiguration();
#endregion

// Configure logger
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();