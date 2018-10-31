using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra
{
    public static class DateTimeExtension
    {
        public static string DateTimeToString(this DateTime dateTime)
        {
            TimeSpan diferenca = DateTime.Now - dateTime;

            if ((int)diferenca.TotalSeconds < 60)
                return SecondsAgo(diferenca);
            else if ((int)diferenca.TotalMinutes < 60)
                return MinutesAgo(diferenca);
            else if ((int)diferenca.TotalHours < 24)
                return HoursAgo(diferenca);
            else if ((int)diferenca.TotalDays < 7)
                return DaysAgo(diferenca);
            else if ((int)diferenca.TotalDays < 30)
                return WeeksAgo(diferenca);
            else if ((int)diferenca.TotalDays < 365)
                return MonthsAgo(diferenca);
            else
                return YearsAgo(diferenca);
        }
        #region private methods
        private static string SecondsAgo(TimeSpan diferenca)
        {
            if ((int)diferenca.TotalSeconds < 2)
                return "1 segundo atrás";
            return string.Format("{0} segundos atrás", (int)diferenca.TotalSeconds);
        }
        private static string MinutesAgo(TimeSpan diferenca)
        {
            if ((int)diferenca.TotalMinutes < 2)
                return "1 minuto atrás";
            return string.Format("{0} minutos atrás", (int)diferenca.TotalMinutes);
        }
        private static string HoursAgo(TimeSpan diferenca)
        {
            if ((int)diferenca.TotalHours < 2)
                return "1 hora atrás";
            return string.Format("{0} horas atrás", (int)diferenca.TotalHours);
        }
        private static string DaysAgo(TimeSpan diferenca)
        {
            if ((int)diferenca.TotalDays < 2)
                return "1 dia atrás";
            return string.Format("{0} dias atrás", (int)diferenca.TotalDays);
        }
        private static string WeeksAgo(TimeSpan diferenca)
        {
            if (((int)diferenca.TotalDays / 7) < 2)
                return "1 semana atrás";
            return string.Format("{0} semanas atrás", (int)diferenca.TotalDays / 7);
        }
        private static string MonthsAgo(TimeSpan diferenca)
        {
            if (((int) diferenca.TotalDays / 30.0) < 2)
                return "1 mes atrás";
            return string.Format("{0} meses atrás", (int) diferenca.TotalDays / 29);
        }      
        private static string YearsAgo(TimeSpan diferenca)
        {
            if (((int)diferenca.TotalDays / 365) < 2)
                return "1 ano atrás";
            return string.Format("{0} anos atrás", (int)diferenca.TotalDays / 365);
        }
        #endregion
    }
}
