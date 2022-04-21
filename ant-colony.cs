using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ants_colony_2
{
    abstract class Ant
    {
        public string name;
        public int hp, def, dmg;

        public Ant(string name, int hp, int def, int dmg)
        {
            this.name = name;
            this.hp = hp;
            this.def = def;
            this.dmg = dmg;
        }
        public virtual void About()
        {
            Console.WriteLine($"\n==========={GetType().Name}===========");
            Console.WriteLine($"здоровье = {hp}, защита = {def}, урон = {dmg}");
        }
    }
    class Queen : Ant
    {
        public int queensLimit;
        public int[] growthCycle;
        public Queen(string name, int hp, int def, int dmg,int[] growthCycle, int queensLimit) : base(name, hp, def, dmg)
        {
            this.queensLimit = queensLimit;
            this.growthCycle = growthCycle;
        }

        public override void About()
        {
            base.About();
            Console.WriteLine($"Имя: {name}");
        }

    }
    class Stack
    {
        public int number;
        public int[] resources;

        public Stack(int number, int[] resources)
        {
            this.number = number;
            this.resources = resources;
        }

        public void About()
        {
            if (resources.Sum() >0)
            {
                Console.WriteLine($"Куча { number}: " + (resources[0] == 0 ? "" : $"веточка: {resources[0]}; ") + (resources[1] == 0 ? "" : $"камушек: {resources[1]}; ") + (resources[2] == 0 ? "" : $"росинка: {resources[2]};"));
            }
            else
            {
                Console.WriteLine($"Куча {number} пуста");
            }
        }
    }
    class Program
    {
        static int Rand(int start, int end)
        { 
            Random rand = new Random();
            return rand.Next(start,end+1);
        }
        static void Main(string[] args)
        {
            Queen q1 = new Queen("феодора", 16, 6, 25,new int[] {2,5},3);
            Stack st1 = new Stack(1, new int[] { 0, 0, 1 });
            st1.About();
            q1.About();
            Console.WriteLine(Rand(q1.growthCycle[0], q1.growthCycle[1]));
        }
    }
}
