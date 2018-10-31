using GerenciadorProvas.Dominio.Enums;


namespace GerenciadorProvas.Infra.SQL
{

    static class SQLUtil
    {
        public static string PegarNomeDoBanco(TipoBancoDados tipo)
        {
            switch (tipo)
            {
                case TipoBancoDados.SQL_SERVER:
                    return "DBGerenciadorProvas.db.SQLServer";
                case TipoBancoDados.MY_SQL:
                    return "DBGerenciadorProvas.db.MySQL";
            }

            return null;
        }

        public static string PegarAlias(TipoBancoDados tipo)
        {
            switch (tipo)
            {
                case TipoBancoDados.SQL_SERVER:
                    return "@";
                case TipoBancoDados.MY_SQL:
                    return "?";
            }

            return null;
        }
    }
    }
