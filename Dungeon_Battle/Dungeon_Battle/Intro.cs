using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    internal class Intro
    {

        public void ShowIntro()
        {
            JobSelect jobSelect = new JobSelect();
            Console.Title = "Dungeon_Battle";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================================================");
            Console.WriteLine();
            Console.WriteLine("                            Dungeon_Battle                                          ");
            Console.WriteLine("DOWA team");
            Console.WriteLine("====================================================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                               1. New Game");
            Console.WriteLine();
            Console.WriteLine("                               2. Load Game");
            Console.WriteLine();
            Console.WriteLine("                               3. Quit");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================================================================================");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    jobSelect.Job_Select();                 
                    break;
                case ConsoleKey.D2:
                    
                    LoadGame();
                    break;
                case ConsoleKey.D3:
                    
                    QuitGame();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    ShowIntro();
                    break;
            }
        }

        private static void NewGame()
        {
            Console.WriteLine("새로운 게임 시작하는 중...");
            DisplayGameIntro displayIntro = new DisplayGameIntro();
            displayIntro.GameIntro();
        }

        private static void LoadGame()
        {
            Console.WriteLine("세이브 된 파일 불러오는중...");
        }

        private static void QuitGame()
        {
            Console.WriteLine("게임 나가는중...");
            Environment.Exit(0);
        }
    }

}
