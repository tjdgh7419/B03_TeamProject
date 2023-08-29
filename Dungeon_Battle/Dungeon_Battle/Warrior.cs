using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Warrior : Skill
	{
		public string skill1 { get; set; }
		public string skill2 { get; set; }
		public string skill1Info { get; set; }
		public string skill2Info { get; set; }
		public int skill1Cost { get; set; }
		public int skill2Cost { get; set; }
		public Warrior()
		{
			skill1 = "알파 스트라이크";
			skill2 = "더블 스트라이크";
			skill1Info = "공격력 * 2 로 하나의 적을 공격합니다.";
			skill2Info = "공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.";
			skill1Cost = 10;
			skill2Cost = 15;
		}

		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void skill_1()
		{
			bool deadChk = false;
			Dungeon dungeon = new Dungeon();
			int skill1Atk = dp.player.Atk * 2;
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
					Console.WriteLine($"{i + 1} Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"{i + 1} Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} Dead");
				}
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("대상을 선택해주세요.");
			Console.Write(">>");
			if (deadChk) Console.WriteLine("잘못된 입력입니다.");
			deadChk = false;

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 1:
					if (dp.monsterlist[0].Hp > 0)
					{
						dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(dp.monsterlist[0], skill1Atk);
					}
					else deadChk = true; skill_1(); break;
				case 2:
					if (dp.monsterlist[1].Hp > 0)
					{
						dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(dp.monsterlist[1], skill1Atk);
					}
					else deadChk = true; skill_1(); break;
				case 3:
					if (dp.monsterlist[2].Hp > 0)
					{
						dp.player.Mp -= skill1Cost; dungeon.PlayerAtkStage(dp.monsterlist[2], skill1Atk);
					}
					else deadChk = true; skill_1(); break;
			}


		}

		public void skill_2()
		{
			Dungeon dg = new Dungeon();
			dp.player.Mp -= skill2Cost;
			int monsterHp = 0;
			double error = 0;
			int Error = 0;
			int player_Atk = 0;
			int monsterCnt = 0;
			var deadExclude = new HashSet<int>();
			List<int> liveMonster = new List<int>();
			Random playerAtk = new Random();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp < 0)
				{
					deadExclude.Add(i);
				}
				else
				{
					monsterCnt++;
					liveMonster.Add(i);
				}
			}

			if (monsterCnt <= 2)
			{
				int cnt = 0;
				foreach (int num in liveMonster)
				{
					cnt++;
					monsterHp = dp.monsterlist[num].Hp;
					error = (dp.player.Atk / (double)100) * 10;
					Error = (int)Math.Ceiling(error);
					player_Atk = playerAtk.Next(dp.player.Atk - Error, dp.player.Atk + Error + 1);
					dp.monsterlist[num].Hp -= player_Atk;
					Console.Clear();
					Console.WriteLine("Battle!!");
					Console.WriteLine();
					Console.WriteLine($"{dp.player.Name} 의 공격!");
					Console.WriteLine($"Lv.{dp.monsterlist[num].Level} {dp.monsterlist[num].Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
					Console.WriteLine();
					Console.WriteLine($"Lv.{dp.monsterlist[num].Level} {dp.monsterlist[num].Name}");
					if (dp.monsterlist[num].Hp > 0) Console.WriteLine($"HP {monsterHp} -> {dp.monsterlist[num].Hp}");
					else Console.WriteLine($"HP {monsterHp} -> Dead");
					Console.WriteLine();
					Console.WriteLine("0. 다음");
					Console.WriteLine();
					Console.Write(">>");

					if (cnt == liveMonster.Count - 1)
					{
						int input1 = dp.CheckValidInput(0, 0);

						switch (input1)
						{
							case 0: break;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					var range = Enumerable.Range(0, dp.monsterlist.Count).Where(i => !deadExclude.Contains(i));
					var monRand = new System.Random();
					int index = monRand.Next(0, (dp.monsterlist.Count) - deadExclude.Count);
					int monVal = range.ElementAt(index);
					deadExclude.Add(index);

					monsterHp = dp.monsterlist[monVal].Hp;
					error = (dp.player.Atk / (double)100) * 10;
					Error = (int)Math.Ceiling(error);
					player_Atk = playerAtk.Next(dp.player.Atk - Error, dp.player.Atk + Error + 1);
					dp.monsterlist[monVal].Hp -= player_Atk;
					Console.Clear();
					Console.WriteLine("Battle!!");
					Console.WriteLine();
					Console.WriteLine($"{dp.player.Name} 의 공격!");
					Console.WriteLine($"Lv.{dp.monsterlist[monVal].Level} {dp.monsterlist[monVal].Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
					Console.WriteLine();
					Console.WriteLine($"Lv.{dp.monsterlist[monVal].Level} {dp.monsterlist[monVal].Name}");
					if (dp.monsterlist[monVal].Hp > 0) Console.WriteLine($"HP {monsterHp} -> {dp.monsterlist[monVal].Hp}");
					else Console.WriteLine($"HP {monsterHp} -> Dead");
					Console.WriteLine();
					Console.WriteLine("0. 다음");
					Console.WriteLine();
					Console.Write(">>");


					if (i == 0)
					{
						int input2 = dp.CheckValidInput(0, 0);
						switch (input2)
						{
							case 0: break;
						}
					}
				}
			}

			int input = dp.CheckValidInput(0, 0);

			switch (input)
			{
				case 0: dg.MonsterAtkStage(); break;
			}
		}
	}
}
