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

namespace pet_menegement_shop
{
    public partial class client : Form
    {
        private int childFormNumber = 0;

        code cs;
        public client()
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

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;

        void fillgrid()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectcus();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void client_Load(object sender, EventArgs e)
        {
            cs = new code();
            cs.getcon();
            fillgrid();
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(255, 32, 65);
                }
            }

            label1.Text = " " + Login.name;
        }
        void filldata()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectidcus();
            txtcuid.Text = ds.Tables[0].Rows[0][1].ToString();
            txtnm.Text = ds.Tables[0].Rows[0][2].ToString();

            txtem.Text = ds.Tables[0].Rows[0][3].ToString();

            txtadd.Text = ds.Tables[0].Rows[0][4].ToString();
            txtmb.Text = ds.Tables[0].Rows[0][5].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs = new code();
            cs.getcon();
            fillgrid();
                cs.insertcus(txtcuid.Text, txtnm.Text, txtem.Text, txtadd.Text, txtmb.Text);
                fillgrid();
       
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.updatecus(txtcuid.Text,txtnm.Text, txtem.Text, txtadd.Text, txtmb.Text);
            fillgrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                Program.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                filldata();
            }
            else if (e.ColumnIndex == 0)
            {
                cs.getcon();
                Program.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                fillgrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.deletecus();
            fillgrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            pet pt = new pet();
            pt.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pet pt = new pet();
            pt.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            billing bl = new billing();
            bl.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            billing bl = new billing();
            bl.Show();
            this.Hide();
        }
    }
}
