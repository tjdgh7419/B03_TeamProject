using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Dungeon_Battle
{
    internal class Inventory
    {
        private List<IItem> items = new List<IItem>();

        // 생성자에서 체력 포션 3개 추가
        public Inventory()
        {
            items.Add(new IItem("Health Potion", 3));
        }

        public void AddItem(string name, int quantity)
        {
            var existingItem = items.Find(item => item.Name == name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new IItem(name, quantity));
            }
        }

        public void ShowInventory()
        {
            foreach (var item in items)
            {
                System.Console.WriteLine(item.ToString());
            }
        }

        public static void Main()
        {
            Inventory myInventory = new Inventory();
          
            myInventory.AddItem("HealthPotion", 3);  // 체력포션의 수량이 증가해야 합니다.

            myInventory.ShowInventory();
        }
    }



}
