using FlorianiProva.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Comum.ObjetosMae.Alunos
{
    public static class AlunoObjetoMae
    {
        public static Aluno AlunoComNomeEmBranco() => new Aluno
        {
            Nome = "",
            Idade = 20 
        };
        public static Aluno AlunoComNomeMuitoGrande() => new Aluno
        {
            Nome = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            Idade = 20
        };
        public static Aluno AlunoComIdadeNegativa() => new Aluno
        {
           Nome = "Lucas" ,
           Idade = -150
        };
        public static Aluno AlunoValido() => new Aluno
        {
            Id = 20,
            Nome = "Lucas",
            Idade = 20
        };
    }
}
