using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Testes;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            //aplicação de classe de condição para metodo generico
            string s = "";
            Condicao teste = new Condicao();

            string result = teste.f<string>(() => {
                return s == "e";
            }, "Verdadeiro", "Falso");

            Console.Write("Resultado: {0}", result);
            Console.Read();

            //áplicação para a lista generica
            var g = new Generico<int>();
            g.Add(1);
            g.Add(2);

            foreach (var item in g.listaGenerico)
            {
                Console.WriteLine(item);
            }

            //aplicação do indice da sequencia de fibonacci
            Console.WriteLine("Insira um numero");
            Console.ReadLine();
            string num = Console.ReadLine();
            int number;
            Int32.TryParse(num, out number);
            int fibonacci = calcularFibonacci(number);

            Console.WriteLine("Fibonacci {0}", fibonacci);
            Console.Read();
        }

        public static int calcularFibonacci(int num)
        {
            if (num == 0)
            {
                return num;
            }
            else if (num == 1)
            {
                return num;
            }
            else
            {
                return calcularFibonacci(num - 1) + calcularFibonacci(num - 2);
            }
        }


    }

    public class Generico<T>
    {
        public List<T> listaGenerico { get; set; } = new List<T>();

        public void Add(T item)
        {
            listaGenerico.Add(item);
        }

        public List<T> GetList()
        {
            return listaGenerico;
        }

        public T Get(Func<T, bool> expression)
        {
            return listaGenerico.FirstOrDefault(expression);
        }


    }

    public class Condicao
    {
        public T f<T>(Func<bool> p, T v, T f)
        {

            if (p())
                return v;
            else
                return f;

        }
    }
}
