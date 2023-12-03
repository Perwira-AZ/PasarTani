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
    internal class CustomerServices
    {
        public CustomerServices()
        {
            
        }

        private NpgsqlConnection conn = new NpgsqlConnection(SharedData.connstring);

        //Order and Address Still Null, Get Manually from Address Services and Order Services
        public List<Customer> GetAllCustomers()
        {
            conn.Open();
            List<Customer> customers = new List<Customer>();


            var sql = "SELECT * FROM __get_all_customers()";
            using var cmd = new NpgsqlCommand(sql, conn);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PhoneNumber = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        AddressId = reader.GetInt32(5),
                        ImageUrl = reader.GetString(6)

                    };

                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return customers;
        }

        //Order and Address Still Null, Get Manually from Address Services and Order Services
        public Customer GetCustomerById(int customerId)
        {
            conn.Open();
            Customer customer = null;


            var sql = "SELECT * FROM __get_customer_by_id(@customerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PhoneNumber = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        AddressId = reader.GetInt32(5),
                        ImageUrl = reader.GetString(6)

                    };
                }
                else
                {
                    Console.WriteLine("Customer not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return customer;
        }

        public bool AddCustomer(string name, string phoneNumber, string email, string password, int addressid, string imageUrl)
        {
            conn.Open();

            var sql = "SELECT __add_customer(@name, @phoneNumber, @email, @password, @addressid, @imageUrl)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("addressid", addressid);
            cmd.Parameters.AddWithValue("imageUrl", imageUrl);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return false;
            }

            
        }

        public bool UpdateCustomer(int customerId, string name, string phoneNumber, string email, string password,string imageUrl)
        {
            conn.Open();

            var sql = "SELECT __update_customer(@customerId, @name, @phoneNumber, @email, @password, @imageUrl)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("imageUrl", imageUrl);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return false;
            }

        }

        public void DeleteCustomer(int customerId)
        {
            conn.Open();

            var sql = "SELECT __delete_customer(@customerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("customerId", customerId);

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
