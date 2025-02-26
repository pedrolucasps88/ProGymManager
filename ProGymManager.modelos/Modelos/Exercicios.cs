using ProGymManager.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Modelos
{
    public class Exercicios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Musculo { get; set; }

        public ICollection<TreinoExercicio> TreinoExercicios { get; set; } = new List<TreinoExercicio>();
        public Exercicios()
        {
            
        }
        public Exercicios(string nome,string musculo)
        {
            this.Nome = nome;
            this.Musculo = musculo;

        }
    }
}
