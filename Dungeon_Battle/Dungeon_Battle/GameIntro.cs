using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    internal class DisplayGameIntro
    {
        public void GameIntro()
        { 
        Console.Clear();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine();
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("3. 던전 입장");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("4. 종료");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");


            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:

                    Console.Clear();
                    Console.WriteLine("Status");
                    break;

                case ConsoleKey.D2:
                    
                    Console.Clear();
                    Console.WriteLine("Inventory");
                    break;

                case ConsoleKey.D3:
                    
                    Console.Clear();
                    Console.WriteLine("Dungeon");
                    break;

                case ConsoleKey.D4:

                    Console.Clear();
                    Console.WriteLine("종료하기");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    
                    break;
            }

        }
    }
}
