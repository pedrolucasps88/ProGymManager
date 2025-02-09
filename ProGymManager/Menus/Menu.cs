using ProGymManager.Modelos;
using System.Collections.Generic;

namespace ProGymManager.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo.ToUpper());
        Console.WriteLine(asteriscos + "\n");
    }

    public int MenuInicial()
    {
        Console.Clear();
        Console.WriteLine("WELCOME TO");
        Console.WriteLine(@"

██████╗░██████╗░░█████╗░░██████╗░██╗░░░██╗███╗░░░███╗███╗░░░███╗░█████╗░███╗░░██╗░█████╗░░██████╗░███████╗██████╗░
██╔══██╗██╔══██╗██╔══██╗██╔════╝░╚██╗░██╔╝████╗░████║████╗░████║██╔══██╗████╗░██║██╔══██╗██╔════╝░██╔════╝██╔══██╗
██████╔╝██████╔╝██║░░██║██║░░██╗░░╚████╔╝░██╔████╔██║██╔████╔██║███████║██╔██╗██║███████║██║░░██╗░█████╗░░██████╔╝
██╔═══╝░██╔══██╗██║░░██║██║░░╚██╗░░╚██╔╝░░██║╚██╔╝██║██║╚██╔╝██║██╔══██║██║╚████║██╔══██║██║░░╚██╗██╔══╝░░██╔══██╗
██║░░░░░██║░░██║╚█████╔╝╚██████╔╝░░░██║░░░██║░╚═╝░██║██║░╚═╝░██║██║░░██║██║░╚███║██║░░██║╚██████╔╝███████╗██║░░██║
╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚═════╝░░░░╚═╝░░░╚═╝░░░░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚═╝
    ");

        Console.WriteLine("Quem você é:");
        Console.WriteLine("1-Funcionario");
        Console.WriteLine("2-Personal");
        Console.WriteLine("3-Aluno");
        Console.WriteLine("4-Sair");

        Console.Write("Opção escolhida: ");
        int opcao = int.Parse(Console.ReadLine()!);
        if(opcao < 1 || opcao > 4)
        {
            Console.WriteLine("Opção incorreta!");
            Console.ReadLine();
            return MenuInicial();
        }
        else
        {
            return opcao;
        }
    }

    public virtual int Sair()
    {
        Console.WriteLine("Saindo...");
        return 0;
    }



    public virtual void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos)
    {
    }
    public virtual void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos
        ,Funcionarios funcionarioLogado)
    {
    }

}
