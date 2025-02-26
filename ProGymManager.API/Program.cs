using ProGymManager.API.EndPoints;
using ProGymManager.Dados;
using ProGymManager.Modelos;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProGymManagerContext>();
builder.Services.AddTransient<DAL<Funcionarios>>();
builder.Services.AddTransient<DAL<Personais>>();
builder.Services.AddTransient<DAL<Alunos>>();
builder.Services.AddTransient<DAL<Treino>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen();
var app = builder.Build();
app.AddEndPointsFuncionarios();
app.AddEndPointsPersonais();
app.AddEndPointsAlunos();
app.AddEndPointsTreino();


app.UseSwagger();
app.UseSwaggerUI();

app.Run();
