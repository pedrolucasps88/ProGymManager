using ProGymManager.Dados;
using ProGymManager.Modelos;
using ProGymManager.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Menus;

internal class MenuPersonal:Menu
{
    Personais personalLogado;

    public void VerificaPersonal(DAL<Personais> personais)
    {
        Console.WriteLine("Digite o seu nome:");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Escreva sua Senha:");
        string senha = Console.ReadLine()!;
        personalLogado = personais.RecuperarPor(f => f.nome.ToUpper().Equals(nome.ToUpper()) && f.senha.Equals(senha));
        if (personalLogado is not null)
        {
            Console.Clear();
            Console.WriteLine($"Bem vindo {personalLogado.nome}!");
            Console.WriteLine("Logado");
            Console.ReadLine();

        }
        else
        {
            Console.WriteLine("Usuario e Senha não encontrados!");
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

    void CriarTreino(DAL<Alunos> alunos,DAL<Exercicios> exercicios,DAL<Treino> treino)
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do aluno:");
        string nome = Console.ReadLine()!;
        int sairT = 0;
        var alunoEscolhido = alunos.RecuperarPor(a=>a.nome.ToUpper().Equals(nome.ToUpper()));
        
        if (alunoEscolhido is not null)
        {
            Console.WriteLine("Digite o Nome do treino do aluno:");
            string nomeTreino = Console.ReadLine()!;
            List<Exercicios> exerciciosTreino = new List<Exercicios>();
            while (sairT == 0)
            {
                var listaDeExercicios = exercicios.listar();
                Console.WriteLine("Digite o Exercicio do treino do aluno:");
                string exercicio = Console.ReadLine()!;
                Console.WriteLine("Digite o Musculo do exercicio:");
                string musculo = Console.ReadLine()!;
                Exercicios ex = new Exercicios(exercicio, musculo);
                if (!listaDeExercicios.Any(e => e.Nome.Equals(exercicio, StringComparison.OrdinalIgnoreCase)))
                {
                    exercicios.Adicionar(ex);
                }

                exerciciosTreino.Add(ex);

                Console.WriteLine("Deseja adicionar mais exercicios? 1-Sim 2-Não");
                int sair = int.Parse(Console.ReadLine()!);
                if (sair == 2)
                {
                    sairT = 1;
                }
            }

            Treino treinoAluno = new Treino
            {
                Nome = nomeTreino,
                AlunoId = alunoEscolhido.Id,
                TreinoExercicios = exerciciosTreino.Select(e => new TreinoExercicio
                {
                    ExercicioId = e.Id
                }).ToList()
            };

            treino.Adicionar(treinoAluno);
            alunoEscolhido.treinos.Add(treinoAluno);
            Console.WriteLine("Treino cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado!");
        }
        Console.ReadLine();
    }


    void Ver_AceitarSolicitacao(DAL<Solicitacao> solicitacoes)
    {
        Console.Clear();

        var solicitacoesDoPersonal = solicitacoes.listar().Where(s => s.personal.Id.Equals(personalLogado.Id));
            if (solicitacoesDoPersonal is null)
            {
                Console.WriteLine("Não há solicitações");
            }
            else
            {
                Console.WriteLine("Solicitações de Treino:");
                foreach (var solicitacao in solicitacoesDoPersonal)
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
                            solicitacoes.Atualizar(solicitacao);
                        Console.WriteLine("Solicitação aceita com sucesso!");
                        }
                        else if (resposta == "n")
                        {
                            solicitacao.Status = "Recusado";
                            solicitacoes.Atualizar(solicitacao);
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

    public override void Executar(DAL<Funcionarios> funcionarios, DAL<Personais> personais, DAL<Alunos> alunos, DAL<Solicitacao> solicitacoes, DAL<Treino> treino, DAL<Exercicios> exercicios)
    {
        int sair = 1;
        
        while (sair == 1)
        {
            if (personalLogado is null)
            {
                VerificaPersonal(personais);
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
                        CriarTreino(alunos,exercicios,treino);
                        break;
                    case 3:
                        Ver_AceitarSolicitacao(solicitacoes);
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
