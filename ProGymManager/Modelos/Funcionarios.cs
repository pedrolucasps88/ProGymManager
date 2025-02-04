using System.Globalization;
using System.Security;

namespace ProGymManager.Modelos;

internal class Funcionarios
{
    public string nome { get; set; }
    public string cpf { get; set; }
    private string? numeroMatricula { get; set; }

    private string senha { get; set; }

    public Funcionarios(string nome, string cpf,string senha)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.numeroMatricula = Guid.NewGuid().ToString("N").Substring(0, 8);
    }

    public bool VerificaSenha()
    {
        Console.WriteLine("Digite a sua senha:");
        string senha = Console.ReadLine()!;
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
        Console.WriteLine($"Ficha do Funcionario:{nome}");
        Console.WriteLine($"Meu cpf:{cpf}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine("------------------------------------");

    }
}
