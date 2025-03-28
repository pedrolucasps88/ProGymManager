﻿using Microsoft.AspNetCore.Mvc;
using ProGymManager.API.Requests;
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

            app.MapPost("/personais", ([FromServices] DAL<Personais> dal, [FromBody] PersonaisRequests personalRequest) =>
            {
                var personal = new Personais(personalRequest.nome, personalRequest.cpf, personalRequest.senha, personalRequest.email);
                dal.Adicionar(personal);
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

            app.MapPut("/personais", ([FromServices] DAL<Personais> dal, [FromBody] Personais personal) =>
            {
                var personalEscolhido = dal.RecuperarPor(p => p.Id.Equals(personal.Id));
                if (personalEscolhido is null)
                {
                    return Results.NotFound();
                }
                personalEscolhido.nome = personal.nome;
                personalEscolhido.cpf = personal.cpf;
                personalEscolhido.senha = personal.senha;
                personalEscolhido.email = personal.email;
                dal.Atualizar(personalEscolhido);
                return Results.Ok();
            });
        }
    }
}
