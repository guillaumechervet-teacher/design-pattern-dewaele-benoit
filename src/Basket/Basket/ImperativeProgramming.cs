﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Basket
{
    public class ImperativeProgramming
    {
        public static decimal CalculateBasketAmount(IList<BasketLineArticle> BasketLineArticles)
        {
            var amountTotal = 0;
            foreach (var basketLineArticle in BasketLineArticles)
            {
            #if DEBUG
                var article = GetArticleDatabaseMock(basketLineArticle.Id); 
            #else
                 var article = GetArticleDatabase(basketLineArticle.Id);
            #endif
                var amount = 0;
                switch (article.Category)
                {
                    case "food":
                        amount += article.Price * 100 + article.Price * 12;
                        break;
                    case "electronic":
                        amount += article.Price * 100 + article.Price * 20 + 4;
                        break;
                    case "desktop":
                        amount += article.Price * 100 + article.Price * 20;
                        break;
                }
                amountTotal += basketLineArticle.Number * amount;
            }
            return amountTotal;
        }

        public static ArticleDatabaseJson GetArticleDatabase(string id)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");

            IList<ArticleDatabaseJson> articleDatabases = JsonConvert.DeserializeObject<List<ArticleDatabaseJson>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase => articleDatabase.Id == id);
            return article;
        }

        public static ArticleDatabaseJson GetArticleDatabaseMock(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabaseJson
                    {
                        Id = "1",
                        Price = 1,
                        Stock =
                            35,
                        Label = "Banana",
                        Category = "food"
                    };
                case "2":
                    return new ArticleDatabaseJson
                    {
                        Id = "2",
                        Price = 500,
                        Stock = 20,
                        Label = "Fridge electrolux",
                        Category = "electronic"
                    };
                case "3":
                    return new ArticleDatabaseJson
                    {
                        Id = "3",
                        Price = 49,
                        Stock =
                            68,
                        Label = "Chair",
                        Category = "desktop"
                    };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
