using Microsoft.EntityFrameworkCore;
using TestDocumentService.Data.Context;
using TestDocumentService.Data.DatabaseSeed;
using TestDocumentService.Data.Interfaces;
using TestDocumentService.Data.Repositorys;

var builder = WebApplication.CreateBuilder(args);

var MyAllowPolicy = "_myAllowPolicy";
builder.Services.AddCors(opt => opt.AddPolicy(name: MyAllowPolicy, policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
 builder.Services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("AppDbDontextConnectionString") ?? throw new InvalidOperationException("Connection string not found.")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//For testing ONLY!!
// Console.WriteLine("--> Enter origin to allow with CORS");
// var origin = Console.ReadLine();
// Console.WriteLine($"--> Entered origin: {origin}");


//Dependeny Injection
builder.Services.AddScoped<ITestDocumentRepo, TestDocumentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowPolicy);

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
