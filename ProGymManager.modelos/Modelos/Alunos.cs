using System;

namespace ProGymManager.Modelos;

public class Alunos
{
    public int Id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
    public string numeroMatricula { get;private set; }
    public byte plano { get; set; }
    public bool ativo { get; set; }
    public string senha { get; set; }

    public List<Treino> treinos { get; set; } = new List<Treino>();
    public int? personalId { get; set; } // Permite valores nulos
    public Personais personal { get; set; }

    public List<Solicitacao> solicitacoes { get; set; } = new List<Solicitacao>();

    public Alunos()
    {
        this.numeroMatricula = GerarNumeroMatricula();
    }
    public Alunos(string nome, string cpf,string senha, string email = null)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.senha = senha;
        this.email = email ?? nome.ToLower().Replace(" ", "") + "@gmail.com";
        this.numeroMatricula = GerarNumeroMatricula();
        this.ativo = true;
        this.personalId = null; // Define PersonalId como nulo por padrão
        this.personal =null;
        this.plano = 1;
    }

    private string GerarNumeroMatricula()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 8);
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
        Console.WriteLine(personal is null ?"Não tem personal ainda" : $"Personal:{personal.nome}" );
        Console.WriteLine("------------------------------------");
    }
}
