using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_2
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            panel1.Width += 20;
            if (panel1.Width >= this.Width)
            {
                timer1.Stop();
                this.Hide();
                
                f1.ShowDialog();
                
            }
            
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
