using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_nikmak
{
    struct WPrice
    {
        public double wclient,wcorp;

        public WPrice(double wclient, double wcorp)
        {
            this.wclient = wclient;
            this.wcorp = wcorp;
        }

        public void Print()
        {
            Console.WriteLine("\t\t\t\tОптовая:\n\t\t\t\t\tКлиентская:");
            Console.WriteLine($"\t\t\t\t\t\t10: {wclient*0.98}\n\t\t\t\t\t\t100: {wclient*0.97}\n\t\t\t\t\t\t1000: {wclient*0.95}");
            Console.WriteLine("\t\t\t\t\tКорпоративная:");
            Console.WriteLine($"\t\t\t\t\t\t10: {wcorp * 0.98}\n\t\t\t\t\t\t100: {wcorp * 0.97}\n\t\t\t\t\t\t1000: {wcorp * 0.95}");
        }
        public void Cost(string tip, string disc)
        {
            switch (tip)
            {
                case "базовый":
                    wclient *= 0.95;
                    wcorp *= 0.95;
                    break;
                case "серебро":
                    wclient *= 0.90;
                    wcorp *= 0.90;
                    break;
                case "золото":
                    wclient *= 0.85;
                    wcorp *= 0.85;
                    break;
            }

            switch (disc)
            {
                case "эконом":
                    wclient *= 0.94;
                    wcorp *= 0.97;
                    break;
                case "стандарт":
                    wclient *= 0.93;
                    wcorp *= 0.95;
                    break;
                case "премиум":
                    wclient *= 0.89;
                    wcorp *= 0.94;
                    break;
            }
        }
    }
    struct BPrice
    {
        public double client, corp;

        public BPrice(int client, int corp)
        {
            this.client = client;
            this.corp = corp;
        }
        public void Cost(string tip, string disc)
        {
            switch (tip)
            {
                case "базовый":
                    client *= 0.95;
                    corp *= 0.95;
                    break;
                case "серебро":
                    client *= 0.90;
                    corp *= 0.90;
                    break;
                case "золото":
                    client *= 0.85;
                    corp *= 0.85;
                    break;
            }

            switch (disc)
            {
                case "эконом":
                    client *= 0.95;
                    corp *= 0.98;
                    break;
                case "стандарт":
                    client *= 0.93;
                    corp *= 0.96;
                    break;
                case "премиум":
                    client *= 0.90;
                    corp *= 0.95;
                    break;
            }
        }
        public void Print()
        {
            Console.WriteLine("\t\t\tЦена:\n\t\t\t\tБазовая:\n\t\t\t\t\tКлиентская: {0}\n\t\t\t\t\tКорпоративная: {1}", client, corp);
        }

    }

    struct Parameter
    {
        public string hieght, wieght, length, quantity, shelfLife, color;

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
        public string title, typi, discountClass;

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
            Console.WriteLine("Имя магазина: {0}\n\tТип лояльности: {1}", name, loyalty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WPrice opt2 = new WPrice(93000, 95500);
            BPrice price2 = new BPrice(98000, 99990);
            Parameter param2 = new Parameter("6.4``", "107 гр", "1 см", "1 шт", "5 лет", "красный");
            Product prod2 = new Product("Смартфон Бэпл", "Электроника", "премиум");
            Stand st2 = new Stand("2");
            WPrice opt1 = new WPrice(850, 880);
            BPrice price1 = new BPrice(1050, 850);
            Parameter param1 = new Parameter("120 см", "1 кг", "50 см", "1 шт", "2 года", "белый");
            Product prod1 = new Product("Чайник", "Бытовая техника", "эконом");
            Stand st1 = new Stand("1");
            Shop shop1 = new Shop("рога и копыта", "серебро");
            shop1.Print();
            st1.Print();
            prod1.Print();
            param1.Print();
            price1.Cost(shop1.loyalty, prod1.discountClass);
            price1.Print();
            opt1.Cost(shop1.loyalty, prod1.discountClass);
            opt1.Print();

            //2 стенд

            st2.Print();
            prod2.Print();
            param2.Print();
            price2.Cost(shop1.loyalty, prod1.discountClass);
            price2.Print();
            opt2.Cost(shop1.loyalty, prod1.discountClass);
            opt2.Print();

            Console.ReadKey();
        }
    }
}
