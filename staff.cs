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
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
        }

        private void staffBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.staffBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.staffDataSet);

        }

        private void staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'staffDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.staffDataSet.staff);

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
            int height = staffDataGridView.Height;
            staffDataGridView.Height = staffDataGridView.RowCount * staffDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(staffDataGridView.Width, staffDataGridView.Height);
            staffDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, staffDataGridView.Width, staffDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            staffDataGridView.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
