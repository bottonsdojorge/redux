using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
	public class DALEnderecoUsuario : DAL
	{
		public DALEnderecoUsuario() : base() {}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public List<Modelo.EnderecoUsuario> SelectAll()
		{
			Modelo.EnderecoUsuario enderecoUsuario;
			List<Modelo.EnderecoUsuario> enderecosUsuario = new List<Modelo.EnderecoUsuario>();
			try 
			{
				using (conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sqlEnderecosUsuario = "SELECT * FROM  EnderecoUsuario";
					SqlCommand cmdEnderecosUsuario = new SqlCommand(sqlEnderecosUsuario, conn);
					SqlDataReader drEnderecosUsuario;

					using (drEnderecosUsuario = cmdEnderecosUsuario.ExecuteReader())
					{
						if (drEnderecosUsuario.HasRows)
						{
							while (drEnderecosUsuario.Read())
							{
								int idLocalEntrega = (int)drEnderecosUsuario["localEntrega_id"];
								int idUsuario = (int)drEnderecosUsuario["Usuario_id"];

								DALLocalEntrega dalLocalEntrega = new DALLocalEntrega();
								Modelo.localEntrega localEntrega = dalLocalEntrega.Select(idLocalEntrega);

								enderecoUsuario = new Modelo.EnderecoUsuario(localEntrega, idUsuario);
								enderecosUsuario.Add(enderecoUsuario);
							}
						}
					}
				}
			}
			catch (Exception)
			{
		
				throw;
			}

			return enderecosUsuario;
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public Modelo.EnderecoUsuario Select(int idLocalEntrega, int idUsuario)
		{
			Modelo.EnderecoUsuario enderecoUsuario = null;
			try
			{
				using (conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sqlEnderecoUsuario = "SELECT * FROM  EnderecoUsuario WHERE localEntrega_id = @idLocalEntrega AND Usuario_id = @idUsuario";
					SqlCommand cmdEnderecoUsuario = new SqlCommand(sqlEnderecoUsuario, conn);
					cmdEnderecoUsuario.Parameters.Add("@idLocalEntrega", SqlDbType.Int).Value = idLocalEntrega;
					cmdEnderecoUsuario.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					SqlDataReader drEnderecoUsuario;

					using (drEnderecoUsuario = cmdEnderecoUsuario.ExecuteReader())
					{
						if (drEnderecoUsuario.HasRows)
						{
							while (drEnderecoUsuario.Read())
							{	DALLocalEntrega dalLocalEntrega = new DALLocalEntrega();
								Modelo.localEntrega localEntrega = dalLocalEntrega.Select(idLocalEntrega);

								enderecoUsuario = new Modelo.EnderecoUsuario(localEntrega, idUsuario);
							}
						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}

			return enderecoUsuario;
		}

		[DataObjectMethod(DataObjectMethodType.Select)]
		public List<Modelo.EnderecoUsuario> SelectFromUsuario(int idUsuario)
		{
			Modelo.EnderecoUsuario enderecoUsuario;
			List<Modelo.EnderecoUsuario> enderecosUsuario = new List<Modelo.EnderecoUsuario>();
			try
			{
				using (conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sqlEnderecosUsuario = "SELECT * FROM  EnderecoUsuario WHERE Usuario_id = @idUsuario";
					SqlCommand cmdEnderecosUsuario = new SqlCommand(sqlEnderecosUsuario, conn);
					cmdEnderecosUsuario.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
					SqlDataReader drEnderecosUsuario;

					using (drEnderecosUsuario = cmdEnderecosUsuario.ExecuteReader())
					{
						if (drEnderecosUsuario.HasRows)
						{
							while (drEnderecosUsuario.Read())
							{
								int idLocalEntrega = (int)drEnderecosUsuario["localEntrega_id"];

								DALLocalEntrega dalLocalEntrega = new DALLocalEntrega();
								Modelo.localEntrega localEntrega = dalLocalEntrega.Select(idLocalEntrega);

								enderecoUsuario = new Modelo.EnderecoUsuario(localEntrega, idUsuario);
								enderecosUsuario.Add(enderecoUsuario);
							}
						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}

			return enderecosUsuario;
		}
	}
}