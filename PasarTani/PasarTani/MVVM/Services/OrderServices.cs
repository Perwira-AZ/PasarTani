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

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            conn.Open();

            var sql = "SELECT * FROM __get_orders_by_customer_id(@customerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);

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

        public Order GetOrderByCustomerIdAndOrderId(int customerId, int orderId)
        {
            conn.Open();

            var sql = "SELECT * FROM __get_order_by_customer_id_and_order_id(@customerId, @orderId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("orderId", orderId);

            Order order = null;

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    order = new Order
                    {
                        OrderID = reader.GetInt32(0),
                        CustomerID = reader.GetInt32(1),
                        ItemID = reader.GetInt32(2),
                        AddressID = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return order;
        }

        public void AddOrder(int customerId, int itemId, int addressId, int quantity)
        {
            conn.Open();

            var sql = "SELECT __add_order(@customerId, @itemId, @addressId, @quantity)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("itemId", itemId);
            cmd.Parameters.AddWithValue("addressId", addressId);
            cmd.Parameters.AddWithValue("quantity", quantity);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();
        }


        public void UpdateOrderByCustomerIdAndOrderId(int customerId, int orderId, int newItemId, int newAddressId, int newQuantity)
        {
            conn.Open();

            var sql = "SELECT __update_order_by_customer_id_and_order_id(@customerId, @orderId, @newItemId, @newAddressId, @newQuantity)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("orderId", orderId);
            cmd.Parameters.AddWithValue("newItemId", newItemId);
            cmd.Parameters.AddWithValue("newAddressId", newAddressId);
            cmd.Parameters.AddWithValue("newQuantity", newQuantity);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();
        
        }

        public void DeleteOrderByCustomerIdAndOrderId(int customerId, int orderId)
        {
            conn.Open();

            var sql = "SELECT __delete_order_by_customer_id_and_order_id(@customerId, @orderId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("orderId", orderId);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();
        }
    }
}
