using System.Data;
using System.Collections.Generic;
namespace Task2
{
    public class InvalitOutFormat : Exception
    {
        public InvalitOutFormat(string message) : base(message) { }
    }
    class SortedArray
    {
        public event EventHandler<string[]> SortingEnd;
        
        public void Sort(string[] Names , int SortType)
        {
            if (SortType == 1)
            {
                Array.Sort(Names);
            }
            else
            if (SortType == 2)
            {
                Array.Sort(Names, (x, y) => string.Compare(y, x));
            }
            else
            {
              
                throw new InvalitOutFormat("Выбран некоректный вид сортировки");
            }
            OnSortingEnd(Names);

        }
        protected virtual void OnSortingEnd(String[] Names)
        {
            SortingEnd.Invoke(this, Names);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           SortedArray sortArray    = new SortedArray();
            sortArray.SortingEnd += OnSortingEnd ;

            string[] names = new string[5];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Введите фамилию {0} -", i+1);
                names[i] = Console.ReadLine();
            }

            Console.WriteLine("Выбираем вид сортировки: \n1 - <A - Я>  2 - <Я - А>");
            try
            {
                int SortType = Convert.ToInt32(Console.ReadLine());
                
                sortArray.Sort(names, SortType);
            }
            catch (InvalitOutFormat ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { }
        }

     

        static void OnSortingEnd(object j ,string[] Names)
        {
            Console.WriteLine("Sort END");
            foreach (var name in Names)
            {
                Console.WriteLine(name);
            }
        }

      
    }
}