using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Aplicação.Features.Boloes
{
    public interface IBolaoService
    {
        Bolao Add(Bolao bolao);
        Bolao Update(Bolao bolao);
        Bolao Get(long id);
        IList<Bolao> GetAll();
        void Delete(Bolao bolao);
        void GerarBolao(Bolao bolao, Concurso concursos, int numeroApostas);
    }
}
