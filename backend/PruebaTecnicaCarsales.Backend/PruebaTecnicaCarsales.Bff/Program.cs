using Microsoft.Extensions.Options;
using PruebaTecnicaCarsales.Bff.Application.Characters.GetCharacters;
using PruebaTecnicaCarsales.Bff.Application.Episodes.GetEpisodes;
using PruebaTecnicaCarsales.Bff.Infrastructure.RickAndMorty;
using PruebaTecnicaCarsales.Bff.Shared.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicyName = "AllowFrontend";

// Add services to the container.
// Add CORS for Angular in port 4200
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//manejo de errores
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add settigns configurable for RickAndMorty API
builder.Services.Configure<RickAndMortyApiOptions>(
    builder.Configuration.GetSection(RickAndMortyApiOptions.SectionName)
);

// HttpClient 
builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<RickAndMortyApiOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
});

// Use cases
builder.Services.AddScoped<IGetEpisodesUseCase, GetEpisodesUseCase>();
builder.Services.AddScoped<IGetCharactersUseCase, GetCharactersUseCase>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
