using CalculoSalarial.Entidades.Enums;
using System.Collections.Generic;

namespace CalculoSalarial.Entidades
{
    class Trabalhador
    {
        public string Nome { get; set; }
        public TrabalhadorNivel Level { get; set; }
        public double BaseSalario { get; set; }
        public Departamento Departamento { get; set; }
        public List<HorasContratatadas> Contratos { get; private set; } = new List<HorasContratatadas>();

        public Trabalhador()
        {
        }

        public Trabalhador(string nome, TrabalhadorNivel level, double baseSalario, Departamento departamento)
        {
            Nome = nome;
            Level = level;
            BaseSalario = baseSalario;
            Departamento = departamento;
        }

        public void AddContratos(HorasContratatadas contratos)
        {
            Contratos.Add(contratos);
        }

        public void RemoveContratos(HorasContratatadas contratos)
        {
            Contratos.Remove(contratos);
        }

        public double Rendimentos(int year, int month)
        {
            double soma = BaseSalario;
            foreach (HorasContratatadas contratos in Contratos)
            {
                if (contratos.Data.Year == year && contratos.Data.Month == month)
                {
                    soma += contratos.TotalValue();
                }
            }
            return soma;
        }
    }
}
