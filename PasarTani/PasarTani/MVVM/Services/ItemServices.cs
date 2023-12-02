using Imagekit.Sdk;
using Npgsql;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasarTani.MVVM.Services
{
    internal class ItemServices
    {

        public ItemServices()
        {

        }
        private NpgsqlConnection conn = new NpgsqlConnection(SharedData.connstring);

        public List<Item> getAllItems()
        {
            conn.Open();

            var sql = @"SELECT * FROM __get_all_items()";
            using var cmd = new NpgsqlCommand(sql, conn);

            List<Item> items = new List<Item>();
            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item
                    {
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        SellerID = reader.GetInt32(2),
                        Stock = reader.GetInt32(3),
                        Price = reader.GetDecimal(4),
                        ImageURL = reader.IsDBNull(5) ? null : reader.GetString(5) // Check for null in case of nullable columns
                    };

                    items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return items;
        }

        public List<Item> GetItemsBySellerId(int sellerId)
        {
            conn.Open();

            var sql = @"SELECT * FROM __get_items_by_seller_id(@sellerId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);

            List<Item> items = new List<Item>();
            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item
                    {
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        SellerID = reader.GetInt32(2),
                        Stock = reader.GetInt32(3),
                        Price = reader.GetDecimal(4),
                        ImageURL = reader.IsDBNull(5) ? null : reader.GetString(5) // Check for null in case of nullable columns
                    };

                    items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message);
            }

            conn.Close();

            return items;
        }

        public Item GetItemById(int itemId)
        {
            conn.Open();

            Item item = null;

            var sql = "SELECT * FROM __get_item_by_id(@itemId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("itemId", itemId);

            try
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new Item
                    {
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        SellerID = reader.GetInt32(2),
                        Stock = reader.GetInt32(3),
                        Price = reader.GetDecimal(4),
                        ImageURL = reader.IsDBNull(5) ? null : reader.GetString(5) // Check for null in case of nullable columns
                    };

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            conn.Close();
            return item;
        }

        public bool AddItem(string itemName, int sellerId,  int stock, decimal price, string imageUrl)
        {
            conn.Open();

            var sql = "SELECT __add_item(@itemName, @sellerId, @stock, @price, @imageUrl)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("itemName", itemName);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("stock", stock);
            cmd.Parameters.AddWithValue("price", price);
            cmd.Parameters.AddWithValue("imageUrl", imageUrl);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            conn.Close();
        }

        public bool UpdateItem(int itemId,  string newItemName, int sellerId, int newStock, decimal newPrice, string newImageUrl)
        {
            conn.Open();

            var sql = "SELECT __update_item(@itemId, @newItemName, @sellerId, @newStock, @newPrice, @newImageUrl)";
            Trace.WriteLine(sql);
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("itemId", itemId);
            cmd.Parameters.AddWithValue("newItemName", newItemName);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("newStock", newStock);
            cmd.Parameters.AddWithValue("newPrice", newPrice);
            cmd.Parameters.AddWithValue("newImageUrl", newImageUrl);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message);
                return false;
            }

            conn.Close();
        }

        public bool DeleteItem(int sellerId, int itemId)
        {
            conn.Open();

            var sql = "SELECT __delete_item(@sellerId, @itemId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("itemId", itemId);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            conn.Close();
        }

        public string GenerateUrlImage(string filepath, string uniqueid)
        {
            ImagekitClient imagekit = new ImagekitClient(SharedData.imagePublicKey, SharedData.imagePrivateKey, SharedData.imageProductEndPoint);

            try
            {
                byte[] bytes = File.ReadAllBytes(filepath);


                string filename = uniqueid;

                FileCreateRequest ob = new FileCreateRequest
                {
                    file = bytes,
                    fileName = filename,
                    useUniqueFileName = true
                };
                Result resp2 = imagekit.Upload(ob);

                string imageURL = resp2.url;

                Trace.WriteLine(resp2.url);
                Trace.WriteLine(imageURL);

                return imageURL;
            }
            catch
            {
                return "";
            }
        }
    }
}
