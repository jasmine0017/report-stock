
using ReportStock.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ReportStock.Services
{
	public class UserService
	{
		public List<UserModel> GetUsers(IConfiguration configuration)
		{
			string storeProcedureName = "SP_USERS_GET";
			List<UserModel> listUsers = new List<UserModel>();
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DBCS")))
				{
					SqlCommand sqlCommand = new SqlCommand(storeProcedureName, sqlConnection);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables.Count > 0)
					{

						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							UserModel user = new UserModel();
							user.id = Convert.ToInt64(dataSet.Tables[0].Rows[i]["Seq"]);
							user.username = Convert.ToString(dataSet.Tables[0].Rows[i]["Username"]);
							user.password = Convert.ToString(dataSet.Tables[0].Rows[i]["Password"]);
							user.name = Convert.ToString(dataSet.Tables[0].Rows[i]["Name"]);
							user.department = Convert.ToString(dataSet.Tables[0].Rows[i]["Department"]);
							user.status = Convert.ToString(dataSet.Tables[0].Rows[i]["Status"]);
							user.createdate = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["CreatedDate"]);
							listUsers.Add(user);
						}

					}
				}
			}
			catch (Exception)
			{
				throw;
			}

			return listUsers;
		}


		public List<UserModel> GetUserById(IConfiguration configuration, Int64 idUser)
		{
			string storeProcedureName = "SP_USER_GET_BY_ID";
			List<UserModel> listUsers = new List<UserModel>();
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
				{
					SqlCommand sqlCommand = new SqlCommand(storeProcedureName, sqlConnection);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@Seq", idUser);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables.Count > 0)
					{
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							UserModel user = new UserModel();
							user.id = Convert.ToInt64(dataSet.Tables[0].Rows[i]["Seq"]);
							user.username = Convert.ToString(dataSet.Tables[0].Rows[i]["Username"]);
							user.password = Convert.ToString(dataSet.Tables[0].Rows[i]["Password"]);
							user.name = Convert.ToString(dataSet.Tables[0].Rows[i]["Name"]);
							user.department = Convert.ToString(dataSet.Tables[0].Rows[i]["Department"]);
							user.status = Convert.ToString(dataSet.Tables[0].Rows[i]["Status"]);
							user.createdate = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["CreatedDate"]);
							listUsers.Add(user);
						}

					}
				}
			}
			catch (Exception)
			{
				throw;
			}

			return listUsers;
		}

		public DataSet UpdateUser(IConfiguration configuration, UserModel user)
		{
			DataSet dataSet;
			string storeProcedureName = "SP_USER_UPDATE";
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
				{
					SqlCommand sqlCommand = new SqlCommand(storeProcedureName, sqlConnection);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@Seq", user.id);
					sqlCommand.Parameters.AddWithValue("@Username", user.username);
					sqlCommand.Parameters.AddWithValue("@Password", user.password);
					sqlCommand.Parameters.AddWithValue("@Department", user.department);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);


				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dataSet;
		}

		public DataSet DeleteUser(IConfiguration configuration, Int64 idUser)
		{
			DataSet dataSet;
			string storeProcedureName = "SP_USER_DELETE";
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
				{
					SqlCommand sqlCommand = new SqlCommand(storeProcedureName, sqlConnection);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@Seq", idUser);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return dataSet;
		}
	}
}
