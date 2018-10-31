using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Concursos;
using System.Collections.Generic;

namespace ProjetoLoterica.Aplicação.Features.Apostas
{
    public interface IApostaService
    {
        Aposta Add(Aposta aposta);
        Aposta Update(Aposta aposta);
        Aposta Get(long id);
        IList<Aposta> GetAll();
        void Delete(Aposta aposta);
        Concurso GetConcurso(long id);
        IList<Aposta> GetApostasComBolao(long id);
    }
}
