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
            throw new NotImplementedException();
        }

        public List<Eroe> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Eroe> FetchByGiocatore(int idGiocatore)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "" +
                    "SELECT dbo.Eroe.Nome as NomeEroe, dbo.Categoria.Nome as Categoria, dbo.Arma.Nome as Arma, dbo.Eroe.Livello, dbo.Eroe.PuntiVita " +
                    "FROM dbo.Eroe  " +
                    "JOIN dbo.Categoria ON dbo.Categoria.Id = dbo.Eroe.IdCategoria" +
                    "JOIN dbo.Arma ON dbo.Arma.Id = dbo.Eroe.IdArma" +
                    "WHERE dbo.Eroe.IdGiocatore = @idGiocatore";

                SqlDataReader reader = command.ExecuteReader();

                List<Eroe> eroi = new List<Eroe>();


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
                    giocatore.Id = (int)reader["IdGiocatore"];




                    eroi.Add(eroe);

                }
                return eroi;
            }
        }

        public List<Eroe> FetchPerPunti()
        {
            throw new NotImplementedException();
        }

        public Eroe GetById(int scelta)
        {
            throw new NotImplementedException();
        }
    }
}
