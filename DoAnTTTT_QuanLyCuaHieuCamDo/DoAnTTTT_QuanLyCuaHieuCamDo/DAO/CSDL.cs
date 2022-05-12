using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DoAnTTTT_QuanLyCuaHieuCamDo.DAO
{
    class CSDL
    {
        private static CSDL instance;

        public static CSDL Instance
        {
            get { if (instance == null) instance = new CSDL(); return CSDL.instance; }
            private set { CSDL.instance = value; }
        }
        private CSDL()
        {
        }
        public static string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCamDo;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter Adapter = new SqlDataAdapter(command);
                Adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// dùng để insert update delete trả ra số dòng thành công
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        ///Trả ra số lượng Example: select count()
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
        public object chaysql(string query)
        {
            string kqua;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader data = command.ExecuteReader();
                StringBuilder kq = new StringBuilder();
                while (data.Read())
                {
                    for (int i = 0; i < data.FieldCount; i++)
                        kq.Append(data[i].ToString());
                    kq.AppendLine();
                }
                kqua = kq.ToString();
                connection.Close();
            }
            return kqua;
        }
    }
}
