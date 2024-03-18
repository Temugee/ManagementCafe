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
    public partial class UC_Additems : UserControl
    {
        function fn = new function();
        String query;
        public UC_Additems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "Select pkId FROM categories WHERE CategoryName = N'" + txtCategory.Text + "'";
            DataSet ds = fn.getData(query);
            
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Барааны утгуудыг хоосон орхиж болохгүй", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPrice.Text == "0")
            {
                MessageBox.Show("Барааны үнэ 0 байж болохгүй", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            query = "INSERT INTO items (Name, CategoryId, Price) values (N'" + txtItemName.Text + "','" + ds.Tables[0].Rows[0][0].ToString() + "', '" + txtPrice.Text + "')";
            fn.setData(query);
            clearAll();

        }
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }

        private void UC_Additems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_Additems_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM categories";
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                txtCategory.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
        }
    }
}
