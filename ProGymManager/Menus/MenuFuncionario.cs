using ProGymManager.Modelos;
using System.Security;
using ProGymManager.Dados;

namespace ProGymManager.Menus
{
    internal class MenuFuncionario:Menu
    {
        Funcionarios funcionarioLogado;
        public void VerificaFuncionario(DAL<Funcionarios> funcionarios)
        {

            Console.WriteLine("Digite o seu nome:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Escreva sua Senha:");
            string senha = Console.ReadLine()!;
            funcionarioLogado=funcionarios.RecuperarPor(f => f.nome.ToUpper().Equals(nome.ToUpper()) && f.senha.Equals(senha));
            if (funcionarioLogado is not null)
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {funcionarioLogado.nome}!");
                Console.WriteLine("Logado");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Usuario e Senha não encontrados!");
            }
        }




        void CadastrarAlunos(DAL<Alunos> alunos)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Alunos");
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite o CPF do aluno:");
            string cpf = Console.ReadLine()!;
            string senha = "123";
            Alunos aluno = new Alunos(nome, cpf, senha);
            alunos.Adicionar(aluno);
            Console.WriteLine($"O aluno {aluno.nome} foi Cadastrado com sucesso!");
            Console.ReadLine();
        }

        void CadastrarPersonal(DAL<Personais> personais)
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Personal");
            Console.WriteLine("Digite o nome do Personal:");
            string nome = Console.ReadLine()!;
            Console.WriteLine("Digite o CPF do Personal:");
            string cpf = Console.ReadLine()!;
            string senha = "123";
            Personais personal = new Personais(nome, cpf,senha);
            personais.Adicionar(personal);
            Console.WriteLine($"O Personal {personal.nome} foi Cadastrado com sucesso!");
            Console.ReadLine();
        }

        void VerAlunos(DAL<Alunos> alunos)
        {

            Console.Clear();
            Console.WriteLine("Alunos:");
            var listaDeAlunos= alunos.listar();
            foreach (var aluno in listaDeAlunos)
            {
                aluno.MostrarFicha();
            }
            Console.ReadLine();
        }

        void VerPersonais(DAL<Personais> personais)
        {
            Console.Clear();
            Console.WriteLine("Personais:");
            var listaDePersonais = personais.listar();
            foreach (var personal in listaDePersonais)
            {
                personal.MostrarFicha();
            }
            Console.ReadLine();
        }

        public override void Executar(DAL<Funcionarios> funcionarios, DAL<Personais> personais, DAL<Alunos> alunos, DAL<Solicitacao> solicitacoes, DAL<Treino> treino, DAL<Exercicios> exercicios)
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
                            CadastrarAlunos(alunos);
                            break;
                        case 2:
                            CadastrarPersonal(personais);
                            break;
                        case 3:
                            VerAlunos(alunos);
                            break;
                        case 4:
                            VerPersonais(personais);
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
