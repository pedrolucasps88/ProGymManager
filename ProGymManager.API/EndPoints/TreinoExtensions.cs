using Microsoft.AspNetCore.Mvc;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints
{
    public static class TreinoExtensions
    {
        public static void AddEndPointsTreino(this WebApplication app)
        {
            app.MapGet("/treinos", ([FromServices] DAL<Treino> dal) =>
            {
                return Results.Ok(dal.listar());
            });

            app.MapGet("/treinos/{nome}", ([FromServices] DAL<Treino> dal, string nome) =>
            {
                var treinos = dal.RecuperarPor(t => t.Nome.ToUpper().Equals(nome.ToUpper()));
                if (treinos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(treinos);
            });

            app.MapPost("/treinos", ([FromServices] DAL<Treino> dal, [FromBody] Treino treino) =>
            {
                dal.Adicionar(treino);
                return Results.Ok();
            });

            app.MapDelete("/treinos/{id}", ([FromServices] DAL<Treino> dal, int id) =>
            {
                var treino = dal.RecuperarPor(t => t.Id.Equals(id));
                if (treino is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(treino);
                return Results.Ok();
            });

            app.MapPut("/treinos", ([FromServices] DAL<Treino> dal, [FromBody] Treino treino) =>
            {
                var treinoEscolhido = dal.RecuperarPor(t => t.Id.Equals(treino.Id));
                if (treinoEscolhido is null)
                {
                    return Results.NotFound();
                }
                dal.Atualizar(treino);
                return Results.Ok();
            });

        }
    }
}
