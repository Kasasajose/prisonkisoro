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
    public partial class prisoner : Form
    {
        public prisoner()
        {
            InitializeComponent();
        }

        private void prisonerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.prisonerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.prisonerDataSet);

        }

        private void prisoner_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prisonerDataSet.prisoner' table. You can move, or remove it, as needed.
            this.prisonerTableAdapter.Fill(this.prisonerDataSet.prisoner);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu_form newform = new menu_form();
            this.Hide();
            newform.Show();
        }
        Bitmap bitmap;
        private void button2_Click(object sender, EventArgs e)
        {

            int height = prisonerDataGridView.Height;
            prisonerDataGridView.Height = prisonerDataGridView.RowCount * prisonerDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(prisonerDataGridView.Width, prisonerDataGridView.Height);
            prisonerDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, prisonerDataGridView.Width, prisonerDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            prisonerDataGridView.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
