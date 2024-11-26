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
    public partial class Form2 : KryptonForm
    {
        public Form2()
        {
            InitializeComponent();
            label3.Text = GameParametres.NameGamer1 + "  и  " + GameParametres.NameGamer2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormStarsTwo fdbS2 = new FormStarsTwo();
            fdbS2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSozvTwo fdbSoz2 = new FormSozvTwo();
            fdbSoz2.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FormStarsTwo fdbS2 = new FormStarsTwo();
            fdbS2.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            FormSozvTwo fdbSoz2 = new FormSozvTwo();
            fdbSoz2.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
