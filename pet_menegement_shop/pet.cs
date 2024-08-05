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
    public partial class pet : Form
    {
        private int childFormNumber = 0;

        public pet()
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
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void label9_Click(object sender, EventArgs e)
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
            Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        code cs;
        void fillgrid()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectpet();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void pet_Load(object sender, EventArgs e)
        {
            label1.Text = " " + Login.name;
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
        }

        void filldata()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectidpet();
            txtnm.Text = ds.Tables[0].Rows[0][1].ToString();

            cmbcat.Text = ds.Tables[0].Rows[0][2].ToString();

            txtqu.Text = ds.Tables[0].Rows[0][3].ToString();
            txtpri.Text = ds.Tables[0].Rows[0][4].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.getcon();
           
            cs.insertpet(txtnm.Text, cmbcat.Text,Convert.ToInt16( txtqu.Text), txtpri.Text);
            fillgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.updatepet(txtnm.Text, cmbcat.Text, Convert.ToInt16(txtqu.Text), txtpri.Text);
            fillgrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.deletepet();
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

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            client cl = new client();
            cl.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            client cl = new client();
            cl.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
