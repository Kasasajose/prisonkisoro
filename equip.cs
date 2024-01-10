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
    public partial class equip : Form
    {
        public equip()
        {
            InitializeComponent();
        }

        private void equipmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.equipmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.equipDataSet);

        }

        private void equip_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'equipDataSet.equipment' table. You can move, or remove it, as needed.
            this.equipmentTableAdapter.Fill(this.equipDataSet.equipment);

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

            int height = equipmentDataGridView.Height;
            equipmentDataGridView.Height = equipmentDataGridView.RowCount * equipmentDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(equipmentDataGridView.Width, equipmentDataGridView.Height);
            equipmentDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, equipmentDataGridView.Width, equipmentDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            equipmentDataGridView.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
