using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Linq_performance
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Tamanho { get; set; }

        private IEnumerable<int> _itens;

        [GlobalSetup]
        public void Setup()
        {
            _itens = Enumerable.Range(1, Tamanho).ToArray();
        }

        [Benchmark]
        public int Max() => _itens.Max();

        [Benchmark]
        public int Min() => _itens.Min();

        [Benchmark]
        public double Media() => _itens.Average();

        [Benchmark]
        public int Soma() => _itens.Sum();

        [Benchmark]
        public int PegarONumeroMaior()
        {
            var maior = int.MinValue;
            foreach (var item in _itens)
            {
                if (item > maior)
                {
                    maior = item;
                }
            }
            return maior;
        }
    }
}
