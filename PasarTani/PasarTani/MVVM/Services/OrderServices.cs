using Npgsql;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Services
{
    internal class OrderServices
    {
        public OrderServices()
        {
            
        }

        private NpgsqlConnection conn = new NpgsqlConnection(SharedData.connstring);

        public List<Order> GetAllOrders()
        {
            conn.Open();

            var sql = "SELECT * FROM __get_all_orders()";
            using var cmd = new NpgsqlCommand(sql, conn);

            List<Order> orders = new List<Order>();

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderID = reader.GetInt32(0),
                        CustomerID = reader.GetInt32(1),
                        ItemID = reader.GetInt32(2),
                        AddressID = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4)
                    };

                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return orders;
        }

    }
}
