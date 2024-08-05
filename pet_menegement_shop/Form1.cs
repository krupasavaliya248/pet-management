using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pet_menegement_shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startup = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startup += 4;
            prog.Value = startup;
            percen.Text = startup + "%";

            if(prog.Value == 100)
            {
                prog.Value = 0;
                Login log = new Login();
                log.Show();
                this.Hide();
                timer1.Stop();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
