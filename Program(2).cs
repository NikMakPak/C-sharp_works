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
            public string[] skills = { "скорость", "прозрачность", "сила", "здоровье" };
            public int genParam(int startPoint=0)
            {
                return rand.Next(startPoint,13);
            }
            static public void doMix(List<Rodent> origin)
            {
                for (int i = 0; i < origin.Count; i++)
                {
                    var elem = origin[0];
                    origin.RemoveAt(0);
                    origin.Insert(rand.Next(origin.Count), elem);
                }
            }
        }
        abstract class Rodent : Global
        {
            public int runSpeed;
            public string fullType;

            protected Rodent()
            {
                runSpeed = genParam();
            }
        }

        class KyrgMouse : Rodent
        {
            public KyrgMouse()
            {
                fullType = "курганчиковая мышь";
            }
        }

        class NewAtrib
        {
            string name;
            int param;

            public NewAtrib(string name, int param)
            {
                this.name = name;
                this.param = param;
            }
        }

        class MalMouse : Rodent
        {
            public int claws, wool, size;
            public List<NewAtrib> newAtribs = new List<NewAtrib>();
            public MalMouse()
            {
                claws = genParam();
                wool = genParam();
                size = genParam();
                fullType = "малоазийская мышь";
            }

            public void addRandomAtrib()
            {
                newAtribs.Add(new NewAtrib(skills[rand.Next(skills.Length)], genParam()));
            }
        }

        class Vole : Rodent
        {
            public int claws;

            public Vole()
            {
                fullType = "обыкновенная поплевка";
                claws = genParam();
            }
        }
        
        class Cat : Global
        {
            public List<Rodent> caught = new List<Rodent>();
            public bool isCatching = true;
            public string loved;

            public Cat()
            {
                loved = "малоазийская мышь";
            }
            public void catching(List<Rodent> rodents)
            {
                for (int i = 0; i < rodents.Count; i++)
                {
                    if (rodents[i].runSpeed > 2 && isCatching)
                    {
                        habitCheck(i);
                    }
                }

                void habitCheck(int i)
                {
                    if (rodents[i] is MalMouse mouse)
                    {
                        mouse.addRandomAtrib();
                        caught.Add(mouse);
                        isCatching = false;
                    }
                    else
                    {
                        caught.Add(rodents[i]);
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
                rodents.Add(new KyrgMouse());
            }
            for (int i = 0; i < 10; i++)
            {
                rodents.Add(new MalMouse());
            }

            Cat cat = new Cat();
            Global.doMix(rodents);
            cat.catching(rodents);
        }
    }
}
