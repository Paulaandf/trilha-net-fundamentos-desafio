using System.Text.RegularExpressions;

namespace Estacionamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            bool ok = false;
            do
            {
            Console.WriteLine("Modelo: LLL NL NN");
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            String Placa = Console.ReadLine();


            if (Regex.IsMatch(Placa.ToUpper(),"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}"))
            {
                veiculos.Add(Placa.ToUpper());
                ok = true;
            }
            else
            {
                Console.WriteLine("Placa com FOrmatação Invalida!");
            }

            } while (ok != true);
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            String placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0; 

                horas = int.Parse(Console.ReadLine());

                valorTotal = precoInicial+(precoPorHora*horas);

                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (String placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
