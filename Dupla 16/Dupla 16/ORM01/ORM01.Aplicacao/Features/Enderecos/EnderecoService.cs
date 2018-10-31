using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM01.Dominio.Features.Enderecos;

namespace ORM01.Aplicacao.Features.Enderecos
{
    public class EnderecoService : IEnderecoService
    {
        IEnderecoRepository _EnderecoRepository;
        
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _EnderecoRepository = enderecoRepository;
        }
        
        public void Add(Endereco endereco)
        {
            endereco.Validar();
             _EnderecoRepository.Add(endereco);
        }

        public void Delete(Endereco endereco)
        {
            _EnderecoRepository.Delete(endereco);
        }

        public List<Endereco> GetAll()
        {
            return _EnderecoRepository.GetAll();
        }

        public Endereco GetById(long Id)
        {
            return _EnderecoRepository.GetById(Id);
        }

        public void Update(Endereco endereco)
        {
            endereco.Validar();
             _EnderecoRepository.Update(endereco);
        }
    }
}
