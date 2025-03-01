using Microsoft.AspNetCore.Mvc;
using ProGymManager.Dados;
using ProGymManager.Modelos.Modelos;

namespace ProGymManager.API.EndPoints;

public static class TreinoExercicioExtensions
{
    public static void AddEndPointTreinoExercicio(this WebApplication app)
    {
        app.MapGet("/exerciciostreino", ([FromServices] DAL<TreinoExercicio> dal) =>
        {
            return Results.Ok(dal.listar());
        });

        app.MapGet("/exerciciostreino/exercicio/{id}", ([FromServices] DAL<TreinoExercicio> dal, int id) =>
        {
            var treinoExercicio = dal.RecuperarPor(te => te.ExercicioId.Equals(id));
            if (treinoExercicio is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(treinoExercicio);
        });

        app.MapGet("/exerciciostreino/treino/{id}", ([FromServices] DAL<TreinoExercicio> dal, int id) =>
        {
            var treinoExercicio = dal.listar().Where(te => te.TreinoId.Equals(id));
            if (treinoExercicio is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(treinoExercicio);
        });

    }
}
