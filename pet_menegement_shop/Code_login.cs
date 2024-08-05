using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace pet_menegement_shop
{
    class Code_login
    {
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\pet_menegement_shop\pet_menegement_shop\pet_shop.mdf;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        

        public void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        public void insert(String name, String eml, String ct, String add, String mbl,String pass)
        {
            cmd = new SqlCommand("insert into register(Name,Email,City,Address,Mobile,Password) values('" + name + "','" + eml + "','" + ct + "','" + add + "','" + mbl + "','"+pass+"')", con);
            cmd.ExecuteNonQuery();
        }

        public void selectlp(String nm , String pss)
        {
            da = new SqlDataAdapter("select count(*) from register where Name='" + nm + "'and Password='" + pss + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

    }

}
