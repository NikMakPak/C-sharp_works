using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_nikmak
{
    struct WPriceCorp
    {
        public int sum10;
        public int sum100;
        public int sum1000;

        public WPriceCorp(int sum10, int sum100, int sum1000)
        {
            this.sum10 = sum10;
            this.sum100 = sum100;
            this.sum1000 = sum1000;
        }
    }
    struct WPriceClient
    {
        public int sum10;
        public int sum100;
        public int sum1000;

        public WPriceClient(int sum10, int sum100, int sum1000)
        {
            this.sum10 = sum10;
            this.sum100 = sum100;
            this.sum1000 = sum1000;
        }
    }
    struct BPrice
    {
        public int client,corp;

        public BPrice(int client, int corp)
        {
            this.client = client;
            this.corp = corp;
        }
        public void Print()
        {
            Console.WriteLine("\t\t\tЦена\n\t\t\t\tБазовая:\n\t\t\t\t\tКлиентская:{0}\n\t\t\t\t\tКорпоративная:{1}",client,corp);
        }

    }
    
    struct Parameter
    {
        public string hieght,wieght,length,quantity,shelfLife,color;

        public Parameter(string hieght = null, string wieght = null, string length = null, string quantity = null, string shelfLife = null, string color = null)
        {
            this.hieght = hieght;
            this.wieght = wieght;
            this.length = length;
            this.quantity = quantity;
            this.shelfLife = shelfLife;
            this.color = color;
        }
        public void Print()
        {
            Console.WriteLine("\t\t\tПараметры:\n\t\t\t\tВысота: {0}\n\t\t\t\tВес: {1}\n\t\t\t\tДлина: {2}", hieght, wieght, length);
            Console.WriteLine("\t\t\t\tКол-во: {0}\n\t\t\t\tСрок годности: {1}\n\t\t\t\tЦвет: {2}", quantity, shelfLife, color);
        }
    }
    struct Product
    {
        public string title,typi,discountClass;

        public Product(string title, string typi, string discountClass)
        {
            this.title = title;
            this.typi = typi;
            this.discountClass = discountClass;
        }
        public void Print()
        {
            Console.WriteLine("\t\tТовар {0}:\n\t\t\tТип: {1}\n\t\t\tКласс: {2}", title, typi, discountClass);
        }
    }
    struct Stand
    {
        public string number;

        public Stand(string number)
        {
            this.number = number;
        }
        public void Print()
        {
            Console.WriteLine("\tСтойка {0}:", number);
        }
    }
    struct Shop
    {
        public string name, loyalty;

        public Shop(string name, string loyalty)
        {
            this.name = name;
            this.loyalty = loyalty;
        }

        public void Print()
        {
            Console.WriteLine("Имя магазина: {0}\n\tТип лояльности: {1}",name, loyalty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WPriceCorp p1 = new WPriceCorp(100,1000,10000);

            Parameter param1 = new Parameter("120 см", "1 кг", "50 см", "1 шт", "2 года","красный");
            Product prod1 = new Product("Чайник", "Бытовая техника", "эконом");
            Stand st1 = new Stand("1");
            Shop shop1 = new Shop("рога и копыта","серебро");
            shop1.Print();
            st1.Print();
            prod1.Print();
            param1.Print();
            if (shop1.loyalty== "базовый")
            {
                Console.WriteLine("yes");
            }
            Console.ReadKey();
        }
    }
}
