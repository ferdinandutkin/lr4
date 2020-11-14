using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 
namespace LR4
{
    public static class StatisticalOperations
    {
        public static Set<T> NormalizedButExtension<T>(this Set<T> s)
        {
            s.Normalize();
            return s;
        }
        public static string CommaAfterEachWord(this string s) => string.Join(", ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries)) + ", ";

        public static int SumButExtension(this Set<int> s) => s.Sum();

        public static int MinMaxDifference(this Set<int> s) => s.Min() - s.Max();

        public static int Count(this Set<int> s) => (int)s;


        public static bool IsWithinRange(this Set<int> s, int[] arr, int top, int bottom) => bottom <= arr.Length && arr.Length <= top;




    }



    public partial class Set<T> : IEnumerable<T>
    {
     

    List<T> container;

        public Set(params T[] values)
        {
            container = values.ToList();
            Normalize();
        }


        public Set(IEnumerable<T> values)
        {
            container = values.ToList();
            Normalize();
        }



        // public static bool operator >=(Set<T> l, Set<T> r) => true;
        // public static bool operator <=(Set<T> l, Set<T> r) => true; 
 
        public T this[int index]
        {
            get => container[index];
            set => container[index] = value;              
        }

        public void Add(T el) => container.Add(el);
      
        public void Normalize() => container = this.Distinct().ToList(); 
        public static Set<T> operator +(Set<T> l, Set<T> r) => new Set<T>(l.Concat(r));
        public static Set<T> operator +(Set<T> s, T el) => new Set<T>(s.Append(el));
        public static Set<T> operator +(T el, Set<T> s) => new Set<T>(s.Prepend(el));

        public static Set<T> operator *(Set<T> l, Set<T> r) => new Set<T>(l.Intersect(r));

        public static explicit operator int(Set<T> s) => s.container.Count;

      
       
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)container).GetEnumerator();
       
        IEnumerator IEnumerable.GetEnumerator() => container.GetEnumerator();

        public override string ToString() => '{' + string.Join(", ", this) + '}';
         


    }

    
    class Program
    {

        static void Main()
        {
            var set1 = new Set<int> { 1, 2, 5, 2, 13, 2, 4 };
            var set2 = new Set<int> { 7, 6, 5, 2, 4, 1 };

          

            Console.WriteLine($"{set1} + {set2} = {set1 + set2}");

            Console.WriteLine($"{set1} * {set2} = {set1 * set2}");
            
            Console.WriteLine($"{set1} + 12 = {set1 + 12}");

            Console.WriteLine($"12 + {set1} = {12 + set1}"); 

            Console.WriteLine($"(int){set1} = {(int)set1}");


            Console.WriteLine(Set<int>.OwnerInfo);

            Console.WriteLine("тестовая строка".CommaAfterEachWord());

            Console.WriteLine(new Set<int>(1, 3, 4, 3, 3, 1).NormalizedButExtension());



        }
    }
}
