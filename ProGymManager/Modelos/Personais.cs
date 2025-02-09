﻿using System.Numerics;

namespace ProGymManager.Modelos;

internal class Personais
{
    public string nome { get; set; }
    public string cpf { get; set; }
    private string? numeroMatricula { get; set; }
    public string senha { get; set; }

    public bool disponivel => Alunos is null || Alunos.Count != 8;
    public List<Alunos>? Alunos { get; set; }= new List<Alunos>();

    public List<Solicitacao> solicitacaos { get; set; } = new List<Solicitacao>();

    public Personais(string nome, string cpf, string senha)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.senha = senha;
        this.numeroMatricula = Guid.NewGuid().ToString("N").Substring(0, 8);
    }

    public bool VerificaSenha(string senha)
    {
        if (senha == this.senha)
        {
            Console.WriteLine("Senha correta!");
            return true;
        }
        else
        {
            Console.WriteLine("Senha incorreta!");
            return false;
        }
    }

    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Aluno:{nome}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine(disponivel == true ? "Tem vagas" : "Cheio de Alunos");
        int num = 1;
        if (Alunos.Count!=0)
        {
            Console.WriteLine($"Alunos de {nome}:");
            foreach (var aluno in Alunos)
            {
                Console.WriteLine($"{num} - {aluno.nome}");
                num++;
            }
            Console.WriteLine("------------------------------------");
        }
        else
        {
            Console.WriteLine("Não Possui alunos ainda!");
        }
        
    }

}
