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
    public partial class Logowanie : Form
    {
        private List<Uzytkownik.Uzytkownik> users;
        private string textLogin { get; set; }
        private string textHaslo { get; set; }
        public Logowanie(List<Uzytkownik.Uzytkownik> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Message();
            var CheckUser = users.Find(x=>x.Nazwa ==textLogin);

            if((CheckUser != null)&& (CheckUser.Hasło == textHaslo))
            {
                    form.label1.Text = $"Zalogowano na: {textLogin}";
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
            }

            else
            {
                form.label1.Text = $"Błędne hasło lub login";
                form.ShowDialog();
            }

        }

     

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Login";
            label2.Text = "Hasło";
            button1.Text = "Zajoluj";
            textBox2.PasswordChar = '*';
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textLogin= textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textHaslo = textBox2.Text;
        }
    }
}
