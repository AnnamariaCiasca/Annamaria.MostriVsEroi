using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using Annamaria.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{

    public class AdoRepositoryArma : IRepositoryArmi
    {

        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = MostriVsEroi;" +
                                         "Integrated Security = true";
        public List<Arma> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Arma> FetchArmiPerCategoria(int categoriaScelta)
        {
            List<Arma> armi = new List<Arma>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Arma.Id, dbo.Arma.Nome, dbo.Arma.PuntiDanno FROM dbo.Arma WHERE dbo.Arma.IdCategoria = @categoriaScelta";
                command.Parameters.AddWithValue("@categoriaScelta", categoriaScelta);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Arma arma = new Arma();
                    arma.Id = (int)reader["Id"];
                    arma.Nome = (string)reader["Nome"];
                    arma.PuntiDanno = (int)reader["PuntiDanno"];


                    armi.Add(arma);

                }
                return armi;
            }
        }

        public Arma GetArmaByEroe(Eroe eroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Arma arma = new Arma();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Arma.Nome, dbo.Arma.Id AS Id, dbo.Arma.PuntiDanno, dbo.Eroe.Id AS EroeId FROM dbo.Arma JOIN dbo.Eroe ON dbo.Eroe.IdArma = dbo.Arma.Id WHERE dbo.Eroe.Id = @idEroe";
                command.Parameters.AddWithValue("@idEroe", eroe.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    arma.Id = (int)reader["Id"];
                    arma.Nome = (string)reader["Nome"];
                    arma.PuntiDanno = (int)reader["PuntiDanno"];
                    eroe.Id = (int)reader["EroeId"];
                }
                return arma;
            }

        }

        public Arma GetArmaByMostro(Mostro mostroScelto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Arma arma = new Arma();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Arma.Nome, dbo.Arma.Id AS Id, dbo.Arma.PuntiDanno, dbo.Mostro.Id AS MostroId FROM dbo.Arma JOIN dbo.Mostro ON dbo.Mostro.IdArma = dbo.Arma.Id WHERE dbo.Mostro.Id = @idMostro";
                command.Parameters.AddWithValue("@idMostro", mostroScelto.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    arma.Id = (int)reader["Id"];
                    arma.Nome = (string)reader["Nome"];
                    arma.PuntiDanno = (int)reader["PuntiDanno"];
                    mostroScelto.Id = (int)reader["MostroId"];
                }
                return arma;
            }
        }

        public Arma GetById(int armaScelta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Arma arma = new Arma();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Arma.Nome, dbo.Arma.PuntiDanno, dbo.Arma.IdCategoria FROM dbo.Arma WHERE dbo.Arma.Id = @armaScelta";
                command.Parameters.AddWithValue("@armaScelta", armaScelta);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    arma.Nome = (string)reader["Nome"];
                    arma.PuntiDanno = (int)reader["PuntiDanno"];
                    arma.IdCategoria = (int)reader["IdCategoria"];


                }
                return arma;
            }
        }
    }
}
