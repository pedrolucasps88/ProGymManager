using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Modelos
{
    internal class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Alunos Aluno { get; set; } // Referência ao Aluno dono do treino
        public List<Exercicios> Exercicios { get; set; } = new List<Exercicios>();

        public Treino(string nome, List<Exercicios> exercicios,Alunos aluno)
        {
            Id = new Random().Next(1, 1000);
            this.Nome = nome;
            this.Exercicios = exercicios;
            this.Aluno=aluno;
        }
    }
}
