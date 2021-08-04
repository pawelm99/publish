using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    public class DBCrud
    {
        private SqlConnection SqlConnection;

        public void Read()
        {

            var zapytanie = "Select * FROM dbo.Spedytorzy ";

            var command = new SqlCommand(zapytanie, SqlConnection);

            using var reader = command.ExecuteReader();
            Console.WriteLine("--------Nazwa Firm--------");
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
            }
            reader.Close();
            Console.WriteLine();
        }

        public void Insert()
        {
            Console.Write("Wpisz nazwe Firmy: ");
            var NazwaFirmy = Console.ReadLine();
            var insertSQL = $"INSERT INTO dbo.Spedytorzy (IDspedytora, NazwaFirmy) VALUES (@IDspe, @NazwFir)";

            var insertCommand = new SqlCommand(insertSQL, SqlConnection);
            Console.Write("Wpisz IDspedytora: ");

            var IdSpedytorRead = Console.ReadLine();
            bool resulat = int.TryParse(IdSpedytorRead, out int IdSpedytor);
            if (resulat)
            {
                insertCommand.Parameters.AddWithValue("@NazwFir", NazwaFirmy);
                insertCommand.Parameters.AddWithValue("@IDspe", IdSpedytor);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Insert Succes");
            }
            else
                Console.WriteLine("Zla podana liczba IDSpedytora!");



        }
        public void Update()
        {
            Console.Write("Wpisz nazwe Fimry którą chcesz edytowac: ");
            var NazwaFirmy = Console.ReadLine();

            var updateSQL = $"UPDATE dbo.Spedytorzy SET IDspedytora=@IDspe,NazwaFirmy=@NazwFir WHERE NazwaFirmy=@nazwa_firmy";
            var updateComannd = new SqlCommand(updateSQL, SqlConnection);
            updateComannd.Parameters.AddWithValue("@nazwa_firmy", NazwaFirmy);
            Console.Write("Wpisz Nową Nazwe Frimy: ");
            var NazwaFirmyRead = Console.ReadLine();
            updateComannd.Parameters.AddWithValue("@NazwFir", NazwaFirmyRead);
            Console.Write("Wpisz Nową Liczbe IDSpedytora: ");
            var liczba = Console.ReadLine();
            bool result2 = int.TryParse(liczba, out int nowa_IDSpedytora);
            if (result2)
            {
                updateComannd.Parameters.AddWithValue("@IDspe", nowa_IDSpedytora);


                Console.WriteLine("Update Succes");
            }
            else
                Console.WriteLine("Bledna nowa liczba idSpedytora!");

            updateComannd.ExecuteNonQuery();
        }


        public void Delete()
        {

            Console.Write("Wpisz nazwe Fimry którą chcesz usunąć: ");
            var NazwaFirmy = Console.ReadLine();

            var deleteSQL = $"DELETE dbo.Spedytorzy WHERE NazwaFirmy=@nazwa_firmy";
            var deleteCommand = new SqlCommand(deleteSQL, SqlConnection);
            deleteCommand.Parameters.AddWithValue("@nazwa_firmy", NazwaFirmy);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Delete Succes");

        }
        public void SQLConnectOpen()
        {
            SqlConnection.Open();
        }
        public void SQLConnectClose()
        {
            SqlConnection.Close();
        }
        public void SQLConnection()
        {
            string connectionSTring = @"Data Source=DESKTOP-9SL4PUT;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=True";
            SqlConnection = new SqlConnection(connectionSTring);

        }
    }
}
