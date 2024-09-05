using Microsoft.Data.Sqlite;

namespace WebAPI_DB
{
    public class CustomerDB : IDisposable
    {
        private SqliteConnection connection = null;

        public CustomerDB()
        {
            connection = new SqliteConnection("Data Source=CustomerOrders.db");
            connection.Open();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// Function to create table to be used for debugging on location machine
        /// </summary>
        public void CreateTables()
        {
            var command = connection.CreateCommand();
            command.CommandText = @"
                    CREATE TABLE CustomerData (
                        CustomerName TEXT,
                        CustomerLocation TEXT
                    );

                    INSERT INTO CustomerData
                    VALUES ('Customer 1', 'Location 1'),
                           ('Customer 2', 'Location 2'),
                           ('Customer 3', 'Location 3');
                ";

            command.ExecuteNonQuery();
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            var command = connection.CreateCommand();
            command.CommandText =@"SELECT *
                                FROM CustomerData";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var customerName = reader.GetString(0);
                    var customerLoc = reader.GetString(1);
                    
                    list.Add(new Customer() { CustomerName = customerName, CustomerLocation = customerLoc });
                        Console.WriteLine($"Hello, {customerName}!");
                }
            }

            return list;
        }

        public void AddCustomerDB(Customer customer)
        {
            List<Customer> list = new List<Customer>();
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO CustomerData
                    VALUES ('$Name', '$Location');";
            command.Parameters.AddWithValue("$Name", customer.CustomerName);
            command.Parameters.AddWithValue("$Location", customer.CustomerLocation);

            command.ExecuteNonQuery();
        }

        public void DeleteCustomerDB(Customer customer)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM CustomerData 
                WHERE CustomerName='$Name' AND CustomerLocation='$Location';";
            command.Parameters.AddWithValue("$Name", customer.CustomerName);
            command.Parameters.AddWithValue("$Location", customer.CustomerLocation);
            
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Function to refer code from, to be deleted as soon as work is done.
        /// </summary>
        public void SampleCode()
        {
            using (var connection = new SqliteConnection("Data Source=CustomerOrders.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                                        @"
                                SELECT name
                                FROM user
                                WHERE id = $id
                            ";
                command.Parameters.AddWithValue("$id", 1);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
            }
        }
    }
}
