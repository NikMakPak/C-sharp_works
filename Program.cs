using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_nikmak
{
    struct amoPrice
    {
        public int sum10;
        public int sum100;
        public int sum1000;

        public amoPrice(int sum10, int sum100, int sum1000)
        {
            this.sum10 = sum10;
            this.sum100 = sum100;
            this.sum1000 = sum1000;
        }
    }
    struct Wholesale
    {
        public amoPrice[] amoPricesClient;
        public amoPrice[] amoPricesCorp;

        public Wholesale(amoPrice[] amoPricesClient, amoPrice[] amoPricesCorp)
        {
            this.amoPricesClient = amoPricesClient;
            this.amoPricesCorp = amoPricesCorp;
        }
    }
    struct Basic
    {
        public int client;
        public int corp;

        public Basic(int client, int corp)
        {
            this.client = client;
            this.corp = corp;
        }
    }
    struct Price
    {
        public Basic[] basics;
        public Wholesale[] wholesales;

        public Price(Basic[] basics, Wholesale[] wholesales)
        {
            this.basics = basics;
            this.wholesales = wholesales;
        }
    }
    struct Parameter
    {
        public string hieght;
        public string wieght;
        public string length;
        public string quantity;
        public string shelfLife;
        public string color;

        public Parameter(string hieght = null, string wieght = null, string length = null, string quantity = null, string shelfLife = null, string color = null)
        {
            this.hieght = hieght;
            this.wieght = wieght;
            this.length = length;
            this.quantity = quantity;
            this.shelfLife = shelfLife;
            this.color = color;
        }
    }
    struct Product
    {
        public string title;
        public string typi;
        public string discountClass;
        public Parameter[] parameters;
        public Price[] prices;

        public Product(string type, string className, string title, string typi, string discountClass, Parameter[] parameters, Price[] prices) : this(type, className)
        {
            this.title = title;
            this.typi = typi;
            this.discountClass = discountClass;
            this.parameters = parameters;
            this.prices = prices;
        }
    }
    struct Stand
    {
        public string number;
        public Product[] products;

        public Stand(string number, Product[] products)
        {
            this.number = number;
            this.products = products;
        }
    }
    struct Shop
    {
        public string name;
        public Stand[] stands;

        public Shop(string name, Stand[] stands)
        {
            this.name = name;
            this.stands = stands;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Stand stand1 = new Stand(number:"1",
                new Product[] { 
                    new Product("техника","эконом",new Parameter(color:"red"))
                }
                );
            Shop shop1 = new Shop(
                name:"Рога",
                stands: new[] 
                {
                    stand1
                }
            );
            
            Console.WriteLine(Shop);
        }
    }
}
