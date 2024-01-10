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
    public partial class lawyer : Form
    {
        public lawyer()
        {
            InitializeComponent();
        }

        private void lawyerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lawyerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.lawyerDataSet);

        }

        private void lawyer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lawyerDataSet.lawyer' table. You can move, or remove it, as needed.
            this.lawyerTableAdapter.Fill(this.lawyerDataSet.lawyer);

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

            int height = lawyerDataGridView.Height;
            lawyerDataGridView.Height = lawyerDataGridView.RowCount * lawyerDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(lawyerDataGridView.Width, lawyerDataGridView.Height);
            lawyerDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, lawyerDataGridView.Width, lawyerDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            lawyerDataGridView.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
