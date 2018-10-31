using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.AccessKeys
{
    public class AccessKey
    {
        public string NumberAccessKey { get; set; }

        public virtual void Validate()
        {
            if(NumberAccessKey.Count() != 44)
                throw new AccessKeyNumberLessThanFortyFourCharactersException();
        }

        public void CreateNumberKey()
        {
            Random random = new Random();
            int aux;
            string _numbers = "";

            for(int i = 0;i < 44; i++)
            {
                aux = random.Next(0, 9);
                _numbers = string.Concat(_numbers, aux.ToString());
            }

            this.NumberAccessKey = _numbers;
        }

    }
}