using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain
{
    public class Article
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
