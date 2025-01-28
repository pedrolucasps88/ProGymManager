using System.Numerics;

namespace ProGymManager.Modelos;

internal class Personais
{
    public string nome { get; set; }
    public string cpf { get; set; }
    private string? numeroMatricula { get; set; }
    public bool disponivel => Alunos is null || Alunos.Count != 8;
    List<Alunos>? Alunos { get; set; }

    public Personais(string nome, string cpf)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.numeroMatricula = Guid.NewGuid().ToString("N").Substring(0, 8);
    }

    public void MostrarFicha()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Ficha do Aluno:{nome}");
        Console.WriteLine($"Matricula:{numeroMatricula}");
        Console.WriteLine(disponivel == true ? "Tem vagas" : "Cheio de Alunos");
        int num = 1;
        if (Alunos is not null)
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
