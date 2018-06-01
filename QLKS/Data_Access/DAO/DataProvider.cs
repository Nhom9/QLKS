using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access.DAO
{
    public class DataProvider
    {
        private string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLKS_2;Integrated Security=True";

        private static DataProvider instance;

        
        internal static DataProvider Instance
        {
            get {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }

        
        private DataProvider() { }

        public DataTable ExcuteQuery(string query,object [] Parameter = null)
        {
            DataTable data= new DataTable();
            using(SqlConnection connection =new SqlConnection(connectionSTR))
            {
                connection.Open();
                
                SqlCommand cmd = new SqlCommand(query,connection);

                //cmd.Parameters.AddWithValue(@"IdName", id);

                if (Parameter != null)
                {
                    
                    string[] listParamete = query.Split(' ');

                    //for (int i = 0; i < Parameter.Length; i++)
                    //{
                        int i = 0; 
                        foreach (string item in listParamete)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, Parameter[i]);
                                i++;
                            }
                        }
                    
                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                adapter.Fill(data);
                
                connection.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query, object[] Parameter = null)
        {
            int data = 0;
            //DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                //cmd.Parameters.AddWithValue(@"IdName", id);   

                if (Parameter != null)
                {

                    string[] listParamete = query.Split(' ');

                    int i = 0;
                    foreach (string item in listParamete)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, Parameter[i]);
                            i++;
                        }
                    }

                }

                data = cmd.ExecuteNonQuery();
                
                connection.Close();
            }
            return data;
        }
        public Object ExcuteScalar(string query, object[] Parameter = null)
        {
            Object data = 0;
            //DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                //cmd.Parameters.AddWithValue(@"IdName", id);

                if (Parameter != null)
                {

                    string[] listParamete = query.Split(' ');

                    int i = 0;
                    foreach (string item in listParamete)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, Parameter[i]);
                            i++;
                        }
                    }

                }

                data = cmd.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}
