using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using Physics.Models;

namespace Physics.Controllers
{
    public class ChaptersController
    {

        /// <summary>
        /// Вывод всех данных из таблицы Chapters
        /// </summary>
        /// <returns></returns>
        public static List<Chapter> GetChapters()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"{Manager.RootUrl}/Chapters").Result;
                var content = response.Content.ReadAsStringAsync();
                var answer =JsonConvert.DeserializeObject<List<Chapter>>(content.Result);
                return answer;
            }
        }

        /// <summary>
        /// Вывод из таблицы Chapters данных с ParentId=0
        /// </summary>
        /// <returns></returns>
        public static List<Chapter> GetChaptersFirst()
        {
            List<Chapter> chapters = GetChapters();
            List<Chapter> sections = chapters.Where(x => x.ParentId == 0).ToList();
            return sections;
        }

        /// <summary>
        /// Получение строки NameFile по IdChapter
        /// </summary>
        /// <param name="idChapter">Идентификатор параграфа</param>
        /// <returns></returns>
        public static string GetChapterFile(int idChapter)
        {
            List<Chapter> chapters = GetChapters();
            Chapter paragraph = chapters.FirstOrDefault(x=>x.IdChapter==idChapter);
            string pathFile = paragraph.NameFile;
            return pathFile;
        }

    }
}
