using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Turma Turma
        {
            get
            {
                return new Turma
                {
                    Id = 1,
                    Descricao = "Artes"
                };
            }
        }

        public static List<Turma> turmaList
        {
            get
            {
                List<Turma> lista = new List<Turma>();

                lista.Add(new Turma()
                {
                    Id = 1,
                    Descricao = "Artes"
                });

                lista.Add(new Turma()
                {
                    Id = 2,
                    Descricao = "Artes"
                });

                lista.Add(new Turma()
                {
                    Id = 3,
                    Descricao = "Artes"
                });

                return lista;
            }
        }
    }


}
