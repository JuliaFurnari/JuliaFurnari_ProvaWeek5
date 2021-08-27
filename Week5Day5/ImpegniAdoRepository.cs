using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    class ImpegniAdoRepository:IImpegnoRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                        "Initial Catalog = Agenda;" +
                                        "Integrated Security = true;";
        public List<Impegno> Fetch()
        {
            List<Impegno> agenda = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataDiScadenza = (DateTime)reader["DataDiScadenza"];
                    var importanza = (Livello)Enum.Parse(typeof(Livello), (string)reader["Importanza"]);
                    var eseguito = (bool)reader["Eseguito"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(titolo, descrizione, dataDiScadenza, importanza, eseguito, id);

                    agenda.Add(impegno);
                }
            }
            return agenda;

        }

        public void Delete(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", impegno.Id);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Impegno set Titolo = @titolo, Descrizione = @descrizione," +
                                      "DataDiScadenza = @data, Importanza = @importanza," +
                                      "Eseguito = @eseguito where Id = @id";
                command.Parameters.AddWithValue("@titolo", impegno.Titolo);
                command.Parameters.AddWithValue("@descrizione", impegno.Descrizione);
                command.Parameters.AddWithValue("@data", impegno.DataDiScadenza);
                command.Parameters.AddWithValue("@importanza", impegno.Importanza.ToString());
                command.Parameters.AddWithValue("@eseguito", impegno.Eseguito);
                command.Parameters.AddWithValue("@id", impegno.Id);


                command.ExecuteNonQuery();
            }
        }

        public void Insert(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into Impegno values (@titolo, @descrizione, @data, @importanza, @eseguito)";
                command.Parameters.AddWithValue("@titolo", impegno.Titolo);
                command.Parameters.AddWithValue("@descrizione", impegno.Descrizione);
                command.Parameters.AddWithValue("@data", impegno.DataDiScadenza);
                command.Parameters.AddWithValue("@importanza", impegno.Importanza.ToString());
                command.Parameters.AddWithValue("@eseguito", impegno.Eseguito);

                command.ExecuteNonQuery();
            }
        }

        public List<Impegno> GetImpegniPerData(DateTime data)
        {
            List<Impegno> agenda = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where DataDiScadenza >= @data";
                command.Parameters.AddWithValue("@data", data);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataDiScadenza = (DateTime)reader["DataDiScadenza"];
                    var importanza = (Livello)Enum.Parse(typeof(Livello), (string)reader["Importanza"]);
                    var eseguito = (bool)reader["Eseguito"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(titolo, descrizione, dataDiScadenza, importanza, eseguito, id);

                    agenda.Add(impegno);
                }
            }
            return agenda;
        }

        public List<Impegno> GetImpegniImportanza(Livello imp)
        {
            List<Impegno> agenda = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Importanza = @importanza";
                command.Parameters.AddWithValue("@importanza", imp.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataDiScadenza = (DateTime)reader["DataDiScadenza"];
                    var importanza = (Livello)Enum.Parse(typeof(Livello), (string)reader["Importanza"]);
                    var eseguito = (bool)reader["Eseguito"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(titolo, descrizione, dataDiScadenza, importanza, eseguito, id);

                    agenda.Add(impegno);
                }
            }
            return agenda;
        }

        public List<Impegno> GetEseguiti()
        {
            List<Impegno> agenda = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Eseguito = 1";
                

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataDiScadenza = (DateTime)reader["DataDiScadenza"];
                    var importanza = (Livello)Enum.Parse(typeof(Livello), (string)reader["Importanza"]);
                    var eseguito = (bool)reader["Eseguito"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(titolo, descrizione, dataDiScadenza, importanza, eseguito, id);

                    agenda.Add(impegno);
                }
            }
            return agenda;
        }
    }
}