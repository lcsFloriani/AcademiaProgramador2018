using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Enums
{
    public enum StatusPedidoEnum
    {
        AguardandoMontagem,
        EmMontagem,
        AguardandoEntrega,
        EmEntrega,
        Entregue
    }
}