using System;
using System.Data;
using Npgsql;

public class AeropuertoContext
{
    private string connectionString;

    public AeropuertoContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DataTable ObtenerAviones()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Aviones";

            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

    public void AgregarAvion(int numero, string modelo, int peso, int capacidad, int hangarId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Aviones (Numero, Modelo, Peso, Capacidad, HangarID) " +
                           "VALUES (@Numero, @Modelo, @Peso, @Capacidad, @HangarID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Numero", numero);
                command.Parameters.AddWithValue("@Modelo", modelo);
                command.Parameters.AddWithValue("@Peso", peso);
                command.Parameters.AddWithValue("@Capacidad", capacidad);
                command.Parameters.AddWithValue("@HangarID", hangarId);

                command.ExecuteNonQuery();
            }
        }
    }
}
