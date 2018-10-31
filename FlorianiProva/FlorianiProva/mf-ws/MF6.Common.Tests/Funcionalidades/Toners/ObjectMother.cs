using MF6.Domain.Funcionalidades.Toners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Toner TonerColoridoValido() { return new Toner(TipoTonerEnum.Colorido, 100) { Id = 1 }; }
        public static Toner TonerPretoBrancoValido() { return new Toner(TipoTonerEnum.PretoBranco, 100) { Id = 2 }; }

        public static Toner TonerColoridoValidoSemId() => new Toner(TipoTonerEnum.Colorido, 100);
        public static Toner TonerPretoBrancoValidoSemId() => new Toner(TipoTonerEnum.PretoBranco, 100);
    }
}
