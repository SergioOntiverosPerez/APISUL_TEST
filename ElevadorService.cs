using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apisul
{
    public class ElevadorService : IElevadorService
    {
        public List<Elevadores> Elevadores { get; set; }
        public ElevadorService(List<Elevadores> elevadores)
        {
            Elevadores = elevadores;
        }

        public Dictionary<char, float> percentualDeUso()
        {
            Dictionary<char, float> dicPercentual = new Dictionary<char, float>();
            try
            {
                dicPercentual.Add('A', percentualDeUsoElevadorA());
                dicPercentual.Add('B', percentualDeUsoElevadorB());
                dicPercentual.Add('C', percentualDeUsoElevadorC());
                dicPercentual.Add('D', percentualDeUsoElevadorD());
                dicPercentual.Add('E', percentualDeUsoElevadorE());

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return dicPercentual;
        }

        public List<int> andarMenosUtilizado()
        {
            List<int> andaresMenosUtilizados = new List<int>();
            try
            {
                var andares = Elevadores.GroupBy(e => e.Andar).Select(group => new { group.Key, Count = group.Count() }).OrderBy(x => x.Count);
                var menosOcorrencia = andares.First().Count;
                andaresMenosUtilizados = andares.TakeWhile(x => x.Count == menosOcorrencia).OrderBy(x => x.Key).Select(x => x.Key).ToList();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return andaresMenosUtilizados;
        }

        public List<char> elevadorMaisFrequentado()
        {
            List<char> elevadorMaisSolicitado = new List<char>();
            try
            {
                var elevadores = Elevadores.GroupBy(e => e.Elevador).Select(group => new { group.Key, Count = group.Count() }).OrderByDescending(x => x.Count);
                var maiorOcorrencia = elevadores.First();
                elevadorMaisSolicitado = elevadores.TakeWhile(x => x.Key == maiorOcorrencia.Key).OrderBy(x => x.Key).Select(x => x.Key).ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return elevadorMaisSolicitado;
        }

        public List<char> elevadorMenosFrequentado()
        {
            List<char> elevadorMenosSolicitado = new List<char>();
            try
            {
                var elevadores = Elevadores.GroupBy(e => e.Elevador).Select(group => new { group.Key, Count = group.Count() }).OrderBy(x => x.Count);
                var maiorOcorrencia = elevadores.First();
                elevadorMenosSolicitado = elevadores.TakeWhile(x => x.Key == maiorOcorrencia.Key).OrderBy(x => x.Key).Select(x => x.Key).ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return elevadorMenosSolicitado;
        }

        public float percentualDeUsoElevadorA()
        {
            float elevadorA = 0;
            try
            {
                elevadorA = (float)Math.Round(((float)Elevadores.Where(e => e.Elevador == 'A').Count() / (float)Elevadores.Count()) * 100, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return elevadorA;
        }

        public float percentualDeUsoElevadorB()
        {
            float elevadorB = 0;
            try
            {
                elevadorB = (float)Math.Round(((float)Elevadores.Where(e => e.Elevador == 'B').Count() / (float)Elevadores.Count()) * 100, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return elevadorB;
        }

        public float percentualDeUsoElevadorC()
        {
            float elevadorC = 0;
            try
            {
                elevadorC = (float)Math.Round(((float)Elevadores.Where(e => e.Elevador == 'C').Count() / (float)Elevadores.Count()) * 100, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return elevadorC;
        }

        public float percentualDeUsoElevadorD()
        {
            float elevadorD = 0;
            try
            {
                elevadorD = (float)Math.Round(((float)Elevadores.Where(e => e.Elevador == 'D').Count() / (float)Elevadores.Count()) * 100, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            } 
            return elevadorD;
        }

        public float percentualDeUsoElevadorE()
        {
            float elevadorE = 0;
            try
            {
                elevadorE = (float)Math.Round(((float)Elevadores.Where(e => e.Elevador == 'E').Count() / (float)Elevadores.Count()) * 100, 2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return elevadorE;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> result = new List<char>();
            try
            {
                var elevador = elevadorMaisFrequentado();
                var periodo = Elevadores.Where(x => x.Elevador == elevador[0]).GroupBy(e => e.Turno).Select(group => new { group.Key, Count = group.Count() }).OrderByDescending(x => x.Count);
                result.Add(periodo.First().Key);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return result;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<char> result = new List<char>();
            try
            {
                var periodo = Elevadores.GroupBy(ele => ele.Turno).Select(group => new { group.Key, Count = group.Count() }).OrderByDescending(x => x.Count);
                var maiorOcorencia = periodo.First().Count;
                result = periodo.TakeWhile(x => x.Count == maiorOcorencia).OrderBy(x => x.Key).Select(x => x.Key).ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
            return result;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> result = new List<char>();
            try
            {
                var elevador = elevadorMenosFrequentado();
                var periodo = Elevadores.Where(x => x.Elevador == elevador[0]).GroupBy(e => e.Turno).Select(group => new { group.Key, Count = group.Count() }).OrderBy(x => x.Count);
                result.Add(periodo.First().Key);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return result;
        }
    }
}
