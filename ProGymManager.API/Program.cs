using ProGymManager.API.EndPoints;
using ProGymManager.Dados;
using ProGymManager.Modelos;
using ProGymManager.Modelos.Modelos;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProGymManagerContext>();
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