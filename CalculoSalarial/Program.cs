using System;
using System.Globalization;
using CalculoSalarial.Entidades;
using CalculoSalarial.Entidades.Enums;

namespace CalculoSalarial
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Entre com o nome do Departamneto:");
            string departamentoNome = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Cargo: (Junior/MidLevel/Senior) : ");
            TrabalhadorNivel level = Enum.Parse<TrabalhadorNivel>(Console.ReadLine());
            Console.Write("Base salarial: ");
            double baseSalario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departamento dept = new Departamento(departamentoNome);
            Trabalhador trabalhador = new Trabalhador(name, level, baseSalario, dept);

            Console.Write("Quantos contratos existem para este trabalhador ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados  #{i}  contrato:");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora :");
                double valuePorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração em (horas) : ");
                int hours = int.Parse(Console.ReadLine());
                HorasContratatadas contract = new HorasContratatadas(date, valuePorHora, hours);
                trabalhador.AddContratos(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com o Mes e o ano para calcular o ganho do trabalhador (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Nome : " + trabalhador.Nome);
            Console.WriteLine("Departamento: " + trabalhador.Departamento.Nome);
            Console.WriteLine("Trabalhando desde : " + monthAndYear + ": " + trabalhador.Rendimentos(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }

}