using DocumentService.Data;
using FileService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<FileDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("FileDbDontextConnectionString") ?? throw new InvalidOperationException("Connection string not found.")));

builder.Services.AddScoped<IDocumentRepo, DocumentRepo>();
builder.Services.AddScoped<ISignedDocumentRepo, SignedDocumentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

