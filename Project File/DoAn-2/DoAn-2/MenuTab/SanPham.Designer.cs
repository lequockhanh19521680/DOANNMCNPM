namespace DoAn_2.MenuTab
{
    partial class SanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtgiaban = new System.Windows.Forms.TextBox();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDeleteIMG = new FontAwesome.Sharp.IconButton();
            this.btnButtonChooseIMG = new FontAwesome.Sharp.IconButton();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.comboloai = new System.Windows.Forms.ComboBox();
            this.combodonvi = new System.Windows.Forms.ComboBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKhuyenmai = new System.Windows.Forms.TextBox();
            this.btnExportExcel = new FontAwesome.Sharp.IconButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(412, 108);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(751, 383);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(152, 21);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(239, 22);
            this.txtid.TabIndex = 1;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(152, 54);
            this.txttensp.Margin = new System.Windows.Forms.Padding(4);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(239, 22);
            this.txttensp.TabIndex = 2;
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(152, 89);
            this.txtsl.Margin = new System.Windows.Forms.Padding(4);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(239, 22);
            this.txtsl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Giá bán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Giá nhập";
            // 
            // txtgiaban
            // 
            this.txtgiaban.Location = new System.Drawing.Point(152, 154);
            this.txtgiaban.Margin = new System.Windows.Forms.Padding(4);
            this.txtgiaban.Name = "txtgiaban";
            this.txtgiaban.Size = new System.Drawing.Size(239, 22);
            this.txtgiaban.TabIndex = 12;
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(152, 121);
            this.txtgianhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(239, 22);
            this.txtgianhap.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 225);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Đơn vị";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(23, 299);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(77, 49);
            this.btnadd.TabIndex = 19;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnAdd);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(120, 299);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(80, 49);
            this.btnsave.TabIndex = 20;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnSave);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(217, 299);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(76, 49);
            this.btndelete.TabIndex = 21;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btnDelete);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAn_2.Properties.Resources._default;
            this.pictureBox1.Location = new System.Drawing.Point(23, 356);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnDeleteIMG
            // 
            this.btnDeleteIMG.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDeleteIMG.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDeleteIMG.IconColor = System.Drawing.Color.Black;
            this.btnDeleteIMG.IconSize = 16;
            this.btnDeleteIMG.Location = new System.Drawing.Point(217, 356);
            this.btnDeleteIMG.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteIMG.Name = "btnDeleteIMG";
            this.btnDeleteIMG.Rotation = 0D;
            this.btnDeleteIMG.Size = new System.Drawing.Size(175, 58);
            this.btnDeleteIMG.TabIndex = 23;
            this.btnDeleteIMG.Text = "Xóa ảnh";
            this.btnDeleteIMG.UseVisualStyleBackColor = true;
            this.btnDeleteIMG.Click += new System.EventHandler(this.btnDeleteIMG_Click);
            // 
            // btnButtonChooseIMG
            // 
            this.btnButtonChooseIMG.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnButtonChooseIMG.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnButtonChooseIMG.IconColor = System.Drawing.Color.Black;
            this.btnButtonChooseIMG.IconSize = 16;
            this.btnButtonChooseIMG.Location = new System.Drawing.Point(217, 433);
            this.btnButtonChooseIMG.Margin = new System.Windows.Forms.Padding(4);
            this.btnButtonChooseIMG.Name = "btnButtonChooseIMG";
            this.btnButtonChooseIMG.Rotation = 0D;
            this.btnButtonChooseIMG.Size = new System.Drawing.Size(175, 58);
            this.btnButtonChooseIMG.TabIndex = 24;
            this.btnButtonChooseIMG.Text = "Chọn ảnh";
            this.btnButtonChooseIMG.UseVisualStyleBackColor = true;
            this.btnButtonChooseIMG.Click += new System.EventHandler(this.btnButtonChooseIMG_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(412, 66);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(260, 22);
            this.txtsearch.TabIndex = 25;
            this.txtsearch.TextChanged += new System.EventHandler(this.TxtsearchTextChanged);
            // 
            // comboloai
            // 
            this.comboloai.FormattingEnabled = true;
            this.comboloai.Items.AddRange(new object[] {
            "Nước ngọt",
            "Bánh",
            "Mì",
            "Nước suối",
            "Xúc xích"});
            this.comboloai.Location = new System.Drawing.Point(152, 187);
            this.comboloai.Margin = new System.Windows.Forms.Padding(4);
            this.comboloai.Name = "comboloai";
            this.comboloai.Size = new System.Drawing.Size(239, 24);
            this.comboloai.TabIndex = 27;
            this.comboloai.SelectedIndexChanged += new System.EventHandler(this.cboSelectedIndexChangedLoai);
            // 
            // combodonvi
            // 
            this.combodonvi.FormattingEnabled = true;
            this.combodonvi.Items.AddRange(new object[] {
            "Chai",
            "Lon",
            "Gói",
            "Hộp",
            "Thùng"});
            this.combodonvi.Location = new System.Drawing.Point(152, 225);
            this.combodonvi.Margin = new System.Windows.Forms.Padding(4);
            this.combodonvi.Name = "combodonvi";
            this.combodonvi.Size = new System.Drawing.Size(239, 24);
            this.combodonvi.TabIndex = 28;
            this.combodonvi.SelectedIndexChanged += new System.EventHandler(this.cboSelectedIndexChangedDonVi);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(316, 299);
            this.btnclear.Margin = new System.Windows.Forms.Padding(4);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(76, 49);
            this.btnclear.TabIndex = 29;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnClear);
            // 
            // LabelSearch
            // 
            this.LabelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSearch.Location = new System.Drawing.Point(681, 68);
            this.LabelSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(82, 21);
            this.LabelSearch.TabIndex = 30;
            this.LabelSearch.Text = "Tìm kiếm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "Khuyến mãi";
            // 
            // txtKhuyenmai
            // 
            this.txtKhuyenmai.Location = new System.Drawing.Point(152, 262);
            this.txtKhuyenmai.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhuyenmai.Name = "txtKhuyenmai";
            this.txtKhuyenmai.Size = new System.Drawing.Size(239, 22);
            this.txtKhuyenmai.TabIndex = 31;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExportExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportExcel.IconSize = 16;
            this.btnExportExcel.Location = new System.Drawing.Point(896, 14);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Rotation = 0D;
            this.btnExportExcel.Size = new System.Drawing.Size(267, 46);
            this.btnExportExcel.TabIndex = 34;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(896, 66);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 33;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1179, 506);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKhuyenmai);
            this.Controls.Add(this.LabelSearch);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.combodonvi);
            this.Controls.Add(this.comboloai);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btnButtonChooseIMG);
            this.Controls.Add(this.btnDeleteIMG);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtgiaban);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsl);
            this.Controls.Add(this.txttensp);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập kho";
            this.Load += new System.EventHandler(this.sanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtgiaban;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnDeleteIMG;
        private FontAwesome.Sharp.IconButton btnButtonChooseIMG;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ComboBox comboloai;
        private System.Windows.Forms.ComboBox combodonvi;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKhuyenmai;
        private FontAwesome.Sharp.IconButton btnExportExcel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
