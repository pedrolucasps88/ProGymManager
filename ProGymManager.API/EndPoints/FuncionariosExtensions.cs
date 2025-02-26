using Microsoft.AspNetCore.Mvc;
using ProGymManager.API.Requests;
using ProGymManager.Dados;
using ProGymManager.Modelos;

namespace ProGymManager.API.EndPoints
{
    public static class FuncionariosExtensions
    {
        public static void AddEndPointsFuncionarios(this WebApplication app)
        {
            app.MapGet( "/funcionarios", ([FromServices] DAL<Funcionarios> dal) =>
            {
                return Results.Ok(dal.listar());
            });

            app.MapGet("/funcionarios/{nome}", ([FromServices] DAL<Funcionarios> dal, string nome) =>
            {
                var funcionarios = dal.RecuperarPor(f => f.nome.ToUpper().Equals(nome.ToUpper()));
                if (funcionarios is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(funcionarios);
            });

            app.MapPost("/funcionarios", ([FromServices] DAL<Funcionarios> dal, [FromBody] FuncionariosRequest funcionarioRequest)=>
            {
                var funcionario =new Funcionarios(funcionarioRequest.nome, funcionarioRequest.cpf, funcionarioRequest.senha, funcionarioRequest.email);
                dal.Adicionar(funcionario);
                return Results.Ok();
            });

            app.MapDelete("/funcionarios/{id}", ([FromServices] DAL<Funcionarios> dal,int id) =>
            {
                var funcionario = dal.RecuperarPor(f => f.Id.Equals(id));
                if(funcionario is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(funcionario);
                return Results.Ok();
            });

            app.MapPut("/funcionarios", ([FromServices] DAL<Funcionarios> dal, [FromBody] Funcionarios funcionario) =>
            {
                var funcionarioEscolhido = dal.RecuperarPor(f => f.Id.Equals(funcionario.Id));
                if (funcionarioEscolhido is null)
                {
                    return Results.NotFound();
                }
                funcionarioEscolhido.nome = funcionario.nome;
                funcionarioEscolhido.cpf = funcionario.cpf;
                funcionarioEscolhido.senha = funcionario.senha;
                funcionarioEscolhido.email = funcionario.email;
                dal.Atualizar(funcionarioEscolhido);
                return Results.Ok();
            });

        }



    }
}
