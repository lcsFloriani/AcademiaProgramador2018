using Projeto_loterica.Application.Interfaces;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Application.Features.Apostas
{
    public class ApostaService : IApostaService
    {
        private IApostaRepository _apostaRepository;

        public ApostaService(IApostaRepository apostaRepository)
        {
            _apostaRepository = apostaRepository;
        }

        public Aposta Add(Aposta objeto)
        {
                objeto.Validar();
                return _apostaRepository.Add(objeto);
        }

        public void Delete(Aposta objeto)
        {
                Validador.ValidateId(objeto.Id);
                _apostaRepository.Delete(objeto);
        }

        public IEnumerable<Aposta> GetAll()
        {
                var list = _apostaRepository.GetAll();
                foreach (var item in list)
                {
                    Validador.ValidateId(item.Id);
                }
                return list;
        }

        public Aposta GetById(long Id)
        {
                Validador.ValidateId(Id);
                Aposta aposta = _apostaRepository.GetById(Id);
                Validador.ValidateId(aposta.Id);
                return aposta;
        }

        public Aposta Update(Aposta objeto)
        {
                Validador.ValidateId(objeto.Id);
                objeto.Validar();
                return _apostaRepository.Update(objeto);
        }
    }
}
