using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace pet_menegement_shop
{
    class code
    {
        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\pet_menegement_shop\pet_menegement_shop\pet_shop.mdf;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        //pet code

        public DataSet selectpet()
        {
            da = new SqlDataAdapter("select * from pet", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet selectidpet()
        {

            da = new SqlDataAdapter("select * from pet where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void insertpet(String name, String cat, int qua, String pri)
        {
            cmd = new SqlCommand("insert into pet(Name,Category,Quantity,Price) values('" + name + "','" + cat + "','" + qua + "','" + pri + "')", con);
            cmd.ExecuteNonQuery();
        }

        public void updatepet(string name, String cat, int qua, String pri)
        {
            cmd = new SqlCommand("update pet set Name='" + name + "', Category='" + cat + "' , Quantity='" + qua + "' , Price='" + pri + "' where Id='" + Program.id + "'", con);
            cmd.ExecuteNonQuery();

        }

        public void deletepet()
        {
            cmd = new SqlCommand("delete from pet where Id = '" + Program.id + "'", con);
            cmd.ExecuteNonQuery();
        }


        //Customer code

        public DataSet selectcus()
        {
            da = new SqlDataAdapter("select * from Customers", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



        public DataSet selectidcus()
        {

            da = new SqlDataAdapter("select * from Customers where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void insertcus(String cid, String name, String eml, String add, String mbl)
        {
            cmd = new SqlCommand("insert into Customers(Customer_id,Cu_name,Email,Address,Mobile) values('" + cid + "','" + name + "','" + eml + "','" + add + "','" + mbl + "')", con);
            cmd.ExecuteNonQuery();
        }

        public void updatecus(String cid, string name, string eml, string add, string mbl)
        {
            cmd = new SqlCommand("update Customers set Customer_id ='" + cid + "',Cu_name='" + name + "', Email='" + eml + "' , Address='" + add + "' , Mobile='" + mbl + "' where Id='" + Program.id + "'", con);
            cmd.ExecuteNonQuery();

        }

        public void deletecus()
        {
            cmd = new SqlCommand("delete from Customers where Id = '" + Program.id + "'", con);
            cmd.ExecuteNonQuery();
        }


        //employee code

        public DataSet selectemp()
        {
            da = new SqlDataAdapter("select * from register", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



        public DataSet selectidemp()
        {

            da = new SqlDataAdapter("select * from register where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void insertemp(String name, String eml, String ct, String add, String mbl, String pass)
        {
            cmd = new SqlCommand("insert into register(Name,Email,City,Address,Mobile,Password) values('" + name + "','" + eml + "','" + ct + "','" + add + "','" + mbl + "','" + pass + "')", con);
            cmd.ExecuteNonQuery();
        }

        public void updateemp(string name, string eml, string ct, string add, string mn, string pas)
        {
            cmd = new SqlCommand("update register set Name='" + name + "', Email='" + eml + "' , City='" + ct + "' , Address='" + add + "' , Mobile='" + mn + "' , Password='" + pas + "' where Id='" + Program.id + "'", con);
            cmd.ExecuteNonQuery();

        }

        public void deleteemp()
        {
            cmd = new SqlCommand("delete from register where Id = '" + Program.id + "'", con);
            cmd.ExecuteNonQuery();
        }


        //billing code

        //pet table
        public DataSet selectbipe()
        {
            da = new SqlDataAdapter("select * from pet", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet selectbipetid()
        {
            da = new SqlDataAdapter("select * from pet where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //customer table
        public DataSet selectbicus()
        {
            da = new SqlDataAdapter("select * from Customers", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet selectbiidcus()
        {
            da = new SqlDataAdapter("select * from Customers where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        //billing main fatch code


        //sell gridview code
        public DataSet selectbisel()
        {
            da = new SqlDataAdapter("select * from Sell_pro", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet selectbiidsel()
        {
            da = new SqlDataAdapter("select * from Sell_pro where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void insertsell(String name, int pri, int qua, int tot)
        {
            tot = pri * qua;
            cmd = new SqlCommand("insert into sell_pro(Name,Price,Quantity,Total) values('" + name + "','" + pri + "','" + qua + "','" + tot + "')", con);
            cmd.ExecuteNonQuery();
        }

        //transaction code

        public DataSet selectbitan()
        {
            da = new SqlDataAdapter("select * from Bill", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet selectbiidtan()
        {
            da = new SqlDataAdapter("select * from Bill where Id = '" + Program.id + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void insertbil(String id, String cnm, String name, int pri, int qua, int tot)
        {
            tot = pri * qua;
            cmd = new SqlCommand("insert into Bill(Cu_id,Cu_Name,Name,Price,Quantity,Total) values('" + id + "','" + cnm + "','" + name + "','" + pri + "','" + qua + "','" + tot + "')", con);
            cmd.ExecuteNonQuery();
        }

        //update code

        
    }
}
