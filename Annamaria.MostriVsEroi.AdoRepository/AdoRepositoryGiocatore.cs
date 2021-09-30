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
    public class AdoRepositoryGiocatore : IRepositoryGiocatori
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = MostriVsEroi;" +
                                      "Integrated Security = true";

        public Giocatore AddGiocatore(Giocatore giocatore)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Giocatore values (@Nome, @Password, @IsAuthenticated, @IsAdmin)";
                command.Parameters.AddWithValue("@Nome", giocatore.Nome);
                command.Parameters.AddWithValue("@Password", giocatore.Password);
                command.Parameters.AddWithValue("@IsAuthenticated", true);
                command.Parameters.AddWithValue("@IsAdmin", giocatore.IsAdmin);
 

                SqlDataReader reader = command.ExecuteReader();
                return giocatore;
            }
        }

        public List<Giocatore> Fetch()
        {
            List<Giocatore> giocatori = new List<Giocatore>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =  "SELECT * FROM dbo.Giocatore";

                SqlDataReader reader = command.ExecuteReader();
            
                while (reader.Read())
                {
                    var Id = (int)reader["Id"];
                    var Nome = (string)reader["Nome"];
                    var Password = (string)reader["Password"];
                    var IsAuthenticated = (bool)reader["IsAuthenticated"];
                    var IsAdmin = (bool)reader["IsAdmin"];

                    Giocatore giocatore = new Giocatore(Id, Nome, Password, IsAuthenticated, IsAdmin);
                    giocatori.Add(giocatore);

                }

            }
            return giocatori;
        }

        public Giocatore GetGiocatoreByNomePassword(Giocatore giocatore)
        {
            string nome = giocatore.Nome;
            string password = giocatore.Password;
       

            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
              
            
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "" +
                    "SELECT * " +
                    " FROM dbo.Giocatore  " +
                    " WHERE dbo.Giocatore.Nome = @nome AND dbo.Giocatore.Password = @password";
                command.Parameters.AddWithValue("@nome", giocatore.Nome);
                command.Parameters.AddWithValue("@password", giocatore.Password);
      

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //var id = (int)reader["IdGiocatore"];
                    giocatore.IsAdmin = (bool)reader["IsAdmin"];
                    giocatore.IsAuthenticated = (bool)reader["IsAuthenticated"];
                }
               
            }
            
            return giocatore;
        }

        public string UserById(int idGiocatore)
        {
            Giocatore giocatore = new Giocatore();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "" +
                    "SELECT dbo.Giocatore.Nome " +
                    "FROM dbo.Giocatore  " +
                    "WHERE dbo.Giocatore.Id = @idGiocatore";
                command.Parameters.AddWithValue("@idGiocatore", idGiocatore);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    giocatore.Nome = (string)reader["Nome"];
                    

                }

            }
            return giocatore.Nome;
        }
    }
}
