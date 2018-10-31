using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.AccessKeys
{
    public class AccessKeyNumberLessThanFortyFourCharactersException : AccessKeyException
    {
        public AccessKeyNumberLessThanFortyFourCharactersException() : base("O numero da chave de acesso é invalido!")
        {

        }
    }
}
