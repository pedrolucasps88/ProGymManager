using Microsoft.AspNetCore.Mvc;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints
{
    public static class PersonaisExtensions
    {
        public static void AddEndPointsPersonais(this WebApplication app)
        {
            app.MapGet("/personais", ([FromServices] DAL<Personais> dal) =>
            {
                return Results.Ok(dal.listar());
            });

            app.MapGet("/personais/{nome}", ([FromServices] DAL<Personais> dal, string nome) =>
            {
                var personais = dal.RecuperarPor(f => f.nome.ToUpper().Equals(nome.ToUpper()));
                if (personais is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(personais);
            });

            app.MapPost("/personais", ([FromServices] DAL<Personais> dal, [FromBody] Personais pessoal) =>
            {
                dal.Adicionar(pessoal);
                return Results.Ok();
            });

            app.MapDelete("/personais/{id}", ([FromServices] DAL<Personais> dal, int id) =>
            {
                var pessoal = dal.RecuperarPor(f => f.Id.Equals(id));
                if (pessoal is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(pessoal);
                return Results.Ok();
            });

            app.MapPut("/personais", ([FromServices] DAL<Personais> dal, [FromBody] Personais pessoal) =>
            {
                var pessoalEscolhido = dal.RecuperarPor(f => f.Id.Equals(pessoal.Id));
                if (pessoalEscolhido is null)
                {
                    return Results.NotFound();
                }
                dal.Atualizar(pessoal);
                return Results.Ok();
            });
        }
    }
}
