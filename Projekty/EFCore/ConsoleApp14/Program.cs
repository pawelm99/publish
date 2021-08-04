using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

/*Stwórz nową aplikację i dodaj do niej EF Core. Użyj Code First from Database i wygeneruj klasę
DBContext z bazy Northwind (zalecam w jakimś podfolderze). Następnie dodaj do kontekstu nową 
tabelę, np. MyUsers z kolumnami int Id, string Name, DateTime RegistrationDate i przygotuj migrację.*/

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {

            var kontekst = new DBKontekst();
            kontekst.Database.EnsureCreated();

            kontekst.Users.Add(new MyUsers { Name = "Tomek2", RegistrationDate = DateTime.Today, Telefon = "513763123"});

            kontekst.SaveChanges();

            
        }
    }
}
