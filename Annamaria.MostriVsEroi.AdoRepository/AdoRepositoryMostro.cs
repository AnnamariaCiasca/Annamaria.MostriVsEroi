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
    public class AdoRepositoryMostro : IRepositoryMostri
    {

        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = MostriVsEroi;" +
                                         "Integrated Security = true";
        public Mostro AddMostro(Mostro mostro, int categoriaScelta, int armaScelta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Mostro values (@Nome, @IdCategoria, @IdArma, @Livello, @PuntiVita)";
                command.Parameters.AddWithValue("@Nome", mostro.Nome);
                command.Parameters.AddWithValue("@IdCategoria", categoriaScelta);
                command.Parameters.AddWithValue("@IdArma", armaScelta);
                command.Parameters.AddWithValue("@Livello", mostro.Livello);
                command.Parameters.AddWithValue("@PuntiVita", mostro.PuntiVita);
  

                SqlDataReader reader = command.ExecuteReader();
                return mostro;
            }
        }

        public List<Mostro> Fetch()
        {

            List<Mostro> mostri = new List<Mostro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.Mostro";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    Arma arma = new Arma();
                    Mostro mostro = new Mostro();

                    mostro.Id = (int)reader["Id"];
                    mostro.Nome = (string)reader["Nome"];
                    categoria.Id = (int)reader["IdCategoria"];
                    arma.Id = (int)reader["IdArma"];
                    mostro.Livello = (int)reader["Livello"];
                    mostro.PuntiVita = (int)reader["PuntiVita"];
                   

                    mostri.Add(mostro);

                }
                return mostri;
            }
        }

        public List<Mostro> GetByLivello(int livello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Mostro> mostri = new List<Mostro>();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.Mostro WHERE dbo.Mostro.Livello <= @livello";
                command.Parameters.AddWithValue("@livello", livello);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    Arma arma = new Arma();
                    Mostro mostro = new Mostro();

                    mostro.Id = (int)reader["Id"];
                    mostro.Nome = (string)reader["Nome"];
                    categoria.Id = (int)reader["IdCategoria"];
                    arma.Id = (int)reader["IdArma"];
                    mostro.Livello = (int)reader["Livello"];
                    mostro.PuntiVita = (int)reader["PuntiVita"];


                    mostri.Add(mostro);
                }
                return mostri;
            }

        }
    }
}
