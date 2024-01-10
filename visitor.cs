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
    public partial class visitor : Form
    {
        public visitor()
        {
            InitializeComponent();
        }

        private void visitorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.visitorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.visitorDataSet);

        }

        private void visitor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'visitorDataSet.visitor' table. You can move, or remove it, as needed.
            this.visitorTableAdapter.Fill(this.visitorDataSet.visitor);

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

            int height = visitorDataGridView.Height;
            visitorDataGridView.Height = visitorDataGridView.RowCount * visitorDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(visitorDataGridView.Width, visitorDataGridView.Height);
            visitorDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, visitorDataGridView.Width, visitorDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            visitorDataGridView.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
