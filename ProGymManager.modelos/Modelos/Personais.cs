using System.Globalization;
using System.Numerics;

namespace ProGymManager.Modelos;

public class Personais
{
    public int Id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
    public string? numeroMatricula { get;private set; }
    public string senha { get; set; }

    public bool disponivel => Alunos is null || Alunos.Count != 8;
    public List<Alunos>? Alunos { get; set; }= new List<Alunos>();

    public List<Solicitacao> solicitacaos { get; set; } = new List<Solicitacao>();

    public Personais()
    {
        this.numeroMatricula = GerarNumeroMatricula();
    }
    public Personais(string nome, string cpf, string senha, string email=null)
    {

        this.nome = nome;
        this.cpf = cpf;
        this.senha = senha;
        this.email = email ?? nome.ToLower().Replace(" ", "") + "@gmail.com";
        this.numeroMatricula = GerarNumeroMatricula();
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

    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Aluno:{nome}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine($"Email:{email}");
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

    public string GetNumeroMatricula()
    {
        return this.numeroMatricula;
    }

}
