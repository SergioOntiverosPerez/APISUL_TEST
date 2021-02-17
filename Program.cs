using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Apisul
{


    class Program
    {
        public static List<Elevadores> elevadores = new List<Elevadores>();
        static void Main(string[] args)
        {


            var myJsonFile = File.ReadAllText(@"D:\Usuario\Documents\ApiSul Test\Apisul\Apisul\input.json");
            var elevadores = JsonConvert.DeserializeObject<List<Elevadores>>(myJsonFile);

            var elevadorService = new ElevadorService(elevadores);
            var menosUtilizados = elevadorService.andarMenosUtilizado();

            Console.WriteLine("Os Andares menos utilizados são: ");
            foreach (var item in menosUtilizados)
            {
                Console.WriteLine("Andar: " + item.ToString());
            }
            var elevadorMiasSolicitado = elevadorService.elevadorMaisFrequentado();
            var periodoMaisSolicitado = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

            Console.WriteLine("O elevador mais frequentado é: " + elevadorMiasSolicitado[0].ToString() + " e o período que se encontra em maior fluxo: " + periodoMaisSolicitado[0].ToString());

            var elevadorMenossolicitado = elevadorService.elevadorMenosFrequentado();
            var periodoMenosSolicitado = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

            Console.WriteLine("O elevador menos frequentado é: " + elevadorMenossolicitado[0].ToString() + " e o período que se encontra menor fluxo: " + periodoMenosSolicitado[0].ToString());

            var periodoMaiorOcorrenciaDeTodosOsElevadores = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();

            Console.WriteLine("O período de maior utilização do conjunto de elevadores é: " + periodoMaiorOcorrenciaDeTodosOsElevadores[0].ToString());

            var percentuais = elevadorService.percentualDeUso();
            foreach (var item in percentuais)
            {
                Console.WriteLine("O percetual de uso do elevador " + item.Key.ToString() + " = " + item.Value.ToString() );
            }



        }
    }
}
