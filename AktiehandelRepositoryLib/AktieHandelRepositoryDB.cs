using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AktiehandelRepositoryLib
{
	public class AktieHandelRepositoryDB : IAktieHandelRepository
	{
		private string connectionString = Secret.ConnectionString;
		private string selectSql = "Select HandelsId, Navn, Antal, Handelspris From Aktiehandel";
		private string insertSql = "Insert Into Aktiehandel (HandelsId, Navn, Antal, Handelspris) Values (@HandelsId, @Navn, @Antal, @Handelspris)";
		private string deleteSql = "Delete from Aktiehandel Where HandelsId = @HandelsId";
		private string updateSql = "Update Aktiehandel Set Navn = @Navn, Antal = @Antal, Handelspris = @Handelspris Where HandelsId = @HandelsId";

		public void Add(AktieHandel ah)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(insertSql, connection))
					{
						command.Parameters.AddWithValue("@HandelsId", ah.HandelsId);
						command.Parameters.AddWithValue("@Navn", ah.Navn);
						command.Parameters.AddWithValue("@Antal", ah.Antal);
						command.Parameters.AddWithValue("@Handelspris", ah.HandelsPris);
						int rowsAffected = command.ExecuteNonQuery();
						if (!(rowsAffected > 0))
						{
							throw new Exception("No rows were affected");
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
		}

		public void Delete(int id)
		{
			AktieHandel handel = GetById(id);
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(deleteSql, connection))
					{
						command.Parameters.AddWithValue("@HandelsId", id);
						int rowsAffected = command.ExecuteNonQuery();
						if (!(rowsAffected > 0))
						{
							throw new Exception("No rows affected");
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
		}

		public IEnumerable<AktieHandel> GetByAntal(int? antal = null)
		{
			IEnumerable<AktieHandel> handelList = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(selectSql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							List<AktieHandel> dataList = new List<AktieHandel>();
							while (reader.Read())
							{
								string dataNavn = reader.GetString(1);
								int dataAntal = reader.GetInt32(2);
								double dataHandelspris = reader.GetDouble(3);
								AktieHandel handelObject = new AktieHandel(dataNavn, dataAntal, dataHandelspris);
								dataList.Add(handelObject);
							}
							reader.Close();
							handelList = dataList;
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handelList;
		}

		public IEnumerable<AktieHandel> GetOrderBy(string? orderBy)
		{
			IEnumerable<AktieHandel> handelList = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(selectSql + " Order By @OrderBy Asc"))
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handelList;
		}

		public List<AktieHandel> GetAll()
		{
			List<AktieHandel> handelList = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(selectSql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							handelList = new List<AktieHandel>();
							while (reader.Read())
							{
								string navn = reader.GetString(1);
								int antal = reader.GetInt32(2);
								double handelspris = reader.GetDouble(3);
								AktieHandel handelObject = new AktieHandel(navn, antal, handelspris);
								handelList.Add(handelObject);
							}
							reader.Close();
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handelList;
		}

		public AktieHandel GetById(int id)
		{
			AktieHandel handel = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					AktieHandel? aktieHandel = null;
					SqlCommand command = new SqlCommand(selectSql + " Where HandelsId = @HandelsId");
					command.Connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						string navn = reader.GetString(1);
						int antal = reader.GetInt32(2);
						double handelspris = reader.GetDouble(3);
						handel = new AktieHandel(navn, antal, handelspris);
					}
					reader.Close();
					return handel;
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handel;
		}

		public void Update(int id, AktieHandel data)
		{
			throw new NotImplementedException();
		}
	}
}
