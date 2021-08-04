using System;
using System.Collections.Generic;

/*Stwórz aplikację identyczną jak w zadaniu jak poprzednio, ale wykorzystując Dapper. 
Podłącz do niej dowolną bazę danych, (np.Northwind) i dodaj funkcjonalność 
CRUD na tej samej tabeli co poprzednio.
Najpierw wyświetl listę danych z tej tabeli, następnie pozwól dodać nowy wpis,
pozwól go edytować a na koniec usuń go. Wykorzystaj mapowanie i parametry.*/

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            var DB = new DBCrudDapper(@"Data Source=DESKTOP-9SL4PUT;Initial Catalog=ZNorthwind;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");

            foreach (var spedytorzy in DB.GetSpedytors())
            {
                Console.WriteLine($"{spedytorzy.IDspedytora} {spedytorzy.NazwaFirmy}");
            }
            Console.WriteLine();

            DB.AddSpedytor();
            DB.UpdateSpedytor();
            DB.DeleteSpedytor();

            foreach (var spedytorzy in DB.GetSpedytors())
            {
                Console.WriteLine($"{spedytorzy.IDspedytora} {spedytorzy.NazwaFirmy}");
            }
            Console.WriteLine();


        }
    }
}
