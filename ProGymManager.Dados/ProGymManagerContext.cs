using Microsoft.EntityFrameworkCore;
using ProGymManager.Modelos;
using ProGymManager.Modelos.Modelos;

namespace ProGymManager.Dados
{
    public class ProGymManagerContext : DbContext
    {
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Exercicios> Exercicios { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Personais> Personais { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<Treino> Treinos { get; set; }

        // Construtor com parâmetros (já existente)
        public ProGymManagerContext(DbContextOptions<ProGymManagerContext> options) : base(options)
        { }

        // Construtor sem parâmetros para suportar o Design Time (em migrations, por exemplo)
        public ProGymManagerContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ProGymManagerDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela de junção TreinoExercicio
            modelBuilder.Entity<TreinoExercicio>()
                .HasKey(te => new { te.TreinoId, te.ExercicioId }); // Define a chave primária composta

            modelBuilder.Entity<TreinoExercicio>()
                .HasOne(te => te.Treino)
                .WithMany(t => t.TreinoExercicios)
                .HasForeignKey(te => te.TreinoId);

            modelBuilder.Entity<TreinoExercicio>()
                .HasOne(te => te.Exercicio)
                .WithMany(e => e.TreinoExercicios)
                .HasForeignKey(te => te.ExercicioId);
        }
    }
}
