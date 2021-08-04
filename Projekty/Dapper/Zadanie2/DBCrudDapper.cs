using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Zadanie2
{
    class DBCrudDapper
    {
        private IDbConnection _connection;
        public DBCrudDapper(string ConnectionString)
        {
            _connection = new SqlConnection(ConnectionString);

        }
        public IEnumerable<Spedytorzy> GetSpedytors()
        {
            return _connection.Query<Spedytorzy>("SELECT * FROM Spedytorzy");
        }
        public bool AddSpedytor()
        {
            Console.Write("Podaj nazwe firmy: ");
            var ReadNFirmy = Console.ReadLine();
            Console.Write("Podaj id firmy: ");
            var ReadID = Console.ReadLine();
            var ResultParsID = int.TryParse(ReadID, out var ID);
            if (ResultParsID)
            {
                var result = _connection.Execute("INSERT INTO Spedytorzy(IDSpedytora,NazwaFirmy) " +
                  "VALUES (@Id,@NF)", new { Id = ID, NF = ReadNFirmy });
                return result == 1;

                Console.WriteLine("Insert Succes");
            }
            else
            {
                Console.WriteLine("Nie udalo sie sparsowac id ");
                return false;
            }

          
        }
        

        public bool UpdateSpedytor()
        {
            Console.Write("Podaj nazwe firmy którą chcesz zmienić: ");
            var ReadLine = Console.ReadLine();
            Console.Write("Podaj id firmy którą chcesz zmienić: ");
            var ReadID = Console.ReadLine();
            Console.Write("Podaj nową nazwę firmy: ");
            var ReadNewNazwa = Console.ReadLine();
            Console.Write("Podaj nowy id firmy: ");
            var ReadIDNew = Console.ReadLine();
            var ResultParsID = int.TryParse(ReadID, out var ID);
            var ResultParsIDNew = int.TryParse(ReadIDNew, out var IdRead);
            if ((ResultParsID)&&(ResultParsIDNew))
            {
                var result = _connection.Execute("UPDATE Spedytorzy SET IDSpedytora =@IdNew," +
                " NazwaFirmy=@Nf WHERE NazwaFirmy=@nazwa_firmy AND IDSpedytora =@Id",
                new {  IdNew = IdRead, NF = ReadNewNazwa, nazwa_firmy = ReadLine, Id = ID });
                return result == 1;

                Console.WriteLine("Update Succes");
            }
            else
            {
                Console.WriteLine("Nie udalo sie sparsowac id ");
                return false;
            }
        }
       
        public bool DeleteSpedytor()
        {
            Console.Write("Podaj nazwe Firmy którą chcesz usunąć: ");
            var ReadLine = Console.ReadLine();
            Console.Write("Podaj id Firmy którą chcesz usunąć: ");
            var ReadLineID = Console.ReadLine();
            var ResultParsID = int.TryParse(ReadLineID, out var ID);
            if (ResultParsID)
            {
                 var result = _connection.Execute("DELETE Spedytorzy WHERE NazwaFirmy=@nazwa_firmy AND IDSpedytora=@Id",
                new { nazwa_firmy = ReadLine, Id = ID });
                Console.WriteLine("Delete Succes");
                return result == 1;
            }
            else
            {
                Console.WriteLine("Nie udalo sie sparsowac id ");
                return false;
            }

           
        }




    }

}
