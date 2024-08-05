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
using System.Data;

namespace pet_menegement_shop
{
    
    public partial class Registration : Form
    {
        private int childFormNumber = 0;

        public Registration()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

       
       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        Code_login cl;



        private void Registration_Load(object sender, EventArgs e)
        {

            foreach (Control ctl in this.Controls)
            {
                if(ctl is MdiClient)
                {
                    ctl.BackColor = Color.White;
                }
            }

            cl = new Code_login();
            cl.getcon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cl = new Code_login();
            cl.getcon();
            cl.insert(txtnm.Text, txtem.Text, cmbct.Text, txtad.Text, txtmb.Text, txtpss.Text);

            MessageBox.Show("inserted");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtnm.Clear();
            txtem.Clear();
            cmbct.ResetText();
            txtad.Clear();
            txtmb.Clear();
            txtpss.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Login ln = new Login();
            ln.Show();
            this.Hide();

        }
    }
}
