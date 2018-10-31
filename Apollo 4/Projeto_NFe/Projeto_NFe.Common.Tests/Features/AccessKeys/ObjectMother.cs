using Projeto_NFe.Infra.AccessKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static AccessKey GetAccessKey()
        {
            return new AccessKey()
            {
                NumberAccessKey = "12344567891010987654321054128976126798341634"
            };
        }

        public static AccessKey GetAccessKeyNumberLessThanFortyFourCharacters()
        {
            return new AccessKey()
            {
                NumberAccessKey = ""
            };
        }
    }
}
