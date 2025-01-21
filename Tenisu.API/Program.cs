using Tenisu.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var tmp = builder.Configuration.GetSection("PathToJsonFile").Value;
//builder.Services.AddScoped<IPlayersRepository>(sp => new PlayersRepository(tmp));
builder.Services.AddScoped<IPlayersRepository>(sp => new PlayersRepository(builder.Configuration.GetConnectionString("PlayersDb")));



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
