using ProGymManager.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Menus;

internal class MenuPersonal:Menu
{
    Personais personalLogado;

    public void VerificaPersonal(Dictionary<string, Personais> personais)
    {
        Console.WriteLine("Digite o seu nome:");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Digite sua Senha: ");
        string senha = Console.ReadLine()!;
        if (personais.ContainsKey(nome))
        {
            Console.Clear();
            Console.WriteLine($"Bem vindo {nome}!");
            personalLogado = personais[nome];
            bool validação = personalLogado.VerificaSenha(senha);
            if (validação)
            {
                Console.WriteLine("Logado");
                Console.ReadLine(); 
            }
            else
            {
                Console.WriteLine("Senha incorreta!");
                personalLogado = null;
                return;
            }
        }
        else
        {
            Console.WriteLine("Nome não encontrado!");
        }
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

            var ExerciciosPorMusculo = exercicios.Where(ex => ex.Musculo.ToUpper().Contains(musculoProcurado.ToUpper())).ToList();
            foreach (var item in ExerciciosPorMusculo)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Exercicio: {item.Nome}");
                Console.WriteLine("------------------------");
            }
            Console.ReadLine();
        }
    }

    void CriarTreino(Dictionary<string, Alunos> Alunos)
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
            while (sairT == 0)
            {
                Console.WriteLine("Digite o Exercicio do treino do aluno:");
                string exercicio = Console.ReadLine()!;
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
            Treino treinoAluno = new Treino(nomeTreino, treino, aluno);
            aluno.Treinos.Add(treinoAluno);
            Console.WriteLine("Treino cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado!");
        }
        Console.ReadLine();
    }


    void Ver_AceitarSolicitacao(Personais personalLogado)
    {
        Console.Clear();
       
            
            if (personalLogado.solicitacaos is null)
            {
                Console.WriteLine("Não há solicitações");
            }
            else
            {
                Console.WriteLine("Solicitações de Treino:");
                foreach (var solicitacao in personalLogado.solicitacaos)
                {
                    if (solicitacao.Status == "Pendente")
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
        Console.ReadLine();
    }

    public override void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos)
    {
        int sair = 1;
        
        while (sair == 1)
        {
            if (personalLogado is null)
            {
                VerificaPersonal(Personais);
            }
            else
            {
                Console.Clear();
                ExibirTituloDaOpcao("Menu do Personal:\n");
                Console.WriteLine("1 - Ver Exercicios no Banco de dados");
                Console.WriteLine("2 - Criar treino para alunos");
                Console.WriteLine("3 - Ver/Aceitar solicitações");
                Console.WriteLine("4 - Sair");

                Console.Write("Sua opção: ");
                int opcao = int.Parse(Console.ReadLine()!);
                switch (opcao)
                {
                    case 1:
                        VerExerciciosPorMusculo();
                        break;
                    case 2:
                        CriarTreino(Alunos);
                        break;
                    case 3:
                        Ver_AceitarSolicitacao(personalLogado);
                        break;
                    case 4:
                        sair = Sair();
                        personalLogado = null;
                        break;
                    default:
                        Console.WriteLine("Opção incorreta!");
                        break;
                }

            }
        }


    }




}
