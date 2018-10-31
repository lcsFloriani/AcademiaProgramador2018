using Pizzaria.Application;
using Pizzaria.WinApp.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features
{
    public abstract class GerenciadorFormulario<T, E> : IGerenciadorFormulario where E : IServico<T>
    {
        protected ControleFormulario<T> controle;
        protected T entidade;
        protected E _servico;

        public GerenciadorFormulario(E servico)
        {
            controle = new ControleFormulario<T>();
            _servico = servico;
        }
       
        public virtual UserControl PegarControle()
        {
            return controle;
        }

        public virtual void ItemSelecionado()
        {
            controle.ItemSelecionado();
        }

        public virtual void LimparItemSelecionado()
        {
            controle.LimparItemSelecionado();
        }

        public virtual void CarregarListagem()
        {
            controle.LimparLista();
            controle.PopularListagem(_servico.Listagem());
        }

        public virtual void CarregarListagem(List<T> lista)
        {
            controle.LimparLista();
            controle.PopularListagem(lista);
        }
        
        public virtual void Excluir()
        {
            try
            {
                T entidade = (T)controle.Valor;
                _servico.Excluir(entidade);
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
                Filtrar = true
            };
        }

        public virtual TituloBotoes ObtemTituloBotoes(string selecionado)
        {
            return new TituloBotoes
            {
                Gravar = "Adicionar " + selecionado,
                Editar = "Editar " + selecionado,
                Excluir = "Excluir " + selecionado,
                Filtrar = "Flitrar" + selecionado
            };
        }

        public abstract void Editar();

        public abstract void Gravar();

        public abstract void Filtrar();
    }
}
