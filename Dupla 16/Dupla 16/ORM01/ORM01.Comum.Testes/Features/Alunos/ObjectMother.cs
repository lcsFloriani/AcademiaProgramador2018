using ORM01.Dominio.Features.Alunos;
using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;

namespace ORM01.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
       

        public static List<Aluno> alunoList
        {
            get
            {
                List<Aluno> lista = new List<Aluno>();

                lista.Add(new Aluno()
                {
                    Id = 1,
                    Nome = "Fabricio",
                    Aniversario = DateTime.Now.AddYears(22),
                });

                lista.Add(new Aluno()
                {
                    Id = 2,
                    Nome = "João",
                    Aniversario = DateTime.Now.AddYears(22),
                });

                lista.Add(new Aluno()
                {
                    Id = 3,
                    Nome = "José",
                    Aniversario = DateTime.Now.AddYears(22),
                });

                return lista;
            }
        }

        public static Aluno aluno
        {
            get
            {
                return new Aluno
                {
                    Id = 1,
                    Nome = "Fabricio",
                    Aniversario = DateTime.Now.AddYears(22),
                    Endereco = endereco,
                    Turma = Turma
                };
            }
        }
    }
}
