using FlorianiProva.Dominio.Funcionalidades.Contatos;
using FlorianiProva.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Aplicacao
{
    public class ContatoService : IContatoService
    {
        private ContatoRepository _contatoRepository;

        public ContatoService(ContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Adicionar(Contato entidade)
        {
            try
            {
                entidade.Valida();
                _contatoRepository.Adicionar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Contato entidade)
        {
            try
            {
                if (_contatoRepository.BuscarContato(entidade.Id))
                {
                    _contatoRepository.Deletar(entidade);
                }
                else
                {
                    throw new Exception("O contato não pode ser excluido pois faz parte de um compromisso!");
                }
                _contatoRepository.Deletar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public void Editar(Contato entidade)
        {
            try
            {
                entidade.Valida();
                _contatoRepository.Editar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Contato> TrazerTodos()
        {
            return _contatoRepository.TrazerTodos();
        }
    }
}
