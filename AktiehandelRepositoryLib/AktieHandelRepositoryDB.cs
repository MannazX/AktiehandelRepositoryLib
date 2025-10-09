using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AktiehandelRepositoryLib
{
	public class AktieHandelRepositoryDB : IAktieHandelRepository
	{
		private string connectionString = Secret.ConnectionString;
		private string selectSql = "Select * From Aktiehandel";
		private string insertSql = "Insert Into Aktiehandel (HandelsId, Navn, Antal, Handelspris) Values (@HandelsId, @Navn, @Antal, @Handelspris)";
		private string deleteSql = "Delete from Aktiehandel Where HandelsId = @HandelsId";
		private string updateSql = "Update Aktiehandel Set Navn = @Navn, Antal = @Antal, Handelspris = @Handelspris Where HandelsId = @HandelsId";

		public AktieHandelRepositoryDB()
		{
			
		}

		public AktieHandel Add(AktieHandel ah)
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
						if (rowsAffected == 0)
						{
							Console.WriteLine("Item was not added");
						}
						else
						{
							Console.WriteLine("Item was added");
						}
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return ah;
		}

		public AktieHandel Delete(int id)
		{
			AktieHandel handel = GetById(id);
			if (handel == null)
			{
				Console.WriteLine("Item was not found");
			}
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					SqlCommand command = new SqlCommand(deleteSql, connection);
					command.Parameters.AddWithValue("@HandelsId", id);
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					if (rowsAffected == 0)
					{
						Console.WriteLine("Item did not Delete");
					}
					else
					{
						Console.WriteLine("Item was deleted");
					}
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handel;
		}

		public IEnumerable<AktieHandel> GetByAntal(int? antal = null)
		{
			IEnumerable<AktieHandel> handelList = null;
			if (antal != null)
			{
				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						connection.Open();
						using (SqlCommand command = new SqlCommand(selectSql + " Where Antal > @Antal", connection))
						{
							command.Parameters.AddWithValue("@Antal", antal);
							using (SqlDataReader reader = command.ExecuteReader())
							{
								List<AktieHandel> dataList = new List<AktieHandel>();
								while (reader.Read())
								{
									string dataNavn = reader.GetString(1);
									int dataAntal = reader.GetInt32(2);
									double dataHandelspris = reader.GetDouble(3);
									dataList.Add(new AktieHandel(dataNavn, dataAntal, dataHandelspris));
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
			}
			else
			{
				handelList = GetAll();
			}
			return handelList;
		}

		public IEnumerable<AktieHandel> GetOrderBy(string? orderBy)
		{
			IEnumerable<AktieHandel> handelList = null;
			if (orderBy != null)
			{
				if (orderBy == "Navn" || orderBy == "Handelspris")
				{
					try
					{
						using (SqlConnection connection = new SqlConnection(connectionString))
						{
							connection.Open();
							using (SqlCommand command = new SqlCommand(selectSql + " Order By " + orderBy + " Asc", connection))
							{
								using (SqlDataReader reader = command.ExecuteReader())
								{
									List<AktieHandel> itemList = new List<AktieHandel>();
									while (reader.Read())
									{
										string navn = reader.GetString(1);
										int antal = reader.GetInt32(2);
										double handelspris = reader.GetDouble(3);
										itemList.Add(new AktieHandel(navn, antal, handelspris));
									}
									reader.Close();
									handelList = itemList;
								}
							}
						}
					}
					catch (SqlException sqlEx)
					{
						Console.WriteLine(sqlEx.Message);
					}
				}
				else
				{
					Console.WriteLine("The order criteria is not valid - whole list returned");
					handelList = GetAll();
				}
			}
			else
			{
				handelList = GetAll();
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
								handelList.Add(new AktieHandel(navn, antal, handelspris));
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
					connection.Open();
					using (SqlCommand command = new SqlCommand(selectSql + " Where HandelsId = @HandelsId", connection))
					{
						command.Parameters.AddWithValue("@HandelsId", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
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
				}
			}
			catch (SqlException sqlEx)
			{
				Console.WriteLine(sqlEx.Message);
			}
			return handel;
		}

		public AktieHandel Update(int id, AktieHandel data)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(updateSql, connection))
					{
						command.Parameters.AddWithValue("@Navn", data.Navn);
						command.Parameters.AddWithValue("@Antal", data.Antal);
						command.Parameters.AddWithValue("@Handelspris", data.HandelsPris);
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
			return data;
		}
	}
}
