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
    public partial class Employee : Form
    {
        private int childFormNumber = 0;

        public Employee()
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
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
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
           // Application.Exit();
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            label1.Text = " " + Login.name;

            cs = new code();
            cs.getcon();
            fillgrid();
            //col();

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(255, 32, 65);
                }
            }
        }

        code cs;

        SqlCommand cmd;
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;

        void fillgrid()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectemp();
            dataGridView1.DataSource = ds.Tables[0];
        }
        void filldata()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectidemp();
            txtnm.Text = ds.Tables[0].Rows[0][1].ToString();

            txtem.Text = ds.Tables[0].Rows[0][2].ToString();
            cmbct.SelectedItem = ds.Tables[0].Rows[0][3].ToString();
            txtadd.Text = ds.Tables[0].Rows[0][4].ToString();
            txtmb.Text = ds.Tables[0].Rows[0][5].ToString();
            txtpas.Text = ds.Tables[0].Rows[0][6].ToString();
        }
        //void col()
        //{
        //    dataGridView1.AutoGenerateColumns = false;
        //    DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
        //    edit.FlatStyle = FlatStyle.Popup;
        //    edit.HeaderText = "Edit";
        //    edit.Name = "Edit";
        //    edit.UseColumnTextForButtonValue = true;
        //    edit.Text = "Edit";
        //    edit.Width = 60;
        //    dataGridView1.Columns.Add(edit);

        //    //Delete

        //    dataGridView1.AutoGenerateColumns = false;
        //    DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
        //    delete.FlatStyle = FlatStyle.Popup;
        //    delete.HeaderText = "Delete";
        //    delete.Name = "Delete";
        //    delete.UseColumnTextForButtonValue = true;
        //    delete.Text = "Delete";
        //    delete.Width = 60;
        //    dataGridView1.Columns.Add(delete);
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            cs.getcon();
           
            cs.insertemp(txtnm.Text, txtem.Text, cmbct.Text, txtadd.Text, txtmb.Text, txtpas.Text);
            fillgrid();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.updateemp(txtnm.Text, txtem.Text, cmbct.Text, txtadd.Text, txtmb.Text, txtpas.Text);
            fillgrid();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //fillgrid();
            //filldata();
            //Program.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cs = new code();
            cs.getcon();
            fillgrid();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs.getcon();
            cs.deleteemp();
            fillgrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtnm.Clear();
            txtem.Clear();
            cmbct.ResetText();
            txtadd.Clear();
            txtmb.Clear();
            txtpas.Clear();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

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


