using Newtonsoft.Json;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Physics.Controllers
{
    public class LabWorksController
    {
        /// <summary>
        /// Вывод всех данных из таблицы LabWorks
        /// </summary>
        /// <returns>
        /// Данные из таблицы LabWorks
        /// </returns>
        public static List<LabWork> GetLabWorks()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/LabWorks").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<LabWork>>(content.Result);
                return answer;
            }
        }


        /// <summary>
        ///  Вывод данных из таблицы LabWorks по переданному идентификатору
        /// </summary>
        /// <param name="idLabWork">Переданный идентификатор IdLabWork</param>
        /// <returns>
        /// Строка у которой IdLabWork = idLabWork
        /// </returns>
        public static List<LabWork> GetLabWorksById(int idLabWork)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/LabWorks/{idLabWork}").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<LabWork>>(content.Result);
                return answer;
            }
        }

    }
}
