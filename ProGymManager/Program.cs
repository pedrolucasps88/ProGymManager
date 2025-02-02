
using ProGymManager.Modelos;
using System.ComponentModel.Design;
using System.Linq;
string solicitacao;
Dictionary<string, Alunos> Alunos = new();
Alunos alunos = new Alunos("João", "12345678900") { ativo = false};
Alunos alunos1 = new Alunos("Maria", "12345678901") { plano = 2 };
Alunos.Add(alunos.nome, alunos);
Alunos.Add(alunos1.nome, alunos1);


Dictionary<string, Personais> Personais = new();
Personais personal = new Personais("Pedro", "12345678902");
Personais personal1 = new Personais("Ana", "12345678903");
Personais.Add(personal.nome, personal);
Personais.Add(personal1.nome, personal1);


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
    Console.WriteLine("*FUNCIONARIO*");
    Console.WriteLine("1 - Cadastrar Alunos");
    Console.WriteLine("2 - Cadastrar Personal");
    Console.WriteLine("3 - Ver Alunos");
    Console.WriteLine("4 - Ver Personais");
    Console.WriteLine("-----------------------");
    Console.WriteLine("*PERSONAL*");
    Console.WriteLine("5 - Ver Exercicios no Banco de dados");
    Console.WriteLine("6 - Criar treino para alunos");
    Console.WriteLine("7 - Ver/Aceitar solicitações");
    Console.WriteLine("-----------------------");
    Console.WriteLine("*ALUNO*");
    Console.WriteLine("8 - Aluno ver treino");
    Console.WriteLine("9 - Contratar Personal");
    Console.WriteLine("10 - Marcar treino com Personal");
    Console.WriteLine("11 - Ver solicitações");
    Console.WriteLine("-----------------------");
    Console.WriteLine("12 - Sair");
    Console.WriteLine("-----------------------");

    Console.Write("Sua Opção: ");
    int opcao= int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            CadastrarAlunos();
            break;
        case 2:
            CadastrarPersonal();
            break;
        case 3:
            VerAlunos();
            break;
        case 4:
            VerPersonais();
            break;
        case 5:
            VerExerciciosPorMusculo();
            break;
        case 6:
            CriarTreino();
            break;
        case 7:
            Ver_AceitarSolicitacao();
            break;
        case 8:
            VerTreinosPorAluno();
            break;
        case 9:
            ContratarPersonal();
            break;
        case 10:
            MarcarTreinoComPersonal();
            break;
        case 11:
            AlunoVerSolicitaçõesDeTreino();
            break;
        case 12:
            Console.WriteLine("TchauTchau");
            Console.ReadLine();
            break;

        default:
            Console.WriteLine("Opção invalida - TchauTchau");
            Console.ReadLine();
            break;
    }

}


void CadastrarAlunos()
{
    Console.Clear();
    Console.WriteLine("Cadastro de Alunos");
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o CPF do aluno:");
    string cpf = Console.ReadLine()!;
    Alunos aluno = new Alunos(nome, cpf);
    Alunos.Add(aluno.nome, aluno);   
    Console.WriteLine($"O aluno {aluno.nome} foi Cadastrado com sucesso!");
    menu();
}

void CadastrarPersonal()
{
    Console.Clear();
    Console.WriteLine("Cadastro de Personal");
    Console.WriteLine("Digite o nome do Personal:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Digite o CPF do Personal:");
    string cpf = Console.ReadLine()!;
    Personais personal = new Personais(nome, cpf);
    Personais.Add(personal.nome, personal);
    Console.WriteLine($"O Personal {personal.nome} foi Cadastrado com sucesso!");
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

void VerPersonais()
{
    Console.Clear();
    Console.WriteLine("Personais:");
    foreach (var personal in Personais)
    {
        personal.Value.MostrarFicha();
    }
    Console.ReadLine();
    menu();
}
void CriarTreino()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine()!;
    int sairT = 0;

    if (Alunos.ContainsKey(nome))
    {
        Console.WriteLine("Digite o Nome do treino do aluno:");
        string nomeTreino = Console.ReadLine()!;
        List<Exercicios> treino = new List<Exercicios>();
        while (sairT==0)
        {
            Console.WriteLine("Digite o Exercicio do treino do aluno:");
            string exercicio=Console.ReadLine()!;
            Console.WriteLine("Digite o Musculo do exercicio:");
            string musculo = Console.ReadLine()!;
            Exercicios ex = new Exercicios(exercicio, musculo);
            treino.Add(ex);
            Console.WriteLine("Deseja adicionar mais exercicios? 1-Sim 2-Não");
            int sair = int.Parse(Console.ReadLine()!);
            if (sair == 2)
            {
                sairT = 1;
            }
        }
        Alunos aluno = Alunos[nome];    
        Treino treinoAluno = new Treino(nomeTreino,treino,aluno);
        aluno.Treinos.Add(treinoAluno);
        Console.WriteLine("Treino cadastrado com sucesso!");
    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }
    Console.ReadLine();
    menu();
}

