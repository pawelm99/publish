using System;

namespace ConsoleApp19
{
/*    Przygotuj niewielką strukturę danych w.NET Core.Stwórz klasę abstrakcyjną Osoba z polami Id, Imię i Nazwisko.Następnie 
        stwórz dwie klasy dziedziczące z Osoby - Klient i Pracownik.Pracownik powinien mieć DatęZatrudnienia i (null'owalną)
        DatęZwolnienia. Klient powinien posiadać pola NrTelefonu i NrRejestracyjny (pojazdu). Przygotuj dwa konteksty - z 
        zastosowaniem TPH i z zastosowaniem TPT. Dodaj do obu kontekstów kilka osób. Polecam również rzucić okiem jak EF zapisuje dane w bazie.*/
    class Program
    {
        static void Main(string[] args)
        {
            var tpt = new TPTKontekst();
            tpt.Pracownik.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Mikołaj", Nazwisko = " Kowalski" });
          /*  tpt.Pracownik.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Michał", Nazwisko = " Nowak" });
            tpt.Pracownik.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Wojtek", Nazwisko = " Nowak" });
            tpt.Klient.Add(new Klient { NrRejestracyjny = "34rt34", NrTelefonu = "967-254-764", Imie = "Piotrek", Nazwisko = " Kowalski" });
            tpt.Klient.Add(new Klient { NrRejestracyjny = "fdgdfg4", NrTelefonu = "633-254-234", Imie = "Bogdan", Nazwisko = " Nowak" });
            tpt.Klient.Add(new Klient { NrRejestracyjny = "dfg34g34", NrTelefonu = "231-435-125", Imie = "Stanisław", Nazwisko = " Nowak" });*/
            tpt.SaveChanges();

            var tpc = new TPCKontext();
            /*tpc.People.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Tomek", Nazwisko = " Kowalski" });
            tpc.People.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Michał", Nazwisko = " Nowak" });
            tpc.People.Add(new Pracownik { DataZatrudnienia = DateTime.Now, Imie = "Wojtek", Nazwisko = " Nowak" });
            tpc.People.Add(new Klient { NrRejestracyjny = "34rt34", NrTelefonu = "967-254-764", Imie = "Piotrek", Nazwisko = " Kowalski" });
            tpc.People.Add(new Klient { NrRejestracyjny = "fdgdfg4", NrTelefonu = "633-254-234", Imie = "Bogdan", Nazwisko = " Nowak" });*/
            tpc.People.Add(new Klient { NrRejestracyjny = "fv3fg", NrTelefonu = "758-654-423", Imie = "Konrad", Nazwisko = " Nowak" });
            tpc.SaveChanges();
        }
    }
}
