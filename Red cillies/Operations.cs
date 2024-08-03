using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_cillies
{
    class Operations
    {
        protected OleDbConnection getCon()
        {
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RedCilliesDb.mdb";
            return Con;
        }
        
       public void insertdata(string query)
        {
            OleDbConnection Con = getCon();
            OleDbCommand Cmd = new OleDbCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product added Successfully");
            Con.Close();
        }

        public void Editdata(string query)
        {
            OleDbConnection Con = getCon();
            OleDbCommand Cmd = new OleDbCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product Updated Successfully");
            Con.Close();
        }

        public void deleteProduct(string query)
        {
            OleDbConnection Con = getCon();
            OleDbCommand Cmd = new OleDbCommand();
            Cmd.Connection = Con;
            Con.Open();
            Cmd.CommandText = query;
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Product Deleted Successfully");
            Con.Close();
        }
        public int count()
        {
            OleDbConnection Con = getCon();
            string query = "select *from ProductTbl order by ID";
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = query;

            OleDbDataReader rdr = cmd.ExecuteReader();
            int id = 0;
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
            }
            id = id + 1;
            Con.Close();
            return id;
        }

        //Method to display data in Datagridview1
        public DataSet populate(string query)
        {
            OleDbConnection Con = getCon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Con;
            cmd.CommandText = query;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
       
    }
}
