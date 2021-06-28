using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DoAn_2.MenuTab
{

    public partial class TonKho : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
        string imgLoc = "";

        SqlCommand command;
        public void gridviewsp()
        {
            string querysp = @"select masp as 'Mã sản phẩm', tensp as 'Tên sản phẩm', soluongsp as 'Số lượng', gianhapsp as 'Giá nhập', giabansp as 'Giá bán', loaisp as 'Loại', donvisp as 'Đơn vị',giamgia as 'Giảm giá' from tonkho";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querysp, connect);
            DataTable datatbsp = new DataTable();
            sqldatasp.Fill(datatbsp);
            dataGridView1.DataSource = datatbsp;
            connect.Close();
        }

        public void clearsp()
        {
            txtId.Clear();
            txtTensp.Clear();
            txtSl.Clear();
            txtGianhap.Clear();
            txtGiaban.Clear();
            comboLoai.SelectedItem = null;
            comboDonvi.SelectedItem = null;
            // pictureBox1.Image = null;
            pictureBox1.Image = Properties.Resources._default;
        }
        private void autoid()
        {
            if (comboLoai.SelectedIndex == -1)
            {
                //    MessageBox.Show("nhập thông tin!");
            }
            else
            {
                string comboselected = this.comboLoai.GetItemText(this.comboLoai.SelectedItem);
                // string s1 = comboselected.Substring(0, comboselected.IndexOf(" "));
                string s1 = comboselected.Substring(0, 1);
                string s2 = comboselected.Substring(comboselected.IndexOf(" ") + 1);
                if (s2 == null)
                {
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s1.Substring(0, 1).ToUpper();
                    String s3 = String.Concat(s1a, s2a);

                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from tonkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();
                    i++;
                    txtId.Text = s3 + i.ToString();
                }
                else
                {
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s2.Substring(0, 1).ToUpper();
                    String s3 = String.Concat(s1a, s2a);

                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from tonkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();
                    i++;
                    txtId.Text = s3 + i.ToString();
                }

            }
        }

        public TonKho()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridviewsp();

            // string querysp = @"select masp as 'Mã sản phẩm', tensp as 'Tên sản phẩm', soluongsp as 'Số lượng', gianhapsp as 'Giá nhập', giabansp as 'Giá bán', loaisp as 'Loại', donvisp as 'Đơn vị'from sanpham;";
            string queryloai = @"select * from loaisp";
            string querydonvi = @"select * from donvisp";

            // SqlDataAdapter sqldatasp = new SqlDataAdapter(querysp, connect);
            SqlDataAdapter sqldataloai = new SqlDataAdapter(queryloai, connect);
            SqlDataAdapter sqldatadonvi = new SqlDataAdapter(querydonvi, connect);

            // DataTable datatbsp = new DataTable();
            DataTable datatbloai = new DataTable();
            DataTable datatbdonvi = new DataTable();

            // sqldatasp.Fill(datatbsp);
            sqldataloai.Fill(datatbloai);
            sqldatadonvi.Fill(datatbdonvi);

            //combobox
            comboLoai.Items.Clear();
            comboDonvi.Items.Clear();
            foreach (DataRow dr in datatbloai.Rows)
            {
                comboLoai.Items.Add(dr["TenLoai"].ToString());
            }
            foreach (DataRow dr2 in datatbdonvi.Rows)
            {
                comboDonvi.Items.Add(dr2["TenDonvi"].ToString());
            }
            connect.Close();
            //table
            // dataGridView1.DataSource = datatbsp;
        }



        private void sanpham_Load(object sender, EventArgs e)
        {


        }



        byte[] currentimg;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                clearsp();

                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTensp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSl.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtGianhap.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtGiaban.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboLoai.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboDonvi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtGiamGia.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                try
                {
                    string sql1 = "select anhsp from tonkho where masp='" + txtId.Text + "' ";

                    if (connect.State != ConnectionState.Open)
                        connect.Open();
                    command = new SqlCommand(sql1, connect);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    if (reader.HasRows)
                    {
                        byte[] img = (byte[])(reader[0]);
                        if (img == null)
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);

                        }
                        //  MessageBox.Show(img.ToString());
                        connect.Close();
                    }
                    else
                    {
                        connect.Close();
                        MessageBox.Show("bi loi");
                    }

                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("loi bang: " + ex.Message);
                }
                txtId.ReadOnly = true;
                //=====================

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    using (var cmd = new SqlCommand("update tonkho set tensp=@tensp,soluongsp=@soluongsp,gianhapsp=@gianhapsp,giabansp=@giabansp,loaisp=@loaisp,donvisp=@donvisp,anhsp=@anhsp where masp=@masp"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@masp", txtId.Text);
                        cmd.Parameters.AddWithValue("@tensp", txtTensp.Text);
                        cmd.Parameters.AddWithValue("@soluongsp", txtSl.Text);
                        cmd.Parameters.AddWithValue("@gianhapsp", txtGianhap.Text);
                        cmd.Parameters.AddWithValue("@giabansp", txtGiaban.Text);
                        cmd.Parameters.AddWithValue("@loaisp", comboLoai.GetItemText(comboLoai.SelectedItem));
                        cmd.Parameters.AddWithValue("@donvisp", comboDonvi.GetItemText(comboDonvi.SelectedItem));
                        cmd.Parameters.AddWithValue("@anhsp", img);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lựu");
                            gridviewsp();
                            txtId.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                            txtId.ReadOnly = true;
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {


                try
                {
                    using (var cmd = new SqlCommand("delete tonkho where masp=@masp"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@masp", txtId.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa");
                            clearsp();
                            gridviewsp();
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during insert: " + ex.Message);
                }

            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void btnButtonChooseIMG_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Error during insert: " + ex.Message);
            }
        }

        private void btnDeleteIMG_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new SqlCommand("update tonkho set anhsp=null where masp=@masp"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@masp", txtId.Text);
                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã xóa");
                        clearsp();
                        gridviewsp();
                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
                    }
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Error during insert: " + ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp from tonkho where ( masp like '" + txtSearch.Text + "%' or tensp like N'" + txtSearch.Text + "%' or soluongsp like '" + txtSearch.Text + "%' or gianhapsp like '" + txtSearch.Text + "%' or giabansp like '" + txtSearch.Text + "%'  or loaisp like N'" + txtSearch.Text + "%'  or donvisp like N'" + txtSearch.Text + "%'     )", connect))
                {
                    DataTable dtsearch = new DataTable("tonkho");
                    da.Fill(dtsearch);
                    dataGridView1.DataSource = dtsearch;

                }
                connect.Close();
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    LabelSearch.Text = "Đã tìm thấy";
                }
                else
                {
                    LabelSearch.Text = "Không tìm thấy...";
                }

                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    LabelSearch.Text = "Tìm kiếm";
                }


            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }



        private void comboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                autoid();
            }
            else
            {

            }

        }

        private void ButtonAutoid_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            //  workbook.SaveAs("C:\\Users\\lionel\\Desktop\\Test\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //  app.Quit(); 
        }
    }
}