
using ProGymManager.Menus;
using ProGymManager.Modelos;
using ProGymManager.Dados;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.EntityFrameworkCore;


Menu menu = new Menu();
var context = new ProGymManagerContext();
DAL<Funcionarios> funcionarios = new(context);
DAL<Alunos> alunos = new(context);
DAL<Personais> personais = new(context);
DAL<Exercicios> exercicios = new(context);
DAL<Solicitacao> solicitacoes = new(context);
DAL<Treino> treino = new(context);

//Funcionarios funcionario1 = new Funcionarios("Pedro", "12345678904", "123");
//funcionarios.Adicionar(funcionario1);

//Dictionary<string, Funcionarios> Funcionarios = new();
//Funcionarios funcionario = new Funcionarios("Lucas", "12345678904", "123");
//Funcionarios funcionario1 = new Funcionarios("Julia", "12345678905", "123");
//Funcionarios.Add(funcionario.nome, funcionario);
//Funcionarios.Add(funcionario1.nome, funcionario1);

//Dictionary<string, Alunos> Alunos = new();
//Alunos alunos = new Alunos("João", "12345678900","123") { ativo = false};
//Alunos alunos1 = new Alunos("Maria", "12345678901", "123") { plano = 2 };
//Alunos.Add(alunos.nome, alunos);
//Alunos.Add(alunos1.nome, alunos1);


//Dictionary<string, Personais> Personais = new();
//Personais personal = new Personais("Pedro", "12345678902", "123");
//Personais personal1 = new Personais("Ana", "12345678903", "123");
//Personais.Add(personal.nome, personal);
//Personais.Add(personal1.nome, personal1);



Dictionary<int,Menu> login = new();
login.Add(1, new MenuFuncionario());
login.Add(2, new MenuPersonal());
login.Add(3, new MenuAluno());
login.Add(4, new MenuSair());

int opcaoEscolhida = menu.MenuInicial();
while (opcaoEscolhida != 4)
{
    login[opcaoEscolhida].Executar(funcionarios, personais, alunos,solicitacoes,treino,exercicios);
    opcaoEscolhida = menu.MenuInicial(); // Atualiza a opção escolhida após a execução do menu
}

Console.WriteLine("Programa encerrado. tchau tchau!");

//falta alguns detalhes
//dar uma limpada nos códigos
//e depois fazer o teste de unidade

//var optionsBuilder = new DbContextOptionsBuilder<ProGymManagerContext>();
//optionsBuilder.UseSqlServer("Server=localhost;User Id=root;Password=1234;Database=ProGymManagerDB");

//using (var context = new ProGymManagerContext(optionsBuilder.Options))
//{
//    context.Database.Migrate(); // Esse comando aplica qualquer migração pendente
//}