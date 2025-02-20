using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Modelos.Modelos
{
    public class TreinoExercicio
    {
        public int TreinoId { get; set; } // Relacionamento com a tabela Treinos
        public Treino Treino { get; set; } // Objeto de treino associado

        public int ExercicioId { get; set; } // Relacionamento com a tabela Exercicios
        public Exercicios Exercicio { get; set; } // Objeto de exercício associado
    }
}
