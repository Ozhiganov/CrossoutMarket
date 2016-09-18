﻿using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Crossout.Model.Items
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int SellOffers { get; set; }

        public int SellPrice { get; set; }

        public int BuyOrders { get; set; }

        public int BuyPrice { get; set; }
        
        public int Margin
        {
            get { return  (int)(SellPrice - BuyPrice - (SellPrice * 0.1d)); }
        }
        
        public string FormatMargin
        {
            get { return FormatPrice(Margin); }
        }

        public DateTime Timestamp { get; set; }
        
        public int RarityId { get; set; }
        public string RarityName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeId { get; set; }
        public int RecipeId { get; set; }
        public string TypeName { get; set; }
        public string FormatBuyPrice
        {
            get
            {
                return FormatPrice(BuyPrice);
            }
        }
        
        public string FormatSellPrice
        {
            get
            {
                return FormatPrice(SellPrice);
            }
        }
        
        public string Image
        {
            get { return $"{Id}.png"; }
        }
        
        public string FormatPrice(int price)
        {
            return string.Format(CultureInfo.InvariantCulture,"{0:0.00}", price/100m);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(SellOffers)}: {SellOffers}, {nameof(SellPrice)}: {SellPrice}, {nameof(BuyOrders)}: {BuyOrders}, {nameof(BuyPrice)}: {BuyPrice}";
        }

        public static Item Create(object[] row)
        {
            int i = 0;
            Item item = new Item
            {
                Id = Convert.ToInt32(row[i++]),
                Name = Convert.ToString(row[i++]),
                SellPrice = Convert.ToInt32(row[i++]),
                BuyPrice = Convert.ToInt32(row[i++]),
                SellOffers = Convert.ToInt32(row[i++]),
                BuyOrders = Convert.ToInt32(row[i++]),
                Timestamp = Convert.ToDateTime(row[i++]),
                RarityId = Convert.ToInt32(row[i++]),
                RarityName = Convert.ToString(row[i++]),
                CategoryId = Convert.ToInt32(row[i++]),
                CategoryName = Convert.ToString(row[i++]),
                TypeId = Convert.ToInt32(row[i++]),
                TypeName = Convert.ToString(row[i++])
            };

            if (DBNull.Value == row[i])
            {
                item.RecipeId = 0;
            }
            else
            {
                item.RecipeId = Convert.ToInt32(row[i]);
            }

            return item;
        }

        public static Item CreateForChart(object[] row)
        {
            int i = 0;
            Item item = new Item
            {
                Id = Convert.ToInt32(row[i++]),
                SellPrice = Convert.ToInt32(row[i++]),
                BuyPrice = Convert.ToInt32(row[i++]),
                SellOffers = Convert.ToInt32(row[i++]),
                BuyOrders = Convert.ToInt32(row[i++]),
                Timestamp = Convert.ToDateTime(row[i++]),
            };
            return item;
        }
    }
}