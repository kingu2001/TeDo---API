using FileService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<FileDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("FileDbDontextConnectionString") ?? throw new InvalidOperationException("Connection string not found.")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IDocumentRepo, DocumentRepo>();
builder.Services.AddScoped<ISignedDocumentRepo, SignedDocumentRepo>();
builder.Services.AddScoped<ICertificateRepo, CertficateRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

if(builder.Environment.IsProduction())
System.Console.WriteLine("--> Environment is i production");

if(builder.Environment.IsDevelopment())
System.Console.WriteLine("--> Environment is i development");

PrepDb.PrepPopulation(app);

app.Run();

