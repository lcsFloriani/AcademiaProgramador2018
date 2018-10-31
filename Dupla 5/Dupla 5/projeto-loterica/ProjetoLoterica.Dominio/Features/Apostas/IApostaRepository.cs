using ProjetoLoterica.Dominio.Features.Concursos;
using System.Collections.Generic;

namespace ProjetoLoterica.Dominio.Features.Apostas
{
    public interface IApostaRepository
    {
        Aposta Add(Aposta aposta);
        Aposta Update(Aposta aposta);
        Aposta Get(long id);
        IList<Aposta> GetAll();
        IList<Aposta> GetApostasComBolao(long id);
        void Delete(Aposta aposta);
        Concurso GetConcurso(long id);
    }
}
