using Newtonsoft.Json;
using PasarTani.MVVM.View;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PasarTani.MVVM.Services
{
    class CekHarga
    {
        public List<Table> GetDataList()
        {

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the start date as 5 days ago
            DateTime startDate = currentDate.AddDays(-5);

            // Format the dates in the required format (YYYY-MM-DD)
            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = currentDate.ToString("yyyy-MM-dd");

            // Update the URL with the calculated start and end dates
            string apiUrl = $"https://www.bi.go.id/hargapangan/WebSite/TabelHarga/GetGridDataDaerah?price_type_id=4&comcat_id=&province_id=&regency_id=&market_id=&tipe_laporan=1&start_date={startDateString}&end_date={endDateString}&_=1700182751171";

            var client = new RestClient(apiUrl); var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TableWrapper>(response.Content).data;
        }
    }
}
