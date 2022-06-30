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
            static public Random rand = new Random();
            public int genParam(int startPoint=3)
            {
                return rand.Next(startPoint,13);
            }
        }
        abstract class Rodent : Global
        {
            public int size;
            public string fullType;

            protected Rodent()
            {
                size = genParam();
            }
            public virtual void tellAbout()
            {
                Console.WriteLine($"Я - {fullType}. Мой размер: {size}");
            }
        }

        class Hamster : Rodent
        {
            public Hamster()
            {
                fullType = "Серый хомячок";
            }
        }

        class Vole : Rodent
        {
            public int weight;
            public int jump;

            public Vole()
            {
                fullType = "Поплевка";
                weight = genParam();
                jump = genParam(5);
            }

            public override void tellAbout()
            {
                base.tellAbout();
                Console.WriteLine($"Мой вес и прыжок: {weight}, {jump}");
            }
        }

        class Bobr : Rodent
        {
            public Bobr()
            {
                fullType = "Бобр добр";
            }
        }

        class Cat : Global
        {
            public List<Rodent> eaten = new List<Rodent>();
            public List<Hamster> held = new List<Hamster>();
            public string loved;

            public Cat()
            {
                loved = "Серый хомячок";
            }
            public void catching(List<Rodent> rodents)
            {
                for (int i = 0; i < rodents.Count; i++)
                {
                    if (rodents[i].size > 3)
                    {
                        if (rodents[i] is Vole vole && vole.weight >= 5 && vole.jump > 8)
                        {
                            habitCheck(i);
                        }
                        if (!(rodents[i] is Vole))
                        {
                            habitCheck(i);
                        }
                    }
                }

                void habitCheck(int i)
                {
                    if (rodents[i] is Hamster hamst)
                    {
                        hamst.tellAbout();
                        held.Add(hamst);
                    }
                    if (!(rodents[i] is Hamster))
                    {
                        eaten.Add(rodents[i]);
                    }
                    rodents.RemoveAt(i);
                }
            }
            
        }

        static void Main(string[] args)
        {
            List<Rodent> rodents = new List<Rodent>();
            for (int i = 0; i < 10; i++)
            {
                rodents.Add(new Vole());
            }
            for (int i = 0; i < 10; i++)
            {
                rodents.Add(new Hamster());
            }
            for (int i = 0; i < 10; i++)
            {
                rodents.Add(new Bobr());
            }

            Cat cat = new Cat();
            cat.catching(rodents);
        }
    }
}
