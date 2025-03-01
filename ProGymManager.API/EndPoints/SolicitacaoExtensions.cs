using Microsoft.AspNetCore.Mvc;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints
{
    public static class SolicitacaoExtensions
    {
        public static void AddEndpointsSolicitacoes(this WebApplication app)
        {
            app.MapGet("/solicitacoes", ([FromServices] DAL<Solicitacao> dal) =>
            {
                //Essa função lista as solicitacoes
                return Results.Ok(dal.listar());
            });

            app.MapGet("/solicitacao/personais/{id}", ([FromServices] DAL<Solicitacao> dal, int id) =>
            {
                var listasolicitacoes = dal.listar().Where(s => s.PersonalId.Equals(id));
                if (listasolicitacoes is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(listasolicitacoes);
            });

            app.MapGet("/solicitacao/alunos/{id}", ([FromServices] DAL<Solicitacao> dal, int id) =>
            {
                var listasolicitacoes = dal.listar().Where(s => s.AlunoId.Equals(id));
                if (listasolicitacoes is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(listasolicitacoes);
            });

            app.MapGet("/solicitacao/status/{status}", ([FromServices] DAL<Solicitacao> dal, string status) =>
            {
                var listasolicitacoes = dal.listar().Where(s => s.Status.Equals(status));
                if (listasolicitacoes is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(listasolicitacoes);
            });

            app.MapPost("/solicitacoes", ([FromServices] DAL<Solicitacao> dal, [FromBody] Solicitacao solicitacao) =>
            {
                dal.Adicionar(solicitacao);
                return Results.Ok();
            });

            app.MapDelete("/solicitacoes/{id}", ([FromServices] DAL<Solicitacao> dal, int id) =>
            {
                var solicitacao = dal.RecuperarPor(s => s.Id.Equals(id));
                if (solicitacao is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(solicitacao);
                return Results.Ok();
            });

            app.MapPut("/solicitacoes", ([FromServices] DAL<Solicitacao> dal, [FromBody] Solicitacao solicitacao) =>
            {
                var solicitacaoEscolhida = dal.RecuperarPor(s => s.Id.Equals(solicitacao.Id));
                if (solicitacaoEscolhida is null)
                {
                    return Results.NotFound();
                }
                solicitacaoEscolhida.Status = solicitacao.Status;
                solicitacaoEscolhida.PersonalId = solicitacao.PersonalId;
                solicitacaoEscolhida.AlunoId = solicitacao.AlunoId;
                dal.Atualizar(solicitacaoEscolhida);
                return Results.Ok();
            });
        }
    }
}
