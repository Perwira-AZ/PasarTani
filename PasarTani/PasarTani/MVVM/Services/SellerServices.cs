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
    internal class SellerServices
    {
        public SellerServices()
        {
            
        }

        private NpgsqlConnection conn = new NpgsqlConnection(SharedData.connstring);
        
        //Order and Address Still Null, Get Manually from Address Services and Order Services
        public List<Seller> GetAllSellers()
        {
            conn.Open();
            List<Seller> sellers = new List<Seller>();


            var sql = "SELECT * FROM __get_all_sellers()";
            using var cmd = new NpgsqlCommand(sql, conn);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Seller seller = new Seller
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PhoneNumber = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        AddressId = reader.GetInt32(5),
                        ImageUrl = reader.GetString(6)

                    };

                    sellers.Add(seller);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return sellers;
        }
        
        //Order and Address Still Null, Get Manually from Address Services and Order Services
        public Seller GetSellerById(int sellerId)
        {
            conn.Open();
            Seller seller = null;


            var sql = "SELECT * FROM __get_seller_by_id(@sellerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    seller = new Seller
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return seller;
        }

        //Order and Address Still Null, Set Manually from Address Services and Order Services
        public bool AddSeller(string name, string phoneNumber, string email, string password, int addressid, string imageUrl)
        {
            conn.Open();

            var sql = "SELECT __add_seller(@name, @phoneNumber, @email, @password, @addressid, @imageUrl)";
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

        //Order and Address Still Null, Update Manually from Address Services and Order Services
        public bool UpdateSeller(int sellerId, string name, string phoneNumber, string email, string password, string imageUrl)
        {
            conn.Open();

            var sql = "SELECT __update_seller(@sellerId, @name, @phoneNumber, @email, @password, @imageUrl)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
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
        public void DeleteSeller(int sellerId)
        {
            conn.Open();

            var sql = "SELECT __delete_seller(@sellerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);

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
