using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Infrastructure
{
    public interface IArticleDatabase
    {
        ArticleDatabaseJson GetArticle(string id);
    }
}