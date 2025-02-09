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
        public void VerificaAluno(Dictionary<string, Alunos> alunos)
        {
            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite sua Senha: ");
            string senha = Console.ReadLine()!;
            if (alunos.ContainsKey(nome))
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {nome}!");
                alunoLogado = alunos[nome];
                bool validação = alunoLogado.VerificaSenha(senha);
                if (validação)
                {
                    Console.WriteLine("Logado");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Senha incorreta!");
                    alunoLogado = null;
                    return;
                }
            }
            else
            {
                Console.WriteLine("Nome não encontrado!");
            }
        }

        void VerTreinosPorAluno(Alunos alunologado)
        {
            Console.Clear();

            foreach (var treino in alunoLogado.Treinos)
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
            Console.ReadLine();
        }

        void ContratarPersonal(Alunos alunoLogado, Dictionary<string, Personais> Personais)
        {
            Console.Clear();
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
                alunoLogado.Personal = personal;
                personal.Alunos.Add(alunoLogado);
                Console.WriteLine("Personal contratado com sucesso!");
            }
            else
            {
                Console.WriteLine("Personal não encontrado!");
            }

            Console.ReadLine();
        }

        void MarcarTreinoComPersonal(Alunos alunoLogado)
        {
            Console.Clear();

            if (alunoLogado.Personal is null)
            {
                Console.WriteLine("Aluno não tem personal ainda!");
                Console.WriteLine("Contrate um no menu de Aluno!");
            }
            else
            {
                Personais personal = alunoLogado.Personal;
                Console.WriteLine("Qual treino quer fazer: ");
                string nomeTreino = Console.ReadLine()!;
                Console.Write("Digite o dia e horário que quer treinar (formato: yyyy-MM-dd HH:mm): ");
                string dataHoraInput = Console.ReadLine()!;
                if (!DateTime.TryParse(dataHoraInput, out DateTime dataHora))
                {
                    Console.WriteLine("Data e hora inválida");
                    Console.ReadLine();
                }
                if (alunoLogado.Treinos.Any(t => t.Nome.Equals(nomeTreino)))
                {
                    Treino treino = alunoLogado.Treinos.First(t => t.Nome.Equals(nomeTreino));
                    Console.WriteLine("Treino Encontrado");
                    Solicitacao solicitacao1 = new Solicitacao(personal, alunoLogado, dataHora, treino);
                    alunoLogado.Solicitacao.Add(solicitacao1);
                    personal.solicitacaos.Add(solicitacao1);
                    Console.WriteLine($"Solicitação de Treino de {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
                    Console.ReadLine();
                }
                else
                {
                    List<Exercicios> exercicios = new List<Exercicios>();
                    Treino treinoPersonalizado = new Treino("Personalizado",exercicios, alunoLogado);
                    Solicitacao solicitacao1 = new Solicitacao(personal, alunoLogado, dataHora,treinoPersonalizado);
                    alunoLogado.Solicitacao.Add(solicitacao1);
                    personal.solicitacaos.Add(solicitacao1);
                    Console.WriteLine($"Solicitação de Treino {nomeTreino} marcado com {personal.nome} no dia {dataHora}");
                    Console.ReadLine();
                }
                
            }
        }
        void AlunoVerSolicitaçõesDeTreino(Alunos alunoLogado)
        {
            Console.Clear();
            if (alunoLogado.Solicitacao is null)
            {
                Console.WriteLine("Não há solicitações");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Solicitações de Treino:");
                foreach (var solicitacao in alunoLogado.Solicitacao)
                {
                    Console.WriteLine($"Personal: {solicitacao.personal.nome} - Data: {solicitacao.DataHora} - Status: {solicitacao.Status}");
                }
                Console.ReadLine();
            }
        }




        public override void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos)
        {
            int sair = 1;
            while (sair == 1)
            {
                if (alunoLogado is null)
                {
                    VerificaAluno(Alunos);
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
                            VerTreinosPorAluno(alunoLogado);
                            break;
                        case 2:
                            ContratarPersonal(alunoLogado, Personais);
                            break;
                        case 3:
                            MarcarTreinoComPersonal(alunoLogado);
                            break;
                        case 4:
                            AlunoVerSolicitaçõesDeTreino(alunoLogado);
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
            
