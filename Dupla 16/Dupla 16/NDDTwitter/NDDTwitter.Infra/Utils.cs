using System;

namespace NDDTwitter.Infra
{
    public static class Utils
    {
        public static string DiferencaDeTempo(this DateTime tempo)
        {
            var diferençaTempo = DateTime.Now - tempo;
            
            if (diferençaTempo.Days >= 365)
                return DiferencaAnoAtuais(diferençaTempo);
            if (diferençaTempo.Days >= 30)
                return DiferencaMesAtuais(diferençaTempo);
            if (diferençaTempo.Days >= 7)
                return diferençaTempo.DiferencaSemanasAtuais();
            if (diferençaTempo.Days > 0)
                return diferençaTempo.DiferencaDiasAtuais();
            if (diferençaTempo.Hours > 0)
                return DiferencaHoraAtuais(diferençaTempo);
            if (diferençaTempo.Minutes > 0)
                return diferençaTempo.DiferencaMinutosAtuais();
           
            return diferençaTempo.DiferencaSegundosAtuais();
        }
        public static string DiferencaAnoAtuais(this TimeSpan diferença)
        {
            var anos = diferença.Days / 365;
            return conversorDeSingularEPlural(anos, "Ano");
        }
        public static string DiferencaMesAtuais(this TimeSpan diferença)
        {
            var meses = diferença.Days / 30;
            return meses == 1 ? string.Format("{0} Mês atrás", meses)
                                : string.Format("{0} Meses atrás", meses);
        }
        public static string DiferencaSegundosAtuais(this TimeSpan diferença)
        {
            return conversorDeSingularEPlural(diferença.Seconds, "Segundo");
        }


        public static string DiferencaMinutosAtuais(this TimeSpan diferença)
        {
            return conversorDeSingularEPlural(diferença.Minutes, "Minuto"); 
        }

        public static string DiferencaHoraAtuais(this TimeSpan diferença)
        {
            return conversorDeSingularEPlural(diferença.Hours, "Hora"); 
        }

        public static string DiferencaDiasAtuais(this TimeSpan diferença)
        {   
            return conversorDeSingularEPlural(diferença.Days, "Dia");
         
        }

        public static string DiferencaSemanasAtuais(this TimeSpan diferença)
        {
            return conversorDeSingularEPlural(diferença.Days / 7, "Semana");
        }

        private static string conversorDeSingularEPlural(int numero, string unidade)
        {
            return numero == 1 ? string.Format("{0} {1} atrás",numero,unidade)
                                : string.Format("{0} {1}s atrás", numero, unidade);
        }
    }
}

