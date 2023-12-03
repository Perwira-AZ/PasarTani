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
    internal class AddressServices
    {
        public AddressServices() 
        { 
        
        }

        private NpgsqlConnection conn = new NpgsqlConnection(SharedData.connstring);

        public List<Address> GetAllAddresses()
        {
            conn.Open();
            List<Address> addresses = new List<Address>();

            var sql = "SELECT * FROM __get_all_addresses()";
            using var cmd = new NpgsqlCommand(sql, conn);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Address address = new Address
                    {
                        AddressID = reader.GetInt32(0),
                        AddressName = reader.GetString(1),
                        City = reader.GetString(2),
                        Province = reader.GetString(3)
                    };

                    addresses.Add(address);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return addresses;
        }

        public Address GetAddressById(int addressId)
        {
            conn.Open();
            Address address = null;

            var sql = "SELECT * FROM __get_address_by_id(@addressId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("addressId", addressId);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    address = new Address
                    {
                        AddressID = reader.GetInt32(0),
                        AddressName = reader.GetString(1),
                        City = reader.GetString(2),
                        Province = reader.GetString(3)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return address;
        }

        public int AddAddress(string addressName, string cityName, string provinceName)
        {
            conn.Open();

            var sql = "SELECT __add_address(@addressName, @cityName, @provinceName)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("addressName", addressName);
            cmd.Parameters.AddWithValue("cityName", cityName);
            cmd.Parameters.AddWithValue("provinceName", provinceName);

            int newAddressId = (int)cmd.ExecuteScalar();

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return newAddressId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return newAddressId;
            }

            
        }

        public bool UpdateAddressById(int addressId, string newAddressName, string newCityName, string newProvinceName)
        {
            conn.Open();

            var sql = "SELECT __update_address_by_id(@addressId, @newAddressName, @newCityName, @newProvinceName)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("addressId", addressId);
            cmd.Parameters.AddWithValue("newAddressName", newAddressName);
            cmd.Parameters.AddWithValue("newCityName", newCityName);
            cmd.Parameters.AddWithValue("newProvinceName", newProvinceName);

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

        public void DeleteAddressById(int addressId)
        {
            conn.Open();

            var sql = "SELECT __delete_address_by_id(@addressId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("addressId", addressId);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine("Error: " + ex.Message);
            }

            
        }

    }
}
