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
    public class AdoRepositoryCategoria : IRepositoryCategorie
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = MostriVsEroi;" +
                                         "Integrated Security = true";
        public List<Categoria> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> FetchCategorieEroi()
        {   
            List<Categoria> categorie = new List<Categoria>();
            bool flag = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT dbo.Categoria.Id, dbo.Categoria.Nome FROM dbo.Categoria WHERE dbo.Categoria.Flag = @flag";
                    command.Parameters.AddWithValue("@flag", flag);


                SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();

                        categoria.Id = (int)reader["Id"];
                        categoria.Nome = (string)reader["Nome"];
                        

                        categorie.Add(categoria);

                    }
                    return categorie;
                }

            }
        

        public List<Categoria> FetchCategorieMostri()
        {
                List<Categoria> categorie = new List<Categoria>();
                bool flag = true;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT dbo.Categoria.Id, dbo.Categoria.Nome FROM dbo.Categoria WHERE dbo.Categoria.Flag = @flag";
                    command.Parameters.AddWithValue("@flag", flag);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();

                        categoria.Id = (int)reader["Id"];
                        categoria.Nome = (string)reader["Nome"];


                        categorie.Add(categoria);

                    }
                    return categorie;
                }

            }
        

        public Categoria GetById(int categoriaScelta)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Categoria categoria = new Categoria();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Categoria.Nome FROM dbo.Categoria WHERE dbo.Categoria.Id = @categoriaScelta";
                command.Parameters.AddWithValue("@categoriaScelta", categoriaScelta);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    categoria.Nome = (string)reader["Nome"];


                }
                return categoria;
            }

        }

        public Categoria GetCategoriaByEroe(Eroe eroe)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Categoria categoria = new Categoria();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Categoria.Nome, dbo.Categoria.Id AS Id, dbo.Eroe.Id AS EroeId FROM dbo.Categoria JOIN dbo.Eroe ON dbo.Eroe.IdCategoria = dbo.Categoria.Id WHERE dbo.Eroe.Id = @idEroe";
                command.Parameters.AddWithValue("@idEroe", eroe.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categoria.Id = (int)reader["Id"];
                    categoria.Nome = (string)reader["Nome"];
                    eroe.Id = (int)reader["EroeId"];
                }
                return categoria;
            }

        }

        public Categoria GetCategoriaByMostro(Mostro mostroScelto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Categoria categoria = new Categoria();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT dbo.Categoria.Nome, dbo.Categoria.Id AS Id, dbo.Mostro.Id AS MostroId FROM dbo.Categoria JOIN dbo.Mostro ON dbo.Mostro.IdCategoria = dbo.Categoria.Id WHERE dbo.Mostro.Id = @idMostro";
                command.Parameters.AddWithValue("@idMostro", mostroScelto.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categoria.Id = (int)reader["Id"];
                    categoria.Nome = (string)reader["Nome"];
                    mostroScelto.Id = (int)reader["MostroId"];
                }
                return categoria;
            }
        }
    }
}
