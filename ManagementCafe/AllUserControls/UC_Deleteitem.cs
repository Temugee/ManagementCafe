using DevExpress.Xpo.DB.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementCafe.AllUserControls
{
    public partial class UC_Deleteitem : UserControl
    {
        function fn = new function();
        String query;
        public UC_Deleteitem()
        {
            InitializeComponent();
        }

        private void UC_Deleteitem_Load(object sender, EventArgs e)
        {
            query = "SELECT items.pkId, items.Name, categories.CategoryName, items.Price from items INNER JOIN categories ON items.CategoryId = categories.pkId";
            loadData(query);
        }
        public void loadData(String qur)
        {
            query = qur;
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM items WHERE Name LIKE'" + txtSearchItem.Text + "%'";
            loadData(query);
        }

        private void guna2DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Барааг устгахдаа итгэлтэй байна уу", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from items where iid = '" + id + "'";
                fn.setData(query);
                loadData("select * from items");
            }
        }

        private void UC_Deleteitem_Enter(object sender, EventArgs e)
        {
            loadData("SELECT * FROM items");
        }
    }
}
