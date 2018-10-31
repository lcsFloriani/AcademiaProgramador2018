using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.WinApp.Features.Core.Common
{
   public interface ICadastroDialog<T> where T : Entidade
    {
        T Valor { set; get; }

        void Limpar();

        void Validacoes();

        void SalvarOuAtualizar();

    }
}
