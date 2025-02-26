using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Security;

namespace ProGymManager.Modelos;

public class Funcionarios
{
    public int Id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
    public string? numeroMatricula {get;private set; }
    public string senha { get; set; }
    public Funcionarios()
    {
        this.numeroMatricula = GerarNumeroMatricula();
    }
    public Funcionarios(string nome, string cpf, string senha, string email = null)
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
            return false;
        }
    }

    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Funcionario:{nome}");
        Console.WriteLine($"Meu cpf:{cpf}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine($"Email:{email}");
        Console.WriteLine("------------------------------------");

    }
    public string GetNumeroMatricula()
    {
        return this.numeroMatricula;
    }
}
