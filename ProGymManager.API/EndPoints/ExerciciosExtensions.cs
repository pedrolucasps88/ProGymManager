using Microsoft.AspNetCore.Mvc;
using ProGymManager.API.Requests;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints;

public static class ExerciciosExtensions
{

    public static void AddEndPointsExercicios(this WebApplication app)
    {
        app.MapGet("/exercicios", ([FromServices] DAL<Exercicios> dal) =>
        {
            return Results.Ok(dal.listar());
        });

        app.MapGet("/exercicios/{nome}", ([FromServices] DAL<Alunos> dal, string nome) =>
        {
            var exercicio = dal.RecuperarPor(e => e.nome.ToUpper().Equals(nome.ToUpper()));
            if (exercicio is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(exercicio);
        });

        app.MapGet("/exercicios/musculo/{musculo}", ([FromServices]DAL<Exercicios>dal,string musculo)=>
        {
            return Results.Ok(dal.listar().Where(e=>e.Musculo.ToUpper().Equals(musculo.ToUpper())));
        });

        app.MapPost("/exercicios", ([FromServices] DAL<Exercicios> dal, [FromBody] ExerciciosRequests exercicioRequest) =>
        {
            var exercicio = new Exercicios(exercicioRequest.nome, exercicioRequest.musculo);
            dal.Adicionar(exercicio);
            return Results.Ok();
        });

        app.MapDelete("/exercicios/{id}", ([FromServices] DAL<Exercicios> dal, int id) =>
        {
            var exercicio = dal.RecuperarPor(e => e.Id.Equals(id));
            if (exercicio is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(exercicio);
            return Results.Ok();
        });

        app.MapPut("/Exercicio", ([FromServices] DAL<Exercicios> dal, [FromBody] Exercicios exercicio) =>
        {
            var exercicioEscolhido = dal.RecuperarPor(e => e.Id.Equals(exercicio.Id));
            if (exercicioEscolhido is null)
            {
                return Results.NotFound();
            }
            exercicioEscolhido.Nome = exercicio.Nome;
            exercicioEscolhido.Musculo = exercicio.Musculo; 
            dal.Atualizar(exercicioEscolhido);
            return Results.Ok();
        });
    }
}
