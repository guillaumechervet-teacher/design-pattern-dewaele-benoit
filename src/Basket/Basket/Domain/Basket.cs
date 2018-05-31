using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain
{
    public class Basket
    {
        private List<LineArticle> lineArticles;
        public Basket(List<LineArticle> unLineArticles)
        {
            lineArticles = unLineArticles;
        }
    }
}