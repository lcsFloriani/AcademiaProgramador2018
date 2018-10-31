using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Receivers
{
    public interface IReceiverService
    {
        Receiver Add(Receiver receiver);
        Receiver Update(Receiver receiver);
        Receiver Get(long id);
        IEnumerable<Receiver> GetAll();
        void Delete(Receiver receiver);
    }
}
