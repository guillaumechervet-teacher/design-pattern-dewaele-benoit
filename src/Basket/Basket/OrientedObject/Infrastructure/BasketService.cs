using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Basket.OrientedObject.Domain;
using Newtonsoft.Json;

namespace Basket.OrientedObject.Infrastructure
{
    public class BasketService
    {
        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            IList<LineArticle> LinesBasket = new List<LineArticle>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var articleId = basketLineArticle.Id;
                var article = GetArticleDatabase(articleId);
                LinesBasket.Add(new LineArticle(new Article(article.Id, article.Label, article.Category, article.Price, article.Stock), 
                    basketLineArticle.Number));
            }

            return new Domain.Basket(LinesBasket);
        }

        public static ArticleDatabase GetArticleDatabase(string id)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");

            IList<ArticleDatabase> articleDatabases = JsonConvert.DeserializeObject<List<ArticleDatabase>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase => articleDatabase.Id == id);
            return article;
        }

    }
}
