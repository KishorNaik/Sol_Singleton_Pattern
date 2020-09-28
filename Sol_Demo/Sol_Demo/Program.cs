using System;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Singleton singletonDemo1 = Singleton.Insatnce;
            singletonDemo1.Access();

            Singleton singletonDemo2 = Singleton.Insatnce;
            singletonDemo2.Access();

            //Using Parallel
            Parallel.Invoke(
                () =>
                {
                    Singleton singletonDemo3 = Singleton.Insatnce;
                    singletonDemo3.Access();
                }, // Thread 1
                () =>
                {
                    Singleton singletonDemo4 = Singleton.Insatnce;
                    singletonDemo4.Access();
                } // Thread 2
                );
        }
    }

    public class Singleton
    {
        private static readonly Lazy<Singleton> singleton = new Lazy<Singleton>(() => new Singleton()); // Thread Safe.

        //// for demo purpose, How many instance will create.
        //private static int counter;

        private Singleton()
        {
            //counter++;
            //Console.WriteLine($"Counter Instance : {counter}");
        }

        public static Singleton Insatnce => singleton.Value;

        public void Access()
        {
            Console.WriteLine("Singleton demo");
        }
    }
}