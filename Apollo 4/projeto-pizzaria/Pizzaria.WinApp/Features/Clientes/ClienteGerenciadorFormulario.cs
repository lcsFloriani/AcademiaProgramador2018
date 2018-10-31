using GerenciadorProvas.WinApp.Features;
using Pizzaria.Application.Features.CEPs;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.WinApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Clientes
{
    public class ClienteGerenciadorFormulario : GerenciadorFormulario<Cliente, ClienteServico>
    {
        private CepServico _cepServico;

        public ClienteGerenciadorFormulario(ClienteServico servico, CepServico cepServico) : base(servico)
        {
            _cepServico = cepServico;
        }

        public override void Gravar()
        {
            ClienteDialog dialog = new ClienteDialog(_servico, _cepServico);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Cliente salvo com sucesso no sistema!");
            }
        }

        public override void Editar()
        {
            ClienteDialog dialog = new ClienteDialog(_servico, _cepServico);
            dialog.Valor = controle.Valor;
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Atualizar(dialog.Valor);
                controle.LimparItemSelecionado();
                CarregarListagem();

                MessageBox.Show("Cliente alterado com sucesso!");
            }
        }

        public override void Filtrar()
        {
            throw new NotImplementedException();
        }

        public override EstadoBotoes ObtemEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Gravar = true,
                Editar = true,
                Excluir = false,
                Filtrar = false
            };
        }
    }
}
