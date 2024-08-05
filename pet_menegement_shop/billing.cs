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
    
    public partial class billing : Form
    {
        code cs;
        private int childFormNumber = 0;

        public billing()
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

        private void billing_Load(object sender, EventArgs e)
        {
            cs = new code();
            cs.getcon();
            fillgrid();
            fillgridcus();
            fillgridsell();
            fillgridbil();
            //col();
            label1.Text = " " + Login.name;

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.FromArgb(255, 32, 65);
                }
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
            ds = cs.selectbipe();
            dataGridView1.DataSource = ds.Tables[0];
        }
        void filldata()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbipetid();
            txtnm.Text = ds.Tables[0].Rows[0][1].ToString();
            txtpri.Text = ds.Tables[0].Rows[0][4].ToString();
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
                cs = new code();
                cs.getcon();
                Program.id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                fillgrid();
            }

        }

        int stock;
        void up()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbipetid();
            stock = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
        }

        String c = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\pet_menegement_shop\pet_menegement_shop\pet_shop.mdf;Integrated Security=True";
        SqlConnection co;
        SqlDataAdapter daa;
        SqlCommand cmds;
        DataSet dsd;

        public void getcon()
        {
            co = new SqlConnection(c);
            co.Open();
        }

        void update()
        {   
          try
            {
                int newstock = Convert.ToInt16(stock) - Convert.ToInt16(txtqua.Text) ;
                getcon();
                cmds = new SqlCommand("update pet  set Quantity='" + newstock + "' where Id='" + Program.id + "'", co);
                cmds.ExecuteNonQuery();
                fillgrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        //customer code

        void fillgridcus()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbicus();
            cusdatagridview.DataSource = ds.Tables[0];
        }

        void filldatacus()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbiidcus();
            txtid.Text = ds.Tables[0].Rows[0][1].ToString();
            txtcn.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void cusdatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cs = new code();
            cs.getcon();
            if (e.ColumnIndex == 0)
            {

                Program.id = Convert.ToInt16(cusdatagridview.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                filldatacus();
            }
            else if (e.ColumnIndex == 0)
            {
                cs = new code();
                cs.getcon();
                Program.id = Convert.ToInt16(cusdatagridview.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                fillgridcus();
            }


        }

        // fatch code
        private void label16_Click(object sender, EventArgs e)
        {

        }

        void fillgridsell()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbisel();
            dataGridView2.DataSource = ds.Tables[0];
        }

        void filldatasell()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbiidsel();
            txtnm.Text = ds.Tables[0].Rows[0][1].ToString();
            txtpri.Text = ds.Tables[0].Rows[0][2].ToString();
            txtqua.Text = ds.Tables[0].Rows[0][4].ToString();
            tot = Convert.ToInt32(txtpri.Text) * Convert.ToInt32(txtqua.Text);

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            cs = new code();
            cs.getcon();
            up();
            if (txtqua.Text == "" || Convert.ToInt16(txtqua.Text) > Convert.ToInt16(stock))
            {
                MessageBox.Show("No Stock");
            }
            else
            {
                cs = new code();
                cs.getcon();
                fillgridsell();
                cs.insertsell(txtnm.Text, Convert.ToInt16(txtpri.Text), Convert.ToInt16(txtqua.Text), tot);
                Totallab.Text = " " + tot;
                total();
                update();
            }
            fillgridsell();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cs = new code();
            cs.getcon();
          
            if (e.ColumnIndex == 0)
            {

                Program.id = Convert.ToInt16(dataGridView2.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                filldatasell();
                fillgridsell();
            }
            


        }

        int tot=0;
        void total()
        {
            tot = Convert.ToInt32(txtpri.Text) * Convert.ToInt32(txtqua.Text);
        }

        //trangection code

        void fillgridbil()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbitan();
            dataGridView3.DataSource = ds.Tables[0];
        }
       

        void filldatabil()
        {
            cs = new code();
            cs.getcon();
            ds = new DataSet();
            ds = cs.selectbiidtan();
            txtid.Text = ds.Tables[0].Rows[0][1].ToString();
            txtcn.Text = ds.Tables[0].Rows[0][2].ToString();
            txtnm.Text = ds.Tables[0].Rows[0][3].ToString();
            txtpri.Text =ds.Tables[0].Rows[0][4].ToString();
            txtqua.Text =ds.Tables[0].Rows[0][5].ToString();
            tot = Convert.ToInt32(txtpri.Text) * Convert.ToInt32(txtqua.Text);

        }

        private void Totallab_Click(object sender, EventArgs e)
        {
            total();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs = new code();
            cs.getcon();
          
            cs.insertbil(txtid.Text,txtcn.Text,txtnm.Text, Convert.ToInt16(txtpri.Text), Convert.ToInt16(txtqua.Text), tot);
            total();
            fillgridbil();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            cs = new code();
            cs.getcon();
            fillgridbil();
            if (e.ColumnIndex == 0)
            {

                Program.id = Convert.ToInt16(dataGridView3.Rows[e.RowIndex].Cells["Id"].FormattedValue);
                filldatabil();
                fillgridbil();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtnm.Clear();
            txtid.Clear();
            txtcn.Clear();
            txtpri.Clear();
            txtqua.Clear();

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

        private void label4_Click(object sender, EventArgs e)
        {
            client cl = new client();
            cl.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            client cl = new client();
            cl.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
