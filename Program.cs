using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_training
{
    internal class Program
    {
        class Global
        {
            private static List<int> ids = new List<int>();
            public Random rand = new Random((int)DateTime.Now.Ticks);
            public string[] alph = { "а", "б", "в", "и", "у", "ж", "н", "я", };
            public string genName()
            {
                string name = "";
                for (int i = 0; i < rand.Next(3,10); i++)
                {
                    name += alph[rand.Next(alph.Length)];
                }
                return name;
            }
            public int genId()
            {
                bool f = false;
                while (f!=true)
                {
                    int id = rand.Next(100000, 1000000);
                    if (!ids.Contains(id))
                    {
                       f= true;
                       ids.Add(id);
                       return id;
                    }
                }
                return 0;
            }
        }
        class User : Global
        {
            public int id { get; }
            public string name { get; }
            public Card userCard { get; set; }

            public User()
            {
                id = genId();
                name = genName();
            }
            public void tellAbout()
            {
                Console.WriteLine($"Меня зовут {name}. Мой id: {id}. Я владею картой: {userCard.card4numbers}");
            }
            public void makeCard()
            {
                Console.Write("Введите пин-код для вашей новой карты:");
                userCard = new Card(this,Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Карта успешно выпущена!");
            }
        }
        class Card : Global
        {
            public User cardHolder { get; }
            public int card4numbers { get; }
            public int pin { get; set; }

            public Card(User cardHolder, int pin)
            {
                this.cardHolder = cardHolder;
                this.card4numbers = rand.Next(1000,10000);
                this.pin = pin;
            }

            public void tellAbout()
            {
                Console.WriteLine($"Инфо о карте:\n\t-Хозяин: {cardHolder.name} - {cardHolder.id}\n\t-4 цифры: {card4numbers}\n\t-пин-код: {pin}");
            }
        }
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new User());
                users[i].makeCard();
            }
            foreach (var u in users)
            {
                Console.WriteLine("\n");
                u.tellAbout();
                u.userCard.tellAbout();
            }
        }
    }
}