void VerTreinosPorAluno()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine()!;
    if (Alunos.ContainsKey(nome))
    {
        Alunos aluno = Alunos[nome];
        foreach (var treino in aluno.Treinos)
        {
            Console.WriteLine($"Treino: {treino.Nome}");
            Console.WriteLine("\n");
            foreach (var exercicio in treino.Exercicios)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Exercicio: {exercicio.Nome} -- {exercicio.Musculo}");
                Console.WriteLine("---------------------------------------");
            }
        }   
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
    menu();
}


void ContratarPersonal()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine()!;
    if (Alunos.ContainsKey(nome))
    {
        Alunos aluno = Alunos[nome];
        List<Personais> personaisDisponiveis = new List<Personais>();

        Console.WriteLine("Personais Disponiveis:");
        foreach (var personal in Personais)
        {
            if (personal.Value.disponivel) personaisDisponiveis.Add(personal.Value);
        }
        foreach (var personais in personaisDisponiveis)
        {
            personais.MostrarFicha();
        }
        Console.WriteLine("Digite o nome do Personal que quer contratar:");
        string nomePersonal = Console.ReadLine()!;
        if (Personais.ContainsKey(nomePersonal))
        {

            Personais personal = Personais[nomePersonal];
            aluno.Personal = personal;
            personal.Alunos.Add(aluno);
            Console.WriteLine("Personal contratado com sucesso!");
        }
        else
        {
            Console.WriteLine("Personal não encontrado!");
        }
    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }

    Console.ReadLine();

    menu();
}    


void MarcarTreinoComPersonal()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do aluno:");
    string nome = Console.ReadLine()!;
    if (Alunos.ContainsKey(nome))
    {
        Alunos aluno = Alunos[nome];
        if (aluno.Personal is null)
        {
            Console.WriteLine("Aluno não tem personal ainda!");
        }
        else
        {
            Personais personal = aluno.Personal;
            Console.Write("Digite o dia que quer treinar : ");
            string dia = Console.ReadLine()!;
            Console.Write("Digite o horario que quer treinar : ");
            string horario = Console.ReadLine()!;
            Console.WriteLine("Qual treino quer fazer: ");
            string nomeTreino = Console.ReadLine()!;
            Console.Write("Digite o dia e horário que quer treinar (formato: yyyy-MM-dd HH:mm): ");
            string dataHoraInput = Console.ReadLine()!;
            if (!DateTime.TryParse(dataHoraInput, out DateTime dataHora))
            {
                Console.WriteLine("Data e hora inválida");
                Console.ReadLine();
                MarcarTreinoComPersonal();
            }
            if (aluno.Treinos.Any(t => t.Nome.Equals(nomeTreino)))
            {
                Treino treino = aluno.Treinos.First(t => t.Nome.Equals(nomeTreino));
                Console.WriteLine("Treino Encontrado");
                Solicitacao solicitacao1 = new Solicitacao(personal,aluno, dataHora,treino);
                aluno.Solicitacao.Add(solicitacao1);
                personal.solicitacaos.Add(solicitacao1);
            }
            else
            {
                Console.WriteLine("Treino não encontrado,tente novamente!");
                MarcarTreinoComPersonal();

            }
            Console.WriteLine($"Solicitação de Treino de {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
            Console.ReadLine();

            menu();
        }
    }
}

void AlunoVerSolicitaçõesDeTreino()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do Aluno:");
    string nome = Console.ReadLine()!;
    if (Alunos.ContainsKey(nome))
    {
        Alunos aluno = Alunos[nome];
        if (aluno.Solicitacao is null)
        {
            Console.WriteLine("Não há solicitações");
        }
        else {
            Console.WriteLine("Solicitações de Treino:");
            foreach (var solicitacao in aluno.Solicitacao)
            {
                Console.WriteLine($"Personal: {solicitacao.personal.nome} - Data: {solicitacao.DataHora} - Status: {solicitacao.Status}");
            }
        }
    }
    else
    {
        Console.WriteLine("Aluno não encontrado!");
    }
    Console.ReadLine();
    menu();
}

void Ver_AceitarSolicitacao()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do Personal:");
    string nome = Console.ReadLine()!;
    if (Personais.ContainsKey(nome))
    {
        Personais personal = Personais[nome];
        if (personal.solicitacaos is null)
        {
            Console.WriteLine("Não há solicitações");
        }
        else
        {
            Console.WriteLine("Solicitações de Treino:");
            foreach (var solicitacao in personal.solicitacaos)
            {
                if (solicitacao.Status== "Pendente")
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine($"Aluno: {solicitacao.aluno.nome} - Data: {solicitacao.DataHora} - Status: {solicitacao.Status}");
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Quer Aceitar essa solicitação(y para sim e n para não):");
                    string resposta = Console.ReadLine()!;
                    if (resposta == "y")
                    {
                        solicitacao.Status = "Aceito";
                        Console.WriteLine("Solicitação aceita com sucesso!");
                    }
                    else if (resposta == "n")
                    {
                        solicitacao.Status = "Recusado";
                        Console.WriteLine("Solicitação recusada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Resposta inválida!");
                    }
                }
                else
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine($"Aluno: {solicitacao.aluno.nome} - Data: {solicitacao.DataHora} - Status: {solicitacao.Status}");
                    Console.WriteLine("------------------------------------------------------------------");
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Personal não encontrado!");
    }
    Console.ReadLine();
    menu();
}
    menu();