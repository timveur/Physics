using Newtonsoft.Json;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Physics.Controllers
{
    public class FormulasController
    {

        /// <summary>
        /// Вывод всех данных из таблицы Formulas
        /// </summary>
        /// <returns></returns>
        public static List<Formula> GetFormulas()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/Formulas").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer = JsonConvert.DeserializeObject<List<Formula>>(content.Result);
                return answer;
            }
        }

    }
}
