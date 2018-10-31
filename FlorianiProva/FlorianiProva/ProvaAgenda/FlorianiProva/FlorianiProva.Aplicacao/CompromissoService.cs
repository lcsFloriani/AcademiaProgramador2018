using FlorianiProva.Dominio.Funcionalidades.Compromissos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Infra.Data;
using FlorianiProva.Dominio.Funcionalidades.Contatos;

namespace FlorianiProva.Aplicacao
{
    public class CompromissoService : ICompromissoService
    {
        private CompromissoRepository _compromissoRepository;

        public CompromissoService(CompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }

        public void Adicionar(Compromisso entidade)
        {
            try
            {
                IList<Contato> contatosList = entidade.Contatos;

                entidade.Valida();

                Compromisso aux = _compromissoRepository.Adicionar(entidade);

                foreach (var item in contatosList)
                {
                    _compromissoRepository.AdicionarContatos_Compromisso(Convert.ToInt32(aux.Id), item.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Compromisso entidade)
        {
            try
            {
                _compromissoRepository.Deletar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Compromisso entidade)
        {
            try
            {
                entidade.Valida();
                IList<Contato> contatosList = entidade.Contatos;
                _compromissoRepository.DeletarTabelaAuxiliar(entidade);

                

                Compromisso aux = _compromissoRepository.Editar(entidade);

                foreach (var item in contatosList)
                {
                    _compromissoRepository.AdicionarContatos_Compromisso(Convert.ToInt32(aux.Id), item.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Compromisso> TrazerTodos()
        {
            try
            {
               return _compromissoRepository.TrazerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Contato> TrazerTodosContatosCompromissos(Compromisso compromisso)
        {
            try
            {
                return _compromissoRepository.TrazerContatos(compromisso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
