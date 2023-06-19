using Newtonsoft.Json;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Physics.Controllers
{
    public class TablesMeasurementsController
    {
        /// <summary>
        /// Вывод всех данных из таблицы TablesMeasurements
        /// </summary>
        /// <returns></returns>
        public static List<TablesMeasurement> GetTablesMeasurements()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/TablesMeasurements").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<TablesMeasurement>>(content.Result);
                return answer;
            }
        }
    }
}
