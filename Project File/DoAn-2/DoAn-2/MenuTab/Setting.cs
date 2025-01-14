﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_2.MenuTab
{
    public partial class Setting : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        // SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
        SqlDataAdapter adap;
        DataSet danhSachKhacHang;
        Label idThongTin = new Label();
        string imgLogoLoc = "";

        public Setting()
        {
            if(MainControl.tennv=="Admin")
            {
                //MessageBox.Show("ban la nhan vien");
                InitializeComponent();
                GridviewNhanVien();
                GridviewKhachHang();
            }
            else
            {
                MessageBox.Show("Chỉ có admin mới có thể truy cập chức năng này!");

            }

        }

        public void GridviewNhanVien()
        {
            //data grid view nhan vien
            string querynv = @"select STT as 'STT', usernv as 'Tên tài khoản', tennv as 'Tên nhân viên', passnv as 'Mật khẩu' from nhanvien";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querynv, connect);
            DataTable datatbsp = new DataTable();
            sqldatasp.Fill(datatbsp);
            dataGridViewNV.DataSource = datatbsp;
            connect.Close();

        }
        private void GridviewKhachHang()
        {
            //datagridview thong tin khach hang

            try
            {
                connect.Open();
                adap = new SqlDataAdapter("select IDkh as 'ID', TenKH as 'Tên khách hàng', SDT as 'SĐT', DiaChi as 'Địa chỉ',Email as 'Email' from KhachHang",connect);
                danhSachKhacHang = new System.Data.DataSet();
                adap.Fill(danhSachKhacHang, "KhachHangTable");
                dataGridViewKH.DataSource = danhSachKhacHang.Tables[0];
                //string querykh = @"select IDkh as 'ID', TenKH as 'Tên khách hàng', SDT as 'SĐT', DiaChi as 'Địa chỉ',Email as 'Email' from KhachHang";
                //SqlDataAdapter sqldatakh = new SqlDataAdapter(querykh, connect);
                //DataTable datatbkh = new DataTable();
                //sqldatakh.Fill(datatbkh, "KhachHangTable");
                //dataGridViewKH.DataSource = datatbkh;
                //connect.Close();
            }
            catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public void ClearNV()
        {
            txtUserNV.Clear();
            txtNameNV.Clear();
            txtPassNV.Clear();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNV.Text))
            {
                MessageBox.Show("Trống!");
                txtUserNV.Select();
            }

            if (string.IsNullOrWhiteSpace(txtNameNV.Text))
            {
                txtNameNV.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtPassNV.Text))
            {
                txtPassNV.Select();
            }
            else
            {
                using (var cmd = new SqlCommand("INSERT INTO nhanvien (usernv,tennv,passnv) VALUES (@usernv,@tennv,@passnv)"))
                {
                    cmd.Connection = connect;
                //    cmd.Parameters.AddWithValue("@usernv", txtUserNV.Text);
                    cmd.Parameters.AddWithValue("@usernv", txtUserNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtNameNV.Text);
                    cmd.Parameters.AddWithValue("@passnv", txtPassNV.Text);
                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã thêm");
                        connect.Close();
                        ClearNV();
                        GridviewNhanVien();

                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
                        connect.Close();
                    }
                    connect.Close();

                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNV.Text))
            {
                MessageBox.Show("Trống!");
                txtUserNV.Select();
            }

            if (string.IsNullOrWhiteSpace(txtNameNV.Text))
            {
                txtNameNV.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtPassNV.Text))
            {
                txtPassNV.Select();
            }
            else
            {
                try
                {
                    using (var cmd = new SqlCommand("update nhanvien set usernv=@usernv,tennv=@tennv,passnv=@passnv where STT=@STT"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@STT", txtSttNV.Text);
                        cmd.Parameters.AddWithValue("@usernv", txtUserNV.Text);
                        cmd.Parameters.AddWithValue("@tennv", txtNameNV.Text);
                        cmd.Parameters.AddWithValue("@passnv", txtPassNV.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lựu");
                            connect.Close();
                            ClearNV();
                            GridviewNhanVien();
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
                    MessageBox.Show("Error during update: " + ex.Message);
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNV.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    using (var cmd = new SqlCommand("delete nhanvien where usernv=@usernv"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@usernv", txtUserNV.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa");
                            connect.Close();
                            ClearNV();
                            GridviewNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!");
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during delete: " + ex.Message);
                }

            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearNV();

        }
             
        private void Setting_Load(object sender, EventArgs e)
        {
            try
            {
                connect.Close();
                connect.Open();
                string sqlQuery = "select ID,TenShop,Diachi,SDT,Loichao from ThongTinShop";
                SqlCommand command = new SqlCommand(sqlQuery, connect);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    idThongTin.Text = sqlDataReader["ID"].ToString();
                    txtTenShop.Text = sqlDataReader["TenShop"].ToString();
                    txtSDT.Text = sqlDataReader["SDT"].ToString();
                    txtDiaChi.Text = sqlDataReader["Diachi"].ToString();
                    txtLoiChao.Text = sqlDataReader["Loichao"].ToString();
                }
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }
            // hien thi anh logo setting
            try
            {
                SqlCommand command;
                string sqlLogo = "select logo from ThongTinShop where ID=1 ";
                if (connect.State 
                    != ConnectionState.Open)
                    connect.Open();

                command = new SqlCommand(sqlLogo, connect); 
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
                        MemoryStream memoryStream = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(memoryStream);

                    }
                    //  MessageBox.Show(img.ToString());
                    connect.Close();
                }
                else
                {
                    connect.Close();
                    MessageBox.Show("Bị lỗi");
                }

            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Lỗi Logo: " + ex.Message);
            }

        }

        private void BtnSaveThongtin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenShop.Text))
            {
                MessageBox.Show("Trống!");
                txtTenShop.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                txtSDT.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                txtDiaChi.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtLoiChao.Text))
            {
                txtLoiChao.Select();
            }
            else
            {
                try
                {
                    using (var cmd = new SqlCommand("update ThongTinShop set TenShop=@TenShop,SDT=@SDT,Diachi=@Diachi,Loichao=@Loichao where ID=1"))
                    {
                        
                        cmd.Connection = connect;
                        //cmd.Parameters.AddWithValue("@ID", IDtt.Text);
                        cmd.Parameters.AddWithValue("@TenShop", txtTenShop.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@Loichao", txtLoiChao.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lưu");
                            connect.Close();
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
                    MessageBox.Show("Error during update tt: " + ex.Message);
                }
            }
        }

        private void dataGridViewNV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNV.CurrentRow.Index != -1)
            {
                txtSttNV.Text = dataGridViewNV.CurrentRow.Cells[0].Value.ToString();
                txtUserNV.Text = dataGridViewNV.CurrentRow.Cells[1].Value.ToString();
                txtNameNV.Text = dataGridViewNV.CurrentRow.Cells[2].Value.ToString();
                txtPassNV.Text = dataGridViewNV.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {

            }
        }

        private void btnButtonChooseIMG_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog diaLog = new OpenFileDialog();
                if (diaLog.ShowDialog() == DialogResult.OK)
                {
                    imgLogoLoc = diaLog.FileName.ToString();
                    pictureBox1.ImageLocation = imgLogoLoc;
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Error during insert: " + ex.Message);
            }
        }

        private void SaveIMGlogo_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fileStream = new FileStream(imgLogoLoc, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                img = binaryReader.ReadBytes((int)fileStream.Length);
                using (var cmd = new SqlCommand("update ThongTinShop set logo=@logo where ID=1"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@logo", img);
                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã lưu");
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
                MessageBox.Show(ex.Message);
            }
        }

        SqlCommandBuilder cmdBuilder;
        private void btnUpdateKH_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmdBuilder = new SqlCommandBuilder();
                adap.UpdateCommand = new SqlCommandBuilder(adap).GetUpdateCommand();
                adap.Update(danhSachKhacHang, "KhachHangTable");
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
