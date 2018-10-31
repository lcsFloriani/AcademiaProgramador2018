using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.Core.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features
{
    public abstract class GerenciadorFormulario<T, E> : IGerenciadorFormulario
        where E : Servico<T>
        where T : Entidade
       
    {

        protected ControleGenerico<T> controle;
        protected T entidade;
        private E _servico;

        public GerenciadorFormulario() {
            controle = new ControleGenerico<T>();
           
        }

        public E ObterServico()
        {
            if (_servico == null)
                _servico = Activator.CreateInstance<E>();

            return _servico;
        }

        public T ObterValor() {
            
            return controle.Valor;
        }

        public UserControl PegarControle()
        {
            return controle;
        }

        public void ItemSelecionado()
        {
            controle.ItemSelecionado();
        }

        public void LimparItemSelecionado()
        {
            controle.LimparItemSelecionado();
        }

        public void CarregarListagem()
        {
            controle.LimparLista();
            controle.PopularListagem((List<T>)ObterServico().Listagem());
        }


        public virtual void Excluir()
        {
            try
            {
                T entidade = (T)controle.Valor;
                ObterServico().Excluir(entidade);
                controle.LimparItemSelecionado();
                CarregarListagem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual EstadoBotoes ObtemEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Gravar = true,
                Editar = true,
                Excluir = true,
                PDF = false,
                CSV = false,
                XML = false
            };
        }

        public virtual TituloBotoes ObtemTituloBotoes(string selecionado)
        {
            return new TituloBotoes
            {
                Gravar = "Adicionar " + selecionado,
                Editar = "Editar " + selecionado,
                Excluir = "Excluir " + selecionado,
                PDF = "PDF " + selecionado,
                CSV = "CSV " + selecionado,
                XML = "XML " + selecionado,
            };
        }

        public abstract void Editar();

        public abstract void Gravar();

        public abstract void Filtrar();

       

    }
}
