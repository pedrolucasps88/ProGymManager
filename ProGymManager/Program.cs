
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

    Console.WriteLine("-----------------------");
    Console.WriteLine("1 - Cadastrar Alunos");
    Console.WriteLine("2 - Ver Alunos");
    Console.WriteLine("-----------------------");
    Console.WriteLine("3 - Ver Exercicios no Banco de dados");
    Console.WriteLine("4 - Criar treino para alunos");
    Console.WriteLine("-----------------------");
    Console.WriteLine("5 - Aluno ver treino");

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
            VerExerciciosPorMusculo();
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

void CriarTreino()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine();
    if (Alunos.ContainsKey(nome))
    {
        Console.WriteLine("Digite o treino do aluno:");
        string treino = Console.ReadLine();
        //Alunos[nome].treino = treino;
        Console.WriteLine("Treino cadastrado com sucesso!");
    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }
    Console.ReadLine();
    menu();
}

void VerExerciciosPorMusculo()
{
    Console.Clear();
    var enderecoDoArquivo = "exercises.txt";
    using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
    {
        var leitor = new StreamReader(fluxoDoArquivo);
        // var linha = leitor.ReadLine();
        // var texto = leitor.ReadToEnd();
        // var numero = leitor.Read();
        List<Exercicios> exercicios = new List<Exercicios>();
        while (!leitor.EndOfStream)
        {
            var linha = leitor.ReadLine();
            var dados = linha.Split(',');
            
            if (dados.Length == 2)
            {
                var nomeExercicio = dados[0].Trim();
                var musculo = dados[1].Trim();
                exercicios.Add(new Exercicios(nomeExercicio, musculo));
            }
        }

        Console.WriteLine("Escreva o Musculo que você quer ver os exercicios:");
        string musculoProcurado = Console.ReadLine()!;

        var ExerciciosPorMusculo = exercicios.Where(ex=>ex.Musculo.ToUpper().Contains(musculoProcurado.ToUpper())).ToList();
        foreach(var item in ExerciciosPorMusculo)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Exercicio: {item.Nome}");
            Console.WriteLine("------------------------");
        }
        Console.ReadLine();
    }
}

menu();