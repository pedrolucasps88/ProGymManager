using ProGymManager.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Modelos
{
    public class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? AlunoId { get; set; } // Permite valores nulos
        public Alunos Aluno { get; set; } // Referência ao Aluno dono do treino

        public ICollection<TreinoExercicio> TreinoExercicios { get; set; } = new List<TreinoExercicio>();
        public Treino()
        {
            
        }
        public Treino(string nome, int alunoId, IEnumerable<Exercicios> exercicios)
        {
            Nome = nome;
            AlunoId = alunoId;

            // Associa os exercícios ao treino usando a tabela de junção
            TreinoExercicios = exercicios.Select(e => new TreinoExercicio
            {
                ExercicioId = e.Id
            }).ToList();
        }

        public int GetId()
        {
            return Id;
        }
    }
}
