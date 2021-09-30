using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.AdoRepository
{
  public class AdoRepositoryEroe : IRepositoryEroi
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = MostriVsEroi;" +
                                         "Integrated Security = true";

        public Eroe AddEroe(Eroe eroe, int categoriaScelta, int armaScelta, Giocatore giocatore)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Eroe values (@Nome, @IdCategoria, @IdArma, @Livello, @PuntiVita, @PuntiAccumulati, @IdGiocatore)";
                command.Parameters.AddWithValue("@Nome", eroe.Nome);
                command.Parameters.AddWithValue("@IdCategoria", categoriaScelta);
                command.Parameters.AddWithValue("@IdArma", armaScelta);
                command.Parameters.AddWithValue("@Livello", eroe.Livello);
                command.Parameters.AddWithValue("@PuntiVita", eroe.PuntiVita);
                command.Parameters.AddWithValue("@PuntiAccumulati", eroe.PuntiAccumulati);
                command.Parameters.AddWithValue("@IdGiocatore", giocatore.Id);

                SqlDataReader reader = command.ExecuteReader();
                return eroe;
            }
        }

        public void Elimina(Eroe eroeDaCancellare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE from dbo.Eroe where Id = @id";
                command.Parameters.AddWithValue("@id", eroeDaCancellare.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Eroe> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Eroe> FetchByGiocatore(int idGiocatore)
        {
            List<Eroe> eroi = new List<Eroe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "" +
                    " SELECT dbo.Eroe.Id, dbo.Eroe.Nome, dbo.Categoria.Nome, dbo.Arma.Nome, dbo.Eroe.Livello, dbo.Eroe.PuntiVita, dbo.Eroe.PuntiAccumulati " +
                    " FROM dbo.Eroe  " +
                    " JOIN dbo.Categoria ON dbo.Categoria.Id = dbo.Eroe.IdCategoria" +
                    " JOIN dbo.Arma ON dbo.Arma.Id = dbo.Eroe.IdArma" +
                    " WHERE dbo.Eroe.IdGiocatore = @idGiocatore";
                command.Parameters.AddWithValue("@idGiocatore", idGiocatore);

                SqlDataReader reader = command.ExecuteReader();

           

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    Giocatore giocatore = new Giocatore();
                    Arma arma = new Arma();
                    Eroe eroe = new Eroe();

                    eroe.Id = (int)reader["Id"];
                    eroe.Nome = (string)reader["Nome"];
                    categoria.Id = (int)reader["IdCategoria"];
                    arma.Id = (int)reader["IdArma"];
                    eroe.Livello = (int)reader["Livello"];
                    eroe.PuntiVita = (int)reader["PuntiVita"];
                    eroe.PuntiAccumulati = (int)reader["PuntiAccumulati"];

                    eroi.Add(eroe);

                }
                return eroi;
            }
        }

        public List<Eroe> FetchPerPunti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =  "" +
                    "SELECT TOP(10) dbo.Eroe.Nome, dbo.Eroe.Livello, dbo.Eroe.PuntiAccumulati, dbo.Eroe.IdGiocatore" +
                    " FROM dbo.Eroe " +
                    " ORDER BY dbo.Eroe.Livello DESC, dbo.Eroe.PuntiAccumulati DESC";
                  
                SqlDataReader reader = command.ExecuteReader();

                List<Eroe> eroi = new List<Eroe>();


                while (reader.Read())
                {
                    Eroe eroe = new Eroe();
                    
                    eroe.Nome = (string)reader["Nome"];
                    eroe.Livello = (int)reader["Livello"];
                    eroe.PuntiAccumulati = (int)reader["PuntiAccumulati"];
                    eroe.IdGiocatore = (int)reader["IdGiocatore"];
                    eroi.Add(eroe);

                }
                return eroi;
            }
        }

        public Eroe GetById(int scelta)
        {
            Eroe eroe = new Eroe();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.Eroe WHERE dbo.Eroe.Id = @scelta";
                command.Parameters.AddWithValue("@scelta", scelta);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    Giocatore giocatore = new Giocatore();
                    Arma arma = new Arma();

                    eroe.Nome = (string)reader["Nome"];
                    categoria.Id = (int)reader["IdCategoria"];
                    arma.Id = (int)reader["IdArma"];
                    eroe.Livello = (int)reader["Livello"];
                    eroe.PuntiVita = (int)reader["PuntiVita"];
                    eroe.PuntiAccumulati = (int)reader["PuntiAccumulati"];
                    giocatore.Id = (int)reader["IdGiocatore"];
                }
                return eroe;
            }

        }
    }
}
