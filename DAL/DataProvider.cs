using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DataProvider
	{
		private static DataProvider instance;

		private string connectionStr = @"Data Source=ADMINISTRATOR;Initial Catalog=QuanLyRapPhim;Integrated Security=True";

		public static DataProvider Instance
		{
			get
			{
				if (instance == null)
					instance = new DataProvider();
				return instance;
			}
		}

		DataProvider() { }

		public DataTable ExecuteQuerry(string commandStr, object[] parameter = null)
		{
			DataTable dataTable = new DataTable();

			using (SqlConnection connection = new SqlConnection(connectionStr)) //connection sẽ dc giải phóng kể cả khi bên trong bị lỗi
			{
				connection.Open();

				SqlCommand command = new SqlCommand(commandStr, connection);

				if (parameter != null)
				{
					commandStr = commandStr.Replace(',', ' ');
					string[] listPara = commandStr.Split(' ');

					int i = 0;
					foreach (string item in listPara)
					{
						if (item.Contains('@'))
						{
							command.Parameters.AddWithValue(item, parameter[i]); //Tìm ra những cụm @... trong lệnh và thêm parameter[i] tương ứng vào sau
							i++;
						}
					}
				}

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				adapter.Fill(dataTable);

				connection.Close();
			}

			return dataTable;
		}
	}
}