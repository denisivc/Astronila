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
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = GameParametres.NameGamer;
        }

        
        //вызов формы звезд
        private void button1_Click(object sender, EventArgs e)
        {

            FormStarsDB fdb = new FormStarsDB();
            fdb.ShowDialog();

        }
        //вызов формы созвездий
        private void button2_Click(object sender, EventArgs e)
        {
            FormSovz fzv = new FormSovz();

            fzv.ShowDialog();
        }
        //вызов формы статистики
        private void button3_Click(object sender, EventArgs e)
        {
            
            Stats fs = new Stats(); 
            fs.ShowDialog();
        }
        //выход из программы
        private void button4_Click(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FormStarsDB fdb = new FormStarsDB();
            fdb.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            FormSovz fzv = new FormSovz();

            fzv.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Stats fs = new Stats();
            fs.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    
}
