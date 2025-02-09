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
        public override void Executar(Dictionary<string, Funcionarios> funcionarios, Dictionary<string, Personais> Personais, Dictionary<string, Alunos> Alunos)
        {
            Console.WriteLine("Tchau tchau :)");
        }
    }
}
