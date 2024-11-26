using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Astronila
{
    public partial class FormLoginTwo : KryptonForm
    {
        public FormLoginTwo()
        {
            InitializeComponent();
        }

        

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text.Length > 0 && kryptonTextBox2.Text.Length > 0)
            {
                GameParametres.NameGamer1 = kryptonTextBox1.Text;
                GameParametres.NameGamer2 = kryptonTextBox2.Text;

                Form2 fdb2 = new Form2();
                fdb2.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Имя не может быть пустым, Введите Имя!");
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
