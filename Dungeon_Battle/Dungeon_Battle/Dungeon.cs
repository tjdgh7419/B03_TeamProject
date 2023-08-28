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
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP 100 / {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 1);

			switch (input)
			{
				case 1: MonsterSelect(); break;
			}
		}

		public void MonsterSelect()
		{
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				Console.WriteLine($"{i + 1} Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
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
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 1: PlayerAtkStage(dp.monsterlist[0]); break;
				case 2: PlayerAtkStage(dp.monsterlist[1]); break;
				case 3: PlayerAtkStage(dp.monsterlist[2]); break;
			}
		}

		public void PlayerAtkStage(Monster monster)
		{
			Random playerAtk = new Random();
			int monsterHp = monster.Hp;
			double error = (dp.player.Atk / (double)100) * 10;
			int Error = (int)Math.Ceiling(error);
			int player_Atk = playerAtk.Next(dp.player.Atk - Error, dp.player.Atk + Error + 1);
			monster.Hp -= player_Atk;
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			Console.WriteLine($"{dp.player.Name} 의 공격!");
			Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
			Console.WriteLine();
			Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
			if (monster.Hp > 0) Console.WriteLine($"HP {monsterHp} -> {monster.Hp}");
			else Console.WriteLine($"HP {monsterHp} -> Dead");
			Console.WriteLine();
			Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 0: MonsterAtkStage(); break;
			}
		}

		public void MonsterAtkStage()
		{
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				Random monsterAtk = new Random();
				int playerHp = dp.player.Hp;
				double error = (dp.monsterlist[i].Atk / (double)100) * 10;
				int Error = (int)Math.Ceiling(error);
				int monster_Atk = monsterAtk.Next(dp.monsterlist[i].Atk - Error, dp.monsterlist[i].Atk + Error + 1);
				dp.player.Hp -= monster_Atk;
				Console.Clear();
				Console.WriteLine("Battle!!");
				Console.WriteLine();
				Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} 의 공격!");
				Console.WriteLine($"Lv.{dp.player.Name} 을(를) 맞췄습니다. [데미지 : {monster_Atk}]");
				Console.WriteLine();
				Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
				if (dp.player.Hp > 0) Console.WriteLine($"HP {playerHp} -> {dp.player.Hp}");
				else Console.WriteLine($"HP {dp.player.Hp} -> Dead");
				Console.WriteLine();
				Console.WriteLine("0. 다음");
				Console.WriteLine();
				Console.Write(">>");

				int input = dp.CheckValidInput(0, 0);

				switch (input)
				{
					case 0: break;
				}
			}
			MonsterSelect();

			
		}


	}
}
