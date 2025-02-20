using System;

namespace ProGymManager.Modelos;

public class Alunos
{
    public int Id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
    public string numeroMatricula { get; set; }
    public int plano { get; set; }
    public bool ativo { get; set; }
    public string senha { get; set; }

    public List<Treino> Treinos { get; set; } = new List<Treino>();

    public Personais Personal { get; set; }

    public List<Solicitacao> Solicitacao { get; set; } = new List<Solicitacao>();

    public Alunos()
    {
        
    }
    public Alunos(string nome, string cpf,string senha)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.senha = senha;
        this.email = email ?? nome.ToLower().Replace(" ", "") + "@gmail.com";
        numeroMatricula = Guid.NewGuid().ToString("N").Substring(0, 8);
        ativo = true;
        plano = 1;
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

    public string GetNumeroMatricula()
    {
        return this.numeroMatricula;
    }


    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Aluno:{nome}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine($"Email:{email}");
        Console.WriteLine(plano == 1 ? "Plano: Mensal" : "Plano: Anual");
        Console.WriteLine(ativo ? "Aluno Ativo" : "Aluno Inativo");
        Console.WriteLine(Personal is null ?"Não tem personal ainda" : $"Personal:{Personal.nome}" );
        Console.WriteLine("------------------------------------");
    }
}
