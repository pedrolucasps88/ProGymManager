using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProGymManager.API.EndPoints;
using ProGymManager.Dados;
using ProGymManager.Modelos;
using ProGymManager.Modelos.Modelos;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProGymManagerContext>((options) =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ProGymManagerDB"]);
    var connectionString = builder.Configuration.GetConnectionString("ProGymManagerDB");
    Console.WriteLine($"String de conexão: {connectionString}");
});
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
Console.WriteLine($"Ambiente atual: {environment}");
builder.Services.AddTransient<DAL<Funcionarios>>();
builder.Services.AddTransient<DAL<Personais>>();
builder.Services.AddTransient<DAL<Alunos>>();
builder.Services.AddTransient<DAL<Treino>>();
builder.Services.AddTransient<DAL<Exercicios>>();
builder.Services.AddTransient<DAL<Solicitacao>>();
builder.Services.AddTransient<DAL<TreinoExercicio>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddEndPointsFuncionarios();
app.AddEndPointsPersonais();
app.AddEndPointsAlunos();
app.AddEndPointsTreino();
app.AddEndpointsSolicitacoes();
app.AddEndPointsExercicios();
app.AddEndPointTreinoExercicio();

//using (var context = new ProGymManagerContext())
//{
//    try
//    {
//        var databaseName = context.Database.GetDbConnection().Database;
//        Console.WriteLine($"Conectado ao banco de dados: {databaseName}");

//        var tables = context.Model.GetEntityTypes()
//            .Select(e => e.GetTableName())
//            .ToList();
//        Console.WriteLine("Tabelas mapeadas pelo Entity Framework:");
//        foreach (var table in tables)
//        {
//            Console.WriteLine(table);
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
//    }
//}


app.UseSwagger();
app.UseSwaggerUI();

var port = Environment.GetEnvironmentVariable("PORT") ?? "7227"; // Porta para produção

if (!app.Environment.IsDevelopment())
{
    // Em produção, use http://0.0.0.0:{port}
    app.Run($"http://0.0.0.0:{port}");
}
else
{
    // Em desenvolvimento, use as configurações padrão do Kestrel
    app.Run();
}