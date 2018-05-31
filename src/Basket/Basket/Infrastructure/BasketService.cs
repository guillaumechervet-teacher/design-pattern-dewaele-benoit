using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Basket = Basket.Domain.Basket;

namespace Basket.Infrastructure
{
    class BasketService
    {
        public Domain.Basket GetBasket(IList<BasketLineArticle>
            basketLineArticles)
        {
            return new Domain.Basket();
        }
    }
}
