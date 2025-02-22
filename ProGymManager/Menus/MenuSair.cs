using ProGymManager.Dados;
using ProGymManager.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Menus
{
    internal class MenuSair:Menu
    {
        public override void Executar(DAL<Funcionarios> funcionarios, DAL<Personais> personais, DAL<Alunos> alunos, DAL<Solicitacao> solicitacoes, DAL<Treino> treino, DAL<Exercicios> exercicios)
        {
            Console.WriteLine("Tchau tchau :)");
        }
    }
}
