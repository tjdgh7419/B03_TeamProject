using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Dungeon
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void BattleStage()
		{
			Console.Clear();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {100/dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.WriteLine(">>");

			int input = dp.CheckValidInput(0, 1);

			switch (input)
			{
				case 1: ;
			}
		}

		public void MonsterSelect()
		{
			Console.Clear();
			for(int i = 0; i < dp.monsterlist.Count; i++)
			{
				Console.WriteLine($"{i} Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");			
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {100 / dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.WriteLine(">>");

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 1:	AtkStage(dp.monsterlist[0]);break;
				case 2: AtkStage(dp.monsterlist[1]); break;
				case 3: AtkStage(dp.monsterlist[2]); break; 
			}
		}

		public void AtkStage(Monster monter)
		{

		}
	}
}
