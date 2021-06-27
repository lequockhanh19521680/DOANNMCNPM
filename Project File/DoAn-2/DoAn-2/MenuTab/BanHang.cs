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
using System.Text.RegularExpressions;

namespace DoAn_2.MenuTab
{
    public partial class BanHang : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        // SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");

        public static string thanhToan = "";//nut Tính tiền chuyển tạm thời cho form TT
        public static string iDHoaDon = "";
        public static string hDMaSP = "";
        public static string hDTenSP = "";
        public static string hDDonGia = "";
        public static string hDSL = "";
        public static string hDLoai = "";
      //  public static string HDthanhtoan = "";
        public static string hDDonVi = "";
        public static string sDT = "";
        public static string tenKH = "";
        
        int checkSLSP;//kiem tra so luong san pham nao do trong ton kho
        int indexRow;
        public BanHang()
        {
            InitializeComponent();
            //test
        }

        private void AutoIDHD()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(IDhoadon) from HoaDon", connect);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            i++;
            txtsohd.Text = i.ToString();
            iDHoaDon = txtsohd.Text; // luu cho form tt
        }
        public void ClearSP()
        {
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            
            comboBoxloaisp.Text = null;
        }
        double sum;
        public void HuyHD()
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            txttongcongtiensp.Clear();
            txtgiamtientong.Clear();
            txtgiamphantramtong.Clear(); 
            txtthanhtoan.Clear();
            txtcongtientong.Clear();
            txtcongphantramtong.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            bool found = false;
            if(dataGridView1.Rows.Count>0)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if(Convert.ToString(row.Cells[0].Value) == txtmasp.Text)
                    {
                        //neu them san pham giong nhau se cộng dồn số lượng và tiền vào ô
                        row.Cells[2].Value = ( int.Parse(txtsoluongsp.Text) + Convert.ToInt16(row.Cells[2].Value.ToString()));
                        row.Cells[4].Value = (double.Parse(txttiensp.Text) + Convert.ToDouble(row.Cells[4].Value.ToString()));
                        found = true;
                        /////////////////////
                    }
                }
                if(!found)
                {
                    dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text);
                }
            }
            else
            {
                dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text);
            }
            /////////////////////
            //int n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = txtmasp.Text;
            //dataGridView1.Rows[n].Cells[1].Value = txttensp.Text;
            //dataGridView1.Rows[n].Cells[2].Value = txtsoluongsp.Text;
            //dataGridView1.Rows[n].Cells[3].Value = txtdongiasp.Text;
            //dataGridView1.Rows[n].Cells[4].Value = txttiensp.Text;
            //dataGridView1.Rows[n].Cells[5].Value = comboBoxdonvisp.Text;
            ////    dataGridView1.Rows[n].Cells[6].Value = txtgiamphantramsp.Text;
           
            //------------ tinh tong tien sp trong datagridview-------------///
             sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txttongcongtiensp.Text = sum.ToString("###,###");
            //------------------- update sql -----------------//
            try
            {
                using (var cmdupdatesl = new SqlCommand("update tonkho set soluongsp=soluongsp - '" + txtsoluongsp.Text + "' where masp='" + txtmasp.Text + "' "))
                {
                    cmdupdatesl.Connection = connect;
                    //cmd.Parameters.AddWithValue("@masp", txtmasp.Text);
                    //cmd.Parameters.AddWithValue("@slsp", txtsoluongsp.Text);
                    connect.Open();
                    if (cmdupdatesl.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã update");
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
                MessageBox.Show("loi update ne" + ex.Message);
            }
            ClearSP();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            //tra lai slsp
            using (var cMDEdit = new SqlCommand("update tonkho set soluongsp=soluongsp + '" + sLSPEdit + "' where masp='" + maSPEdit + "' "))
            {
                cMDEdit.Connection = connect;
                connect.Open();
                if (cMDEdit.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã update");
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công!");
                    connect.Close();
                }
                connect.Close();
            }

            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtmasp.Text;
            newDataRow.Cells[1].Value = txttensp.Text;
            newDataRow.Cells[2].Value = txtsoluongsp.Text;
            newDataRow.Cells[3].Value = txtdongiasp.Text;
            newDataRow.Cells[4].Value = txttiensp.Text;
            newDataRow.Cells[5].Value = comboBoxdonvisp.Text;
            newDataRow.Cells[6].Value = comboBoxloaisp.Text;

            //

            // tru slsp
           using (var cMDEdit2 = new SqlCommand("update tonkho set soluongsp=soluongsp - '" + txtsoluongsp.Text + "' where masp='" + txtmasp.Text + "' "))
           {
               cMDEdit2.Connection = connect;
               connect.Open();
               if (cMDEdit2.ExecuteNonQuery() > 0)
               {
                   MessageBox.Show("Đã update");
                   connect.Close();
               }
               else
               {
                   MessageBox.Show("Không thành công!");
                   connect.Close();
               }
               connect.Close();
           }

           ClearSP();
            sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txttongcongtiensp.Text = sum.ToString("###,###");

        }
        string maSPEdit;
        int sLSPEdit;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow.Index != -1)
            {
                ClearSP();
               

                txtmasp.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttensp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsoluongsp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdongiasp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
               
                txttiensp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboBoxdonvisp.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBoxloaisp.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtgiamphantramsp.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maSPEdit = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sLSPEdit = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                MessageBox.Show("No data!");
            }
        }
        string maSP1;
        int sLSP1;
        private void btnxoa_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                DataGridViewRow row = dataGridView1.Rows[item.Index];
                maSP1 = row.Cells[0].Value.ToString();
                sLSP1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                dataGridView1.Rows.RemoveAt(item.Index); //remove row in datagridview
            }
            //------------- tra lai soluong sp database -----------------//
            try
            {
                using (var cMDUpdatesl2 = new SqlCommand("update tonkho set soluongsp=soluongsp + '" + sLSP1 + "' where masp='" + maSP1 + "' "))
                {
                    cMDUpdatesl2.Connection = connect;
                    connect.Open();
                    if (cMDUpdatesl2.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã update");
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
                MessageBox.Show("loi update ne" + ex.Message);
            }
            //-----------------------------------------//
            sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txttongcongtiensp.Text = sum.ToString("###,###");
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ClearSP();
        }

        private void txttongcongtiensp_TextChanged(object sender, EventArgs e)
        {
            txtthanhtoan.Text = txttongcongtiensp.Text;
        }

        private void txtgiamtientong_TextChanged(object sender, EventArgs e)
        {
            txtgiamphantramtong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamphantramtong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if(txtgiamtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongCongTienSP;
                double truTienTongCong;
                double tCTienSauKhiTru;
                tongCongTienSP = double.Parse(txttongcongtiensp.Text);
                truTienTongCong = double.Parse(txtgiamtientong.Text);
                if (truTienTongCong > tongCongTienSP)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    tCTienSauKhiTru = tongCongTienSP - truTienTongCong;
                    txtthanhtoan.Text = tCTienSauKhiTru.ToString("###,###");
                    //pass form TT
                  //  HDthanhtoan = txtthanhtoan.Text;
                }
            }
        }

        private void txtgiamphantramtong_TextChanged(object sender, EventArgs e)
        {
            txtgiamtientong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if (txtgiamphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                txtgiamtientong.Enabled = false;
                double tongCongTienSP;
                double truPhanTramTong;
                double tCTienSauKhiTruPT;
                double tCTienSauKhiTruPT2;
                tongCongTienSP = double.Parse(txttongcongtiensp.Text);
                truPhanTramTong = double.Parse(txtgiamphantramtong.Text);

                if (truPhanTramTong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (truPhanTramTong > 0)
                {
                    tCTienSauKhiTruPT = (truPhanTramTong * tongCongTienSP) / 100;
                    tCTienSauKhiTruPT2 = tongCongTienSP - tCTienSauKhiTruPT;
                    txtthanhtoan.Text = tCTienSauKhiTruPT2.ToString("###,###");
                }
                else if (truPhanTramTong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }

            }

        }

        private void txtgiamtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!=',')
            {
                e.Handled = true;
            }
        }

        private void txtgiamphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_TextChanged(object sender, EventArgs e)
        {
            txtcongphantramtong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtcongphantramtong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongCongTienSP;
                double congTienTongCong;
                double tCTienSauKhiTru;
                tongCongTienSP = double.Parse(txttongcongtiensp.Text);
                congTienTongCong = double.Parse(txtcongtientong.Text);
                if (congTienTongCong > tongCongTienSP)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    tCTienSauKhiTru = tongCongTienSP + congTienTongCong;
                    txtthanhtoan.Text = tCTienSauKhiTru.ToString("###,###");
                }
            }
        }

        private void txtcongphantramtong_TextChanged(object sender, EventArgs e)
        {
            txtcongtientong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
             //   txtcongtientong.Enabled = false;
                double tongCongTienSP;
                double congPhanTramTong;
                double tCTienSauKhiCongPT;
                double tCTienSauKhiCongPT2;

                tongCongTienSP = double.Parse(txttongcongtiensp.Text);
                congPhanTramTong = double.Parse(txtcongphantramtong.Text);

                if (congPhanTramTong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (congPhanTramTong > 0)
                {
                    tCTienSauKhiCongPT = (congPhanTramTong * tongCongTienSP) / 100;
                    tCTienSauKhiCongPT2 = tCTienSauKhiCongPT + tongCongTienSP;
                    txtthanhtoan.Text = tCTienSauKhiCongPT2.ToString("###,###");
                }
                else if (congPhanTramTong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }

            }
        }

        private void txtcongphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        string colMaSP;
        string colTenSP;
        string colSLSP;
        string colLoaiSP;
        string colDVSP;
        string colDonGiaSP;
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {

            //------------------------------------------------// pass datadridview to listbox formTT
            ListBox listBox1a = new ListBox();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listBox1a.Items.Add(item.Cells[1].Value.ToString() + '/' + item.Cells[2].Value.ToString() + '/' + item.Cells[3].Value.ToString());
              //--  listBox1a.Items.Add(item.Cells[1].Value.ToString().PadRight(30) + item.Cells[4].Value.ToString());
            }
            //------------------------------------------------// datagridview masp,tensp,slsp to list
            //pass datagridview to listbox: masp,tensp,sl
            ListBox listBox3 = new ListBox();
            ListBox listBox4 = new ListBox();
            ListBox listBox5 = new ListBox();
            ListBox listBox6 = new ListBox();
            ListBox listBox7 = new ListBox();
            ListBox listBox8 = new ListBox();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listBox3.Items.Add(item.Cells[0].Value.ToString()).ToString();//masp
                listBox4.Items.Add(item.Cells[1].Value.ToString()).ToString();//tensp
                listBox5.Items.Add(item.Cells[2].Value.ToString()).ToString();//slsp
                listBox6.Items.Add(item.Cells[6].Value.ToString()).ToString();//loai
                listBox7.Items.Add(item.Cells[5].Value.ToString()).ToString();//donvi
                listBox8.Items.Add(item.Cells[3].Value.ToString()).ToString();//dongia
                colMaSP = string.Join(",", listBox3.Items.Cast<String>());
                colTenSP = string.Join(",", listBox4.Items.Cast<String>());
                colSLSP = string.Join(",", listBox5.Items.Cast<String>());
                colLoaiSP = string.Join(",", listBox6.Items.Cast<String>());
                colDVSP = string.Join(",", listBox7.Items.Cast<String>());
                colDonGiaSP = string.Join(",", listBox8.Items.Cast<String>());
            }
            
            hDMaSP = colMaSP;
            hDTenSP = colTenSP;
            hDSL = colSLSP;
            hDLoai = colLoaiSP;
            hDDonVi = colDVSP;
            hDDonGia = colDonGiaSP;
            //---------------------------------------------------//
            //pass data form tt
            thanhToan = txtthanhtoan.Text;
            var form2 = new BanHangTT(listBox1a.Items);
            HuyHD();
            AutoIDHD(); // clear toan bo textbox.... và làm mới ID
            form2.Show();
            //------------------------------------------------//

           
            
          //  BanHangTT frmTT = new BanHangTT();
          //  frmTT.Show();  
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmakh.Text))
                {
                    txttenkh.Clear();
                }
                else
                {
                    connect.Open();
                    string sQLKH = "select * from KhachHang where SDT=" + int.Parse(txtmakh.Text);
                    SqlCommand cMD = new SqlCommand(sQLKH, connect);
                    SqlDataReader dR = cMD.ExecuteReader();
                    if (dR.Read())
                    {
                        txttenkh.Text = (dR["TenKH"].ToString());
                        //luu tru cho form TT
                        tenKH = txttenkh.Text;
                        sDT = txtmakh.Text;
                    }
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                AutoIDHD();
                string sQLTenSP = "select tensp from tonkho";
                SqlCommand cMD = new SqlCommand(sQLTenSP, connect);
                connect.Open();
                SqlDataReader dR = cMD.ExecuteReader();
                AutoCompleteStringCollection autotensp = new AutoCompleteStringCollection();
                while (dR.Read())
                {
                    autotensp.Add(dR.GetString(0));
                    
                }
                txttensp.AutoCompleteMode = AutoCompleteMode.Suggest;
                txttensp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txttensp.AutoCompleteCustomSource = autotensp;
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txttensp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttensp_KeyDown(object sender, KeyEventArgs e)
        {
            string loaiSP1;
            double giamGiaTextbox;
            
            if(e.KeyCode==Keys.Enter)
            {
                connect.Open();
                string sqlsp = "select * from tonkho where (tensp= N'"+ txttensp.Text+"') ";
                SqlCommand cmd2 = new SqlCommand(sqlsp, connect);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    checkSLSP = Convert.ToInt32(dr2["soluongsp"]);
                    if(checkSLSP<1)
                    {
                        MessageBox.Show("het hang");
                    }
                    else
                    {
                        txtmasp.Text = (dr2["masp"].ToString());
                        txtdongiasp.Text = (dr2["giabansp"].ToString());
                        txtsoluongsp.Text = "1";
                        txtgiamphantramsp.Text = (dr2["giamgia"].ToString());
                        comboBoxdonvisp.Text = (dr2["donvisp"].ToString());
                        comboBoxloaisp.Text = (dr2["loaisp"].ToString());
                        //thanhtiensp = soluong * don gia
                        double slsp;
                        double dongiasp;
                        double thanhtiensp;
                        double thanhtiensp2;
                        slsp = double.Parse(txtsoluongsp.Text);
                        dongiasp = double.Parse(txtdongiasp.Text);

                        thanhtiensp = slsp * dongiasp;
                        //tien giam gia cua san pham
                        giamGiaTextbox = double.Parse(txtgiamphantramsp.Text);
                        double giamgiasp = (giamGiaTextbox * thanhtiensp) / 100;
                        //tien san pham = (so luong * don gia ) - giam gia
                        thanhtiensp2 = thanhtiensp - giamgiasp;

                        txttiensp.Text = thanhtiensp2.ToString("###,###");

                        //luu tru cho from  TT
                        loaiSP1 = comboBoxloaisp.Text;//
                        //  HDmasp = txtmasp.Text;
                        //  HDdongia = txtdongiasp.Text;
                        //  HDsl = txtsoluongsp.Text;
                        //  HDdonvi = comboBoxdonvisp.Text;
                        //  HDtensp = txttensp.Text;
                         //   HDloai = loaisp1;
                    }

                }
                connect.Close();
            }
        }

        private void txtsoluongsp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsoluongsp.Text))
            {
                
            }
            else if (string.IsNullOrWhiteSpace(txtdongiasp.Text))
            {

            }
            else if (string.IsNullOrWhiteSpace(txtgiamphantramsp.Text))
            {

            }
            else
            {
                int slspHienTai = Convert.ToInt32(txtsoluongsp.Text);
                if(slspHienTai>checkSLSP)
                {
                    txtsoluongsp.Text = checkSLSP.ToString();
                }
                else
                {
                    double giamGiaTextbox;
                    double sLSP;
                    double donGiaSP;
                    double thanhTienSP;
                    double thanhTienSP2;
                    sLSP = double.Parse(txtsoluongsp.Text);
                    donGiaSP = double.Parse(txtdongiasp.Text);
                    thanhTienSP = sLSP * donGiaSP;

                    //tien giam gia cua san pham
                    giamGiaTextbox = double.Parse(txtgiamphantramsp.Text);
                    double giamGiaSP = (giamGiaTextbox * thanhTienSP) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhTienSP2 = thanhTienSP - giamGiaSP;


                    txttiensp.Text = thanhTienSP2.ToString("###,###");
                }
                

            }
 
        }

        private void btnhuyHD_Click(object sender, EventArgs e)
        {
            HuyHD();
            AutoIDHD();

        }

        private void txttensp_TextChanged_1(object sender, EventArgs e)
        {

        }
     //   string maspdata1;

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtmasp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double giamGiaTextbox;
                connect.Open();
                string sqlsp = "select * from tonkho where (masp= '" + txtmasp.Text + "') ";
                SqlCommand cmd2 = new SqlCommand(sqlsp, connect);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    txtmasp.Text = (dr2["masp"].ToString());
                    txttensp.Text = (dr2["tensp"].ToString());
                    txtdongiasp.Text = (dr2["giabansp"].ToString());
                    txtsoluongsp.Text = "1";
                    txtgiamphantramsp.Text = (dr2["giamgia"].ToString());
                    comboBoxdonvisp.Text = (dr2["donvisp"].ToString());
                    comboBoxloaisp.Text = (dr2["loaisp"].ToString());
                    //thanhtiensp = soluong * don gia
                    double sLSP;
                    double donGiaSP;
                    double thanhTienSP;
                    double thanhTienSP2;
                    sLSP = double.Parse(txtsoluongsp.Text);
                    donGiaSP = double.Parse(txtdongiasp.Text);
                    thanhTienSP = sLSP * donGiaSP;
                    //tien giam gia cua san pham
                    giamGiaTextbox = double.Parse(txtgiamphantramsp.Text);
                    double giamGiaSP = (giamGiaTextbox * thanhTienSP) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhTienSP2 = thanhTienSP - giamGiaSP;

                    txttiensp.Text = thanhTienSP2.ToString("###,###");

                }
                connect.Close();
            }
        }

        private void txtsoluongsp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtdongiasp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txttiensp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnscansp_Click(object sender, EventArgs e)
        {

        }
    }
}
