using System;

namespace ProGymManager.Modelos;

internal class Alunos
{
    public string nome { get; set; }
    public string cpf { get; set; }
    private string numeroMatricula { get; set; }
    public int plano { get; set; }
    public bool ativo { get; set; }

    public Alunos(string nome, string cpf)
    {
        this.nome = nome;
        this.cpf = cpf;
        numeroMatricula = Guid.NewGuid().ToString("N").Substring(0, 8);
        ativo = true;
        plano = 1;
    }

    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Aluno:{nome}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine(plano == 1 ? "Plano: Mensal" : "Plano: Anual");
        Console.WriteLine(ativo ? "Aluno Ativo" : "Aluno Inativo");
        Console.WriteLine("------------------------------------");
    }
}
