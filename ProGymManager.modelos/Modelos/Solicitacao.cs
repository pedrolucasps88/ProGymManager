﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Modelos;

public class Solicitacao
{
    public int Id { get; set; }
    public Personais personal { get; set; }
    public Alunos aluno { get; set; }

    public DateTime DataHora { get; set; }

    public Treino treino { get; set; }

    public string Status { get; set; } = "Pendente";

    public Solicitacao()
    {
        
    }
    public Solicitacao(Personais personal,Alunos aluno, DateTime DataHora, Treino treino)
    {
        this.personal = personal;
        this.aluno = aluno;
        this.DataHora = DataHora;
        this.treino = treino;

    }

}
