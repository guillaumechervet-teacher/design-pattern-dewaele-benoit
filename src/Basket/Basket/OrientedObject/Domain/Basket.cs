using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain
{
    public class Basket
    {
        private IList<LineArticle> lineArticles;
        public Basket(IList<LineArticle> unLineArticles)
        {
            lineArticles = unLineArticles;
        }

        public IList<LineArticle> GetLineArticles()
        {
            return this.lineArticles;
        }
        public int Calculate()
        {
            int total = 0;
            foreach (var ligne in lineArticles)
            {
                total += ligne.Calculate();
            }
            return total;
        }
    }
}