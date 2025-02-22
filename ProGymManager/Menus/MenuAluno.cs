using ProGymManager.Dados;
using ProGymManager.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Menus
{
    internal class MenuAluno : Menu
    {
        Alunos alunoLogado;
        public void VerificaAluno(DAL<Alunos> alunos)
        {
            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Escreva sua Senha:");
            string senha = Console.ReadLine()!;
            alunoLogado = alunos.RecuperarPor(f => f.nome.ToUpper().Equals(nome.ToUpper()) && f.senha.Equals(senha));
            if (alunoLogado is not null)
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {alunoLogado.nome}!");
                Console.WriteLine("Logado");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Usuario e Senha não encontrados!");
            }
        }

        void VerTreinosPorAluno(DAL<Treino>treino)
        {
            Console.Clear();
            var listaDeTreinos = treino.listar().Where(t => t.Aluno.Id.Equals(alunoLogado.Id));
            if (listaDeTreinos.Count() == 0)
            {
                Console.WriteLine("Não há treinos cadastrados");
                Console.ReadLine();
                return;
            }

            foreach (var treinos in listaDeTreinos)
            {
                Console.WriteLine($"Treino: {treinos.Nome}");
                Console.WriteLine("\n");
                foreach (var exercicio in treinos.TreinoExercicios)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"Exercicio: {exercicio.Exercicio.Nome} -- {exercicio.Exercicio.Musculo}");
                    Console.WriteLine("---------------------------------------");
                }
            }
            Console.ReadLine();
        }

        void ContratarPersonal(DAL<Personais> personais,DAL<Alunos> alunos)
        {
            Console.Clear();
            var listaDePersonaisDisponiveis = personais.listar().Where(p => p.disponivel);

            Console.WriteLine("Personais Disponiveis:");
            foreach (var personal in listaDePersonaisDisponiveis)
            {
                personal.MostrarFicha();
            }
            Console.WriteLine("Digite o nome do Personal que quer contratar:");
            string nomePersonal = Console.ReadLine()!;
            var personalEscolhido = personais.RecuperarPor(p => p.nome.ToUpper().Equals(nomePersonal.ToUpper()));
            if (listaDePersonaisDisponiveis.Any(p=>p.Equals(personalEscolhido)))
            {
                alunoLogado.personal = personalEscolhido;
                alunoLogado.personalId = personalEscolhido.Id;
                alunos.Atualizar(alunoLogado);
                Console.WriteLine("Personal contratado com sucesso!");
            }
            else
            {
                Console.WriteLine("Personal não encontrado ou não disponivel!");
            }

            Console.ReadLine();
        }

        void MarcarTreinoComPersonal(DAL<Solicitacao>solicitacao,DAL<Treino>treino)
        {
            Console.Clear();

            if (alunoLogado.personal is null)
            {
                Console.WriteLine("Aluno não tem personal ainda!");
                Console.WriteLine("Contrate um no menu de Aluno!");
            }
            else
            {
                var listaDeTreinos = treino.listar().Where(t => t.Aluno.Id.Equals(alunoLogado.Id));
                Personais personal = alunoLogado.personal;
                Console.WriteLine("Qual treino quer fazer: ");
                string nomeTreino = Console.ReadLine()!;
                Console.Write("Digite o dia e horário que quer treinar (formato: yyyy-MM-dd HH:mm): ");
                string dataHoraInput = Console.ReadLine()!;
                if (!DateTime.TryParse(dataHoraInput, out DateTime dataHora))
                {
                    Console.WriteLine("Data e hora inválida");
                    Console.ReadLine();
                }
                if (listaDeTreinos.Any(t=>t.Nome.ToUpper().Equals(nomeTreino.ToUpper())))
                {
                    
                    Treino treinoescolhido = treino.RecuperarPor(t => t.Nome.ToUpper().Equals(nomeTreino.ToUpper()));
                    Console.WriteLine("Treino Encontrado");
                    Solicitacao solicitacao1 = new Solicitacao(personal, alunoLogado, dataHora, treinoescolhido);
                    alunoLogado.solicitacoes.Add(solicitacao1);
                    personal.solicitacaos.Add(solicitacao1);
                    solicitacao.Adicionar(solicitacao1);
                    Console.WriteLine($"Solicitação de Treino de {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
                    Console.ReadLine();
                }
                else
                {
                
                    var listaDeTodosTreinos=treino.listar();
                    if (listaDeTodosTreinos.Any(t => t.Nome.Equals("Personalizado")))
                    {
                        Treino personalizado = treino.RecuperarPor(t => t.Nome.Equals("Personalizado"));
                        Solicitacao solicitacao1 = new Solicitacao(personal, alunoLogado, dataHora, personalizado);
                        alunoLogado.solicitacoes.Add(solicitacao1);
                        personal.solicitacaos.Add(solicitacao1);
                        Console.WriteLine($"Solicitação de Treino {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
                        Console.ReadLine();
                    }
                    else
                    {
                        List<Exercicios> exercicios = new List<Exercicios>();
                        Treino treinoPersonalizado = new Treino("Personalizado", alunoLogado.Id,exercicios );
                        treino.Adicionar(treinoPersonalizado);
                        Solicitacao solicitacao1 = new Solicitacao(personal, alunoLogado, dataHora, treinoPersonalizado);
                        alunoLogado.solicitacoes.Add(solicitacao1);
                        personal.solicitacaos.Add(solicitacao1);
                        Console.WriteLine($"Solicitação de Treino {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
                        Console.ReadLine();
                    }
                    
                    
                }
                
            }
        }
        void AlunoVerSolicitaçõesDeTreino(DAL<Solicitacao>solicitacoes)
        {
            Console.Clear();
            var solicitacoesDoAluno = solicitacoes.listar().Where(s => s.aluno.Id.Equals(alunoLogado.Id));
            if (solicitacoesDoAluno is null)
            {
                Console.WriteLine("Não há solicitações");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Solicitações de Treino:");
                foreach (var solicitacao in solicitacoesDoAluno)
                {
                    Console.WriteLine($"Personal: {solicitacao.personal.nome} - Data: {solicitacao.DataHora} - Status: {solicitacao.Status}");
                }
                Console.ReadLine();
            }
        }




        public override void Executar(DAL<Funcionarios> funcionarios, DAL<Personais> personais, DAL<Alunos> alunos, DAL<Solicitacao> solicitacoes, DAL<Treino> treino, DAL<Exercicios> exercicios)
        {
            int sair = 1;
            while (sair == 1)
            {
                if (alunoLogado is null)
                {
                    VerificaAluno(alunos);
                }
                else
                {
                    Console.Clear();
                    ExibirTituloDaOpcao("Menu do Aluno:\n");
                    Console.WriteLine("1 - Aluno ver treino");
                    Console.WriteLine("2 - Contratar Personal");
                    Console.WriteLine("3 - Marcar treino com Personal");
                    Console.WriteLine("4 - Ver solicitações");
                    Console.WriteLine("5 - Sair");

                    Console.Write("Sua opção: ");
                    int opcao = int.Parse(Console.ReadLine()!);
                    switch (opcao)
                    {
                        case 1:
                            VerTreinosPorAluno(treino);
                            break;
                        case 2:
                            ContratarPersonal(personais,alunos);
                            break;
                        case 3:
                            MarcarTreinoComPersonal(solicitacoes,treino);
                            break;
                        case 4:
                            AlunoVerSolicitaçõesDeTreino(solicitacoes);
                            break;
                        case 5:
                            sair = Sair();
                            alunoLogado = null;
                            break;
                        default:
                            Console.WriteLine("Opção incorreta!");
                            break;
                    }
                }
            }

              
            MenuInicial();
        }




    }
}
            
