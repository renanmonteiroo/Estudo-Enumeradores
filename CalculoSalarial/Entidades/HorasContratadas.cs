using System;

namespace CalculoSalarial.Entidades
{
    class HorasContratatadas
    {

        public DateTime Data { get; set; }
        public double ValorPorHora { get; set; }
        public int Horas { get; set; }

        public HorasContratatadas()
        {
        }

        public HorasContratatadas(DateTime data, double valorPorHora, int horas)
        {
            Data = data;
            ValorPorHora = valorPorHora;
            Horas = horas;
        }

        public double TotalValue()
        {
            return Horas * ValorPorHora;
        }
    }
}


