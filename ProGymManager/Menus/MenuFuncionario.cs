using ProGymManager.Modelos;
using System.Security;

namespace ProGymManager.Menus
{
    internal class MenuFuncionario:Menu
    {
        Funcionarios funcionarioLogado;
        public void VerificaFuncionario(Dictionary<string, Funcionarios> funcionarios)
        {

            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine()!;
            Console.WriteLine(funcionarios[nome].nome);
            Console.WriteLine(funcionarios[nome].senha);
            Console.WriteLine("Escreva sua Senha:");
            string senha = Console.ReadLine()!;
            if (funcionarios.ContainsKey(nome))
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {nome}!");
                funcionarioLogado = funcionarios[nome];
                Console.WriteLine(funcionarioLogado.nome);
                Console.WriteLine(funcionarioLogado.senha);
                bool validação=funcionarioLogado.VerificaSenha(senha);
                Console.WriteLine(validação);
                if (validação==true)
                {
                    Console.WriteLine("Logado");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Senha incorreta!");
                    funcionarioLogado = null;
                    return;
                }
            }
            else
            {
                Console.WriteLine("Nome não encontrado!");
            }
        }




        void CadastrarAlunos(Dictionary<string, Alunos> Alunos)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Alunos");
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite o CPF do aluno:");
            string cpf = Console.ReadLine()!;
            string senha = "123";
            Alunos aluno = new Alunos(nome, cpf, senha);
            Alunos.Add(aluno.nome, aluno);
            Console.WriteLine($"O aluno {aluno.nome} foi Cadastrado com sucesso!");
        }

        void CadastrarPersonal(Dictionary<string, Personais> Personais)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Personal");
            Console.WriteLine("Digite o nome do Personal:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite o CPF do Personal:");
            string cpf = Console.ReadLine()!;
            string senha = "123";
            Personais personal = new Personais(nome, cpf,senha);
            Personais.Add(personal.nome, personal);
            Console.WriteLine($"O Personal {personal.nome} foi Cadastrado com sucesso!");
        }

        void VerAlunos(Dictionary<string, Alunos> Alunos)
        {

            Console.Clear();
            Console.WriteLine("Alunos:");
            foreach (var alunos in Alunos)
            {
                alunos.Value.MostrarFicha();
            }
            Console.ReadLine();
        }

        void VerPersonais(Dictionary<string, Personais> Personais)
        {
            Console.Clear();
            Console.WriteLine("Personais:");
            foreach (var personal in Personais)
            {
                personal.Value.MostrarFicha();
            }
            Console.ReadLine();
        }

        public override void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos)
        {
            int sair = 1;
            while (sair!=0)
            {
                Console.WriteLine("entrou aqui");
                if (funcionarioLogado is null)
                {
                    VerificaFuncionario(funcionarios);
                }
                else
                {
                    Console.Clear();
                    ExibirTituloDaOpcao("Menu do Funcionario:\n");
                    Console.WriteLine("Escolha uma opção: ");
                    Console.WriteLine("1 - Cadastrar Alunos");
                    Console.WriteLine("2 - Cadastrar Personal");
                    Console.WriteLine("3 - Ver Alunos");
                    Console.WriteLine("4 - Ver Personais");
                    Console.WriteLine("5 - Sair");

                    Console.Write("Sua opção: ");
                    int opcao = int.Parse(Console.ReadLine()!);
                    switch (opcao)
                    {
                        case 1:
                            CadastrarAlunos(Alunos);
                            break;
                        case 2:
                            CadastrarPersonal(Personais);
                            break;
                        case 3:
                            VerAlunos(Alunos);
                            break;
                        case 4:
                            VerPersonais(Personais);
                            break;
                        case 5:
                            sair =Sair();
                            funcionarioLogado = null;
                            break;
                        default:
                            Console.WriteLine("Opção incorreta!");
                            break;
                    }
                }
            }
           

        }



    }
}
