using Newtonsoft.Json;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Physics.Controllers
{
    public class MeasurementsController
    {
        /// <summary>
        /// Вывод всех данных из таблицы Measurements
        /// </summary>
        /// <returns>
        /// Данные из таблицы Measurements
        /// </returns>
        public static List<Measurement> GetMeasurements()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/Measurements").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Measurement>>(content.Result);
                return answer;
            }
        }


        /// <summary>
        ///  Вывод данных из таблицы Measurements по переданному TablesMeasureId
        /// </summary>
        /// <param name="idTablesMeasure">Идентификатор переданный из таблицы TablesMeasurement</param>
        /// <returns>
        /// Строки у которых IdTablesMeasure = idTablesMeasure
        /// </returns>
        public static List<Measurement> GetMeasurementsFromTablesId(int idTablesMeasure)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/Measurements/?tablesMeasureId={idTablesMeasure}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Measurement>>(content.Result);
                return answer;
            }
        }

    }
}
