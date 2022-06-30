using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_training
{
    internal class Program
    {
        abstract public class Global
        {
            static public string[] colors = { "белого", "желтого","синего", "красного", "оранжегого", "зеленого", "голубого", "фиолетогого", "серого", "прозрачного" };
            static public Random rand = new Random((int)DateTime.Now.Ticks);
            static public string[] types = { "жирный котэ", "сибирский", "уральский", "домашний" };
            static public MutantCat goFunnel(List<CatProt> cats)
            {
                string color = "{ ";
                string type = "{ ";
                List<Skill> abilities = new List<Skill> { };
                for (int i = 0; i < cats.Count; i++)
                {
                    if (cats[i] is Cat cat)
                    {
                        color += cat.color + ", ";
                        type += cat.type + ", ";
                        foreach (Skill skill in cat.abilities)
                        {
                            abilities.Add(skill);
                        }
                    }
                    else if (cats[i] is MutantCat mCat)
                    {
                        color += mCat.color + ", ";
                        type += mCat.type + ", ";
                        foreach (Skill skill in mCat.abilities)
                        {
                            abilities.Add(skill);
                        }
                    }
                }
                color += " }";
                type += " }";
                return new MutantCat(color, type, abilities);
            }
        }
        public class Skill : Global
        {
            string skill;

            public Skill()
            {
                this.skill = genSkill();
            }

            public void printInfo()
            {
                Console.WriteLine($"- {skill}");
            }
            string genSkill()
            {
                return $"ловить {rand.Next(201)} бабочек {colors[rand.Next(201) % (colors.Length)]} цвета";
            }
        }

        abstract public class CatProt : Global
        {
            public string color, type;
            public int weight;
            public List<Skill> abilities = new List<Skill> ();

            public void play()
            {
                Console.WriteLine("Я играю");
            }
            public void mya()
            {
                Console.WriteLine("Я мяукаю");
            }
            public void tellAbout()
            {
                Console.WriteLine($"Я кот типа {type}; {color} цвета; с весом {weight} кг");
                Console.WriteLine("Я умею:");
                if (abilities.Count>0)
                {
                    foreach (Skill skill in abilities)
                    {
                        skill.printInfo();
                    }
                }
                else
                {
                    Console.WriteLine("- пока ничего :(");
                }
            }
            public void trainSkill()
            {
                if (rand.Next(10)>5)
                {
                    abilities.Add(new Skill());
                }
            }
        }

        public class Cat : CatProt
        {
            public Cat()
            {
                this.color = colors[rand.Next(100) % (colors.Length)];
                this.type = types[rand.Next(100) % (types.Length)];
                this.weight = rand.Next(10, 51);
                trainSkill();
            }
        }

        public class MutantCat : CatProt
        {
            public MutantCat(string color, string type, List<Skill> abilities)
            {
                this.color = color;
                this.type = type;
                this.weight = rand.Next(10, 51);
                this.abilities = abilities;
            }
        }

        static void Main(string[] args)
        {
            
            action(10);
            action(100);
            action(1000);


            void action(int maxRange)
            {
                // создание кучи котов
                List<CatProt> catsHeap = new List<CatProt> { };
                for (int i = 0; i < maxRange + 10; i++)
                {
                    catsHeap.Add(new Cat());
                }

                int mixCount = 0;
                while (mixCount < maxRange)
                {
                    // создание группы котов в воронку
                    int range = Global.rand.Next(1, catsHeap.Count / 2);
                    int index = Global.rand.Next((catsHeap.Count - range < 0) ? 0 : catsHeap.Count - range);
                    //int range = 2;
                    //int index = catsHeap.Count - 2;
                    List<CatProt> group = catsHeap.GetRange(index, range);
                    catsHeap.RemoveRange(index, range);
                    mixCount += range;

                    // отправка и принятие в воронку
                    catsHeap.Add(Global.goFunnel(group));
                }
                
                Console.WriteLine($"\n#####\nПри смешивании {maxRange} кошек:");
                int n = 0;
                foreach (MutantCat mut in catsHeap.FindAll(x => x.GetType().Name == "MutantCat"))
                {
                    n++;
                    Console.WriteLine($"\n\t#{n})");
                    mut.tellAbout();
                }

            }
            
        }
            
    }
}
