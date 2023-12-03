using Newtonsoft.Json;
using PasarTani.MVVM.View;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;

namespace PasarTani.MVVM.Services
{
    class CekHarga
    {
        public List<Table> GetDataList()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the start date as 5 days ago
            DateTime startDate = currentDate.AddDays(-3);

            // Format the dates in the required format (dd/MM/yyyy)
            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = currentDate.ToString("yyyy-MM-dd");

            string todayString = currentDate.ToString("dd/MM/yyyy");
            string yesterdayString = currentDate.AddDays(-1).ToString("dd/MM/yyyy");
            string daymin2String = currentDate.AddDays(-2).ToString("dd/MM/yyyy");
            string daymin3yString = currentDate.AddDays(-3).ToString("dd/MM/yyyy");

            // Update the URL with the calculated start and end dates
            string apiUrl = $"https://www.bi.go.id/hargapangan/WebSite/TabelHarga/GetGridDataDaerah?price_type_id=4&comcat_id=&province_id=&regency_id=&market_id=&tipe_laporan=1&start_date={startDateString}&end_date={endDateString}&_=1700182751171";

            var client = new RestClient(apiUrl);
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            // Deserialize the response into a dynamic object
            Console.WriteLine(response.Content);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

            // Create a list to store the Table objects
            List<Table> dataList = new List<Table>();

            // Iterate over each item in the "data" array
            foreach (var item in jsonResponse.data)
            {
                // Create a new Table object
                Table table = new Table
                {
                    no = item.no,
                    name = item.name,
                    level = item.level,
                    today = item[todayString],
                    yesterday = item[yesterdayString],
                    daymin2 = item[daymin2String],
                    daymin3 = item[daymin3yString],
                };

                // Iterate over each property in the item

                // Add the Table object to the list
                dataList.Add(table);
            }

            return dataList;
        }
    }
}
