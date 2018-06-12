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
                var article = ArticleDatabaseJson.GetArticleDatabase(articleId);
                LinesBasket.Add(new LineArticle(new Article(article.Id, article.Label, article.Category, article.Price, article.Stock), 
                    basketLineArticle.Number));
            }

            return new Domain.Basket(LinesBasket);
        }

    }
}
