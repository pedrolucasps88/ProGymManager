
using ProGymManager.Modelos;
using System.ComponentModel.Design;
Dictionary<string, Alunos> Alunos = new();
Alunos alunos = new Alunos("João", "12345678900") { ativo = false};
Alunos alunos1 = new Alunos("Maria", "12345678901") { plano = 2 };
Alunos.Add(alunos.nome, alunos);
Alunos.Add(alunos1.nome, alunos1);



void menu()
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
    Console.WriteLine("Escolha uma Opção:");

    Console.WriteLine("1 - Cadastrar Alunos");
    Console.WriteLine("2 - Ver Alunos");
    Console.WriteLine("3 - Criar treino para alunos");
    Console.WriteLine("4 - Aluno ver treino");
    Console.WriteLine("5 - Sair");

    int opcao= int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            CadastrarAlunos();
            break;
        case 2:
            VerAlunos();
            break;
        case 3:
            Console.WriteLine("TchauTchau");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("TchauTchau");
            Console.ReadLine();
            break;
    }

}









void CadastrarAlunos()
{
    Console.Clear();
    Console.WriteLine("Cadastro de Alunos");
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite o CPF do aluno:");
    string cpf = Console.ReadLine();
    Alunos aluno = new Alunos(nome, cpf);
    Alunos.Add(aluno.nome, aluno);   
    Console.WriteLine($"O aluno {aluno.nome} foi Cadastrado com sucesso!");
    menu();
}

void VerAlunos()
{

    Console.Clear();
    Console.WriteLine("Alunos:");
    foreach(var alunos in Alunos)
    {
        alunos.Value.MostrarFicha();
    }
    Console.ReadLine();
    menu();
}



menu();