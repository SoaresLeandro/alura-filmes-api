using FilmesAPI.Data.Daos;
using FilmesAPI.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<FilmeContext>(opts => 
    opts.UseLazyLoadingProxies()
        .UseMySQL(builder.Configuration.GetConnectionString("FilmeConnection")));

builder.Services.AddTransient<ICinemaDao, CinemaDaoComEfCore>();
builder.Services.AddTransient<IEnderecoDao, EnderecoDaoComEfCore>();
builder.Services.AddTransient<IFilmeDao, FilmeDaoComEfCore>();
builder.Services.AddTransient<ISessaoDao, SessaoDaoComEfCore>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
