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
    public partial class FormLoginSingle : KryptonForm
    {
        public FormLoginSingle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if ((kryptonTextBox1.Text.Length > 0) && (kryptonTextBox1.Text != "Введите имя"))
            {
                GameParametres.NameGamer = kryptonTextBox1.Text;
                Form1 fdb = new Form1();
                fdb.ShowDialog();
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
