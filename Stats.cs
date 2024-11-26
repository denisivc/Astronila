using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Astronila.Controller;
using ComponentFactory.Krypton.Toolkit;

namespace Astronila
{
    public partial class Stats : KryptonForm
    {
        Query controller;
        public Stats()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
        }

        private void label1Stats_Click(object sender, EventArgs e)
        {
            
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetQuestion("Users");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
