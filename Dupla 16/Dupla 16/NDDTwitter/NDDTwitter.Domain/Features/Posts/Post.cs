using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Features
{
    public class Post
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public DateTime PostDate { get; set; }

        public string DisplayPostDate
        {
            get
            {
                return PostDate.DiferencaDeTempo();
            }
        }


        public void Validate()
        {
            if (String.IsNullOrEmpty(Message))
                throw new MessageNulaOuVaziaException();
            if (Message.Length > 140)
                throw new MessageMoreThan140CharacterException();
            if (PostDate > DateTime.Now)
                throw new DateTimeException();
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
