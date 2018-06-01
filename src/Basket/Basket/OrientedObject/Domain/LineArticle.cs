using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain
{
    public class LineArticle
    {
        private Article article;
        private int number;

        public LineArticle(Article article, int number)
        {
            this.article = article;
            this.number = number;
        }

        public Article GetArticle()
        {
            return this.article;
        }
        public int getNumnber()
        {
            return this.number;
        }

        public int Calculate()
        {
            return article.Calulate() * number;
        }

    }
}