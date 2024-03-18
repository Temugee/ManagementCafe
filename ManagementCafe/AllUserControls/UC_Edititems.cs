using System;
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
    public partial class UC_Edititems : UserControl
    {
        String query;
        function fn = new function();
        public UC_Edititems()
        {
            InitializeComponent();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Edititems_Load(object sender, EventArgs e)
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
        int id;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            String category = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtPrice.Text = price.ToString();
            txtName.Text = name.ToString();
            txtCategory.Text = category.ToString();
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            query = "Select pkId FROM categories WHERE CategoryName = N'" + txtCategory.Text + "'";
            DataSet ds = fn.getData(query);
            if (txtName.Text != "" && txtCategory.Text != "" && txtPrice.Text !="")
            {
                query = "UPDATE items SET Name = N'" + txtName.Text+ "', CategoryId = '" + ds.Tables[0].Rows[0][0].ToString() + "', Price = '" + txtPrice.Text + "' WHERE pkId = '" + id + "'";
                fn.setData(query);
                loadData("SELECT items.pkId, items.Name, categories.CategoryName, items.Price from items INNER JOIN categories ON items.CategoryId = categories.pkId");
                /*MessageBox.Show("Амжилттай шинэчиллээ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            else
            {
                MessageBox.Show("Бүх утгуудыг бөглөнө үү", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
