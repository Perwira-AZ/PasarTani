using Npgsql;
using PasarTani.Model;
using PasarTani.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            /*conn.Open();

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
                    };

                    items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error: " + ex.Message);
            }

            conn.Close();*/
            List<Item> items = new List<Item>();
            Item item = new Item
            {
                ItemID = 123,
                ItemName = "testItem",
                SellerID = 1,
                Stock = 20,
                Price = 2000,
            };
            Item item2 = new Item
            {
                ItemID = 124,
                ItemName = "testItem 2",
                SellerID = 1,
                Stock = 15,
                Price = 5000,
            };
            items.Add(item);
            items.Add(item2);

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
                        Price = reader.GetDecimal(4)
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
                        Price = reader.GetDecimal(4)
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

        public void AddItem(int sellerId, string itemName, int stock, decimal price)
        {
            conn.Open();

            var sql = "SELECT __add_item(@sellerId, @itemName, @stock, @price)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("itemName", itemName);
            cmd.Parameters.AddWithValue("stock", stock);
            cmd.Parameters.AddWithValue("price", price);

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

        public void UpdateItem(int sellerId, int itemId, string newItemName, int newStock, decimal newPrice)
        {
            conn.Open();

            var sql = "SELECT __update_item(@sellerId, @itemId, @newItemName, @newStock, @newPrice)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("itemId", itemId);
            cmd.Parameters.AddWithValue("newItemName", newItemName);
            cmd.Parameters.AddWithValue("newStock", newStock);
            cmd.Parameters.AddWithValue("newPrice", newPrice);

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

        public void DeleteItem(int sellerId, int itemId)
        {
            conn.Open();

            var sql = "SELECT __delete_item(@sellerId, @itemId)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("sellerId", sellerId);
            cmd.Parameters.AddWithValue("itemId", itemId);

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
