using System;
using System.Data.SqlClient;


//Stwórz prostą aplikację konsolową. Podłącz do niej dowolną bazę danych,
//(np.Northwind) przy pomocy ADO.NET i dodaj funkcjonalność CRUD na dowolnej tabeli.
//Najpierw wyświetl listę danych z tej tabeli, następnie pozwól dodać nowy wpis, pozwól go edytować a na koniec usuń go.

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            DBCrud dBCrud = new DBCrud();
            dBCrud.SQLConnection();
            dBCrud.SQLConnectOpen();
            dBCrud.Read();
            dBCrud.Insert();
            dBCrud.Update();
            dBCrud.Delete();
            dBCrud.SQLConnectClose();




        }
    }
}
