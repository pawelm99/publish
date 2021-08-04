using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Utwórz prostą aplikację WinForms.
Dodaj do formularza funkcje rejestracji i logowania.
Podziel formularz na dwie części. W sekcji rejestracji dodaj TextBoxy "Login", "Hasło", "Powtórz Hasło". 
Dodaj CheckBox "Zgoda RODO". Pola z hasłem muszą ukrywać znaki (wyświetlać kropki). Dodaj Button "Zarejestruj", 
który utworzy konto w dowolnej kolekcji. Po zarejestrowaniu wyświetl MessageBox z informacją o poprawnym 
zarejestrowaniu. Żeby utworzyć konto, Login nie może być pusty, hasła muszą się zgadzać a Checkbox musi być zaznaczony.
W sekcji logowania dodaj tylko Textboxy "Login", "Hasło" i Button "Zaloguj". Pole z hasłem musi ukrywać znaki. 
Dane muszą należeć do istniejącego konta. Wyświetl MessageBox z powiadomieniem.*/

namespace Zadanie5_WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PanelUzytkownika());
        }
    }
}
