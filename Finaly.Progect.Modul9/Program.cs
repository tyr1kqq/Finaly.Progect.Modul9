using System.Data;

namespace Finaly.Progect.Modul9
{
    class MyException: Exception
    {
        public MyException(string Mesage) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Exception[] expencion =
            {
            new DivideByZeroException(),
            new FormatException(),
            new FieldAccessException(),
            new FileLoadException(),
            new ArgumentException(),
            new MyException("Warning")
            };
             
            foreach (var ex in expencion)
            {
                try
                {
                    throw ex;
                }
                catch( DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch ( FormatException e )
                {
                    Console.WriteLine(e.Message);
                }
                catch (FieldAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FileLoadException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (MyException e)
                {
                    Console.WriteLine( "А это мое исключение  " + e.Message);
                }
                finally { Console.WriteLine(); }
            }
           
            
            

            
        }
    }
}