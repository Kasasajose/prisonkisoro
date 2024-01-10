using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_form
{
    public partial class menu_form : Form
    {
        public menu_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            staff newform = new staff();
            this.Hide();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prisoner newform = new prisoner();
            this.Hide();
            newform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            equip newform = new equip();
            this.Hide();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lawyer newform = new lawyer();
            this.Hide();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            visitor newform = new visitor();
            this.Hide();
            newform.Show();
        }
    }
}
