namespace _Yuseop__Status
{
    class Program
    {
        static Character player;


        static void Main(string[] args)
        {
            DataSetting();
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + player.Level);
            Console.WriteLine("공격력 : " + player.Atk);
            Console.WriteLine("방어력 : " + player.Def);
            Console.WriteLine("체 력 : " + player.Hp);
            Console.WriteLine("Gold :" + player.Gold);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int x))
            {
                if (x == 0)
                {
                    // 메인화면
                    DisplayMainMenu();
                }
                else
                {
                    //error
                    Console.WriteLine("잘못 입력하셨습니다.");
                }
            }
        }
    }
}

    //참조 형식
class Character
{
      public int Level;
      public string Name;
      public string Job;
      public int Atk;
      public int Def;
      public int Hp;
      public int Gold;

      public Character(string name, string job, int level, int atk, int def, int hp, int gold)
      {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
      }
}