using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchMarkDemo
{
    class Program {

        static void Main(string[] args) {
            var summary = BenchmarkRunner.Run<RandomService>();

            var secondSummary = BenchmarkRunner.Run<CaculateNumberBenchMark>();

            Console.Write(secondSummary);
            Console.ReadKey();
        }
    }




    public interface IRandomService {
        int GetRandomNum();
    }

    public class RandomService //: IRandomService
    {
        public Random ran = new Random();

        [Benchmark]
        public int GetRandomNum() {
            return ran.Next();
        }
    }

    
    public class ComplexNumber
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }

    public class CaculateNumber
    {
        public static int Caculate(ComplexNumber complexNumber) {
            return complexNumber.FirstNumber * complexNumber.SecondNumber;
        }
    }

    public class CaculateNumberBenchMark
    {
        private ComplexNumber complexNumber;

        [GlobalSetup]
        public void GlobalSetup() {
            this.complexNumber = new ComplexNumber() { FirstNumber = 2, SecondNumber = 6 };
        }

        [Benchmark]
        public int GetCaculateNumber() {
            return CaculateNumber.Caculate(complexNumber);
        }
    }


}