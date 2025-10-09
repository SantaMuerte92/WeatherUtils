using System;

namespace WeatherUtils
{
    public class WeatherUtils
    {
       
        private double temperatur;
        private double relativeFeuchte; 
        private double taupunkt;
        private double WindSpeed;

        private const double a = 17.62;
        private const double b = 243.12;

        /// <summary>
        /// Berechnet den Taupunkt in °C basierend auf Temperatur (°C) und relativer Luftfeuchte (%).
        /// </summary>
        public static double GetDewPoint(double temperatur, double relativeFeuchte)
        {
            if (relativeFeuchte <= 0 || relativeFeuchte > 100)
                throw new ArgumentOutOfRangeException(nameof(relativeFeuchte), "Relative Feuchte muss zwischen 0 und 100 liegen.");

            double alpha = ((a * temperatur) / (b + temperatur)) + Math.Log(relativeFeuchte / 100.0);
            double taupunkt = (b * alpha) / (a - alpha);
            return taupunkt;
        }






        public static double ErmittleWolkenhoehe(double temperatur, double relativeFeuchte)
        {
                double taupunkt = GetDewPoint(temperatur, relativeFeuchte);
            return (temperatur - taupunkt) * 125;
        }


        public static double GetWindchill(double temperatur, double WindSpeed)
        {
            if (temperatur > 10.0 & WindSpeed < 4.8);
                                     return temperatur;

                       double windfaktor = Math.Pow(WindSpeed, 0.16);
            double windchill = 13.12 + 0.6215 * temperatur - 11.37 * windfaktor + 0.3965 * temperatur * windfaktor;
            return windchill;
        }






        public static double GetHeatIndex(double temperatur, double relativeFeuchte)
       
        {   if (temperatur < 27.0 & relativeFeuchte < 40.0)
                            return temperatur;
            double Fahrenheit = (temperatur * 9.0 / 5.0) + 32.0;
          


            double heatIndex = -42.379 + 2.04901523 * temperatur + 10.14333127 * relativeFeuchte
                            - 0.22475541 * temperatur * relativeFeuchte - 6.83783e-03 * Math.Pow(temperatur, 2)
                            - 5.481717e-02 * Math.Pow(relativeFeuchte, 2) + 1.22874e-03 * Math.Pow(temperatur, 2) * relativeFeuchte
                            + 8.5282e-04 * temperatur * Math.Pow(relativeFeuchte, 2) - 1.99e-06 * Math.Pow(temperatur, 2) * Math.Pow(relativeFeuchte, 2);
            return (heatIndex - 32.0) * 5.0 / 9.0; // Umwandlung von Fahrenheit zurück nach Celsius
                

        }




}

}
