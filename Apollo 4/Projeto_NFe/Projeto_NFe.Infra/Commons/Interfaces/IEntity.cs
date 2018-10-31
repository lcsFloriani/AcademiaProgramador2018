using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Commons.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }

        void Validate();

    }
}
