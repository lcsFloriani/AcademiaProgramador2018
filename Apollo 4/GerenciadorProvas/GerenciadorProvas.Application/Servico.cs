using System;
using System.Collections.Generic;
using GerenciadorProvas.Dominio.Interfaces;
using GerenciadorProvas.Dominio.Modal;



namespace GerenciadorProvas.Aplicacao
{
    public abstract class Servico<T> : IRepository<T> where T : Entidade
    {
        protected IRepository<T> _repositorio { get; set; }

        public Servico(IRepository<T> repositorio)
        {
            this._repositorio = repositorio;
        }

        public T Adicionar(T entidade)
        {
            try
            {
                entidade.Validacoes();

                entidade = _repositorio.Adicionar(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }



        public T Atualizar(T entidade)
        {
            try
            {
                entidade.Validacoes();

                entidade = _repositorio.Atualizar(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }


        public T ProcuraPorId(int id)
        {
            try
            {
                return _repositorio.ProcuraPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<T> Listagem()
        {
            try
            {
                return _repositorio.Listagem();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Excluir(T entidade)
        {
            try
            {
                 _repositorio.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
