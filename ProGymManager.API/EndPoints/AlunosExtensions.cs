using Microsoft.AspNetCore.Mvc;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints
{
    public static class AlunosExtensions
    {
        public static void AddEndPointsAlunos(this WebApplication app)
        {
            app.MapGet("/alunos", ([FromServices] DAL<Alunos> dal) =>
            {
                return Results.Ok(dal.listar());
            });

            app.MapGet("/alunos/{nome}", ([FromServices] DAL<Alunos> dal, string nome) =>
            {
                var alunos = dal.RecuperarPor(a => a.nome.ToUpper().Equals(nome.ToUpper()));
                if (alunos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(alunos);
            });

            app.MapPost("/alunos", ([FromServices] DAL<Alunos> dal, [FromBody] Alunos aluno) =>
            {
                dal.Adicionar(aluno);
                return Results.Ok();
            });

            app.MapDelete("/alunos/{id}", ([FromServices] DAL<Alunos> dal, int id) =>
            {
                var aluno = dal.RecuperarPor(a => a.Id.Equals(id));
                if (aluno is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(aluno);
                return Results.Ok();
            });

            app.MapPut("/alunos", ([FromServices] DAL<Alunos> dal, [FromBody] Alunos aluno) =>
            {
                var alunoEscolhido = dal.RecuperarPor(a => a.Id.Equals(aluno.Id));
                if (alunoEscolhido is null)
                {
                    return Results.NotFound();
                }
                dal.Atualizar(aluno);
                return Results.Ok();
            });
        }
    }
}
