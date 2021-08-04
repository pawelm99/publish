using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie5_WinForms
{
    public partial class PanelUzytkownika : Form
    {
        public List<Uzytkownik.Uzytkownik> users;
        public PanelUzytkownika()
        {
            InitializeComponent();
             users = new List<Uzytkownik.Uzytkownik>();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var user = new Uzytkownik.Uzytkownik();
            var form = new Rejestracja(  user);
            form.ShowDialog();
            users.Add(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Logowanie(users);
            form.ShowDialog();
        }

       
    }
}
