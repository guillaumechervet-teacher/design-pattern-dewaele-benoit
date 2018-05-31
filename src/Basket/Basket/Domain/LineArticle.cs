using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain
{
    public class LineArticle
    {
        private Article article;
        private int number;
        public LineArticle(Article unArticle, int unNumber)
        {
            article = unArticle;
            number = unNumber;
        }

    }
}
