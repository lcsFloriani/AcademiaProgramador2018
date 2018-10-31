using GerenciadorProvas.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.infra
{
    public sealed class SingletonTipoBanco
    {

        private static TipoBancoDados instancia = TipoBancoDados.SQL_SERVER;


        private SingletonTipoBanco() { }

        public static TipoBancoDados Instancia
        {
            get
            {
                return instancia;
            }
        }


        public static void MudarTipoBanco(TipoBancoDados tipo)
        {
            instancia = tipo;
        }
    }
}
