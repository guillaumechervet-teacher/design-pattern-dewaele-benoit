using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain
{
    public class Article
    {
        private string id;
        private string label;
        private string category;
        private int price;
        private int stock;

        public Article(string id, string label, string category, int price, int stock)
        {
            this.id = id;
            this.label = label;
            this.category = category;
            this.price = price;
            this.stock = stock;
        }

        public string getId()
        {
            return this.id;
        }

        public string getLabel()
        {
            return this.label;
        }

        public string getCategory()
        {
            return this.category;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getStock()
        {
            return this.stock;
        }


        public int Calulate()
        {
            var amount = 0;
            var articlePrice = price;
            switch (category)
            {
                case "food":
                    amount += articlePrice * 100 + articlePrice * 12;
                    break;
                case "electronic":
                    amount += articlePrice * 100 + articlePrice * 20 + 4;
                    break;
                case "desktop":
                    amount += articlePrice * 100 + articlePrice * 20;
                    break;
            }

            return amount;
        }

    }
}