using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Basket.OrientedObject.Infrastructure
{
    class ArticleDatabaseJson
    {
        public static Basket.ArticleDatabaseJson GetArticleDatabase(string id)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");

            IList<Basket.ArticleDatabaseJson> articleDatabases = JsonConvert.DeserializeObject<List<Basket.ArticleDatabaseJson>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase => articleDatabase.Id == id);
            return article;
        }
    }
}
