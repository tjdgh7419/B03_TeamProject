using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dungeon_Battle.IItem;

namespace Dungeon_Battle
{
    public class IItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public IItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} (x{Quantity})";
        }
    }


    public class HealthPotion : IItem
    {
        public HealthPotion(string name, int quantity) : base(name, quantity)
        {
        }

        public string Name => "Health Potion";

        
        public void Use(Player player)
        {
            player.Hp += 20;
            Console.WriteLine($"{player.Name}의 체력이 20만큼 회복했습니다!");
        }
    }

    public class StrengthPotion : IItem
    {
        public StrengthPotion(string name, int quantity) : base(name, quantity)
        {
        }

        public string Name => "Strength Potion";

        public void Use(Player player)
        {


            player.Atk += 5;  // 공격력을 5만큼 증가시킵니다.
            Console.WriteLine($"{player.Name}의 공격력이 5만큼 증가했습니다!");
            throw new NotImplementedException();
        }
    }
}
