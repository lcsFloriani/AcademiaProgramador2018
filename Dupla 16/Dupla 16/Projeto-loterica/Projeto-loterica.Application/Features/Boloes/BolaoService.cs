using Projeto_loterica.Application.Interfaces;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Application.Features.Boloes
{
    public class BolaoService : IBolaoService
    {
        IBolaoRepository _bolaoRepository;
        public BolaoService(IBolaoRepository bolaoRepository)
        {
            _bolaoRepository = bolaoRepository;
        }
        
        public Bolao Add(Bolao objeto)
        {
                objeto.validar();
                return _bolaoRepository.Add(objeto);
        }

        public void Delete(Bolao objeto)
        {
                Validador.ValidateId(objeto.Id);
                _bolaoRepository.Delete(objeto);
        }

        public IEnumerable<Bolao> GetAll()
        {
                var list = _bolaoRepository.GetAll();
                foreach (var item in list)
                {
                    Validador.ValidateId(item.Id);
                }
                return list;
        }

        public Bolao GetById(long Id)
        {
                Validador.ValidateId(Id);
                var objeto = _bolaoRepository.GetById(Id);
                Validador.ValidateId(objeto.Id);
                return objeto;
        }

        public Bolao Update(Bolao objeto)
        {
                objeto.validar();
                Validador.ValidateId(objeto.Id);
                return _bolaoRepository.Update(objeto);
        }
    }
}
