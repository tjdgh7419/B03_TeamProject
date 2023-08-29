using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Wizard : Skill
	{
		public string skill1 { get; set; }
		public string skill2 { get; set; }
		public string skill1Info { get; set; }
		public string skill2Info { get; set; }
		public int skill1Cost { get; set; }
		public int skill2Cost { get; set; }

		public Wizard()
		{
			skill1 = "화염구";
			skill2 = "불기둥";
			skill1Info = "공격력 * 2.5 로 하나의 적을 공격합니다.";
			skill2Info = "전체 몬스터를 공격력 * 1.2 로 공격합니다.";
			skill1Cost = 20;
			skill2Cost = 25;
		}


		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void skill_1()
		{
			bool deadChk = false;
			Dungeon dungeon = new Dungeon();
			int skill1Atk = (int)(dp.player.Atk * 2.5);
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
			Dungeon dungeon = new Dungeon();	
			int skill2Atk = (int)(dp.player.Atk * 1.2);
			Random playerAtk = new Random();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
				{
					int monsterHp = dp.monsterlist[i].Hp;
					double error = (skill2Atk / (double)100) * 10;
					int Error = (int)Math.Ceiling(error);
					int player_Atk = playerAtk.Next(skill2Atk - Error, skill2Atk + Error + 1);
					dp.monsterlist[i].Hp -= player_Atk;
					Console.Clear();
					Console.WriteLine("Battle!!");
					Console.WriteLine();
					Console.WriteLine($"{dp.player.Name} 의 공격!");
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
					Console.WriteLine();
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name}");
					if (dp.monsterlist[i].Hp > 0) Console.WriteLine($"HP {monsterHp} -> {dp.monsterlist[i].Hp}");
					else Console.WriteLine($"HP {monsterHp} -> Dead");
					Console.WriteLine();
					Console.WriteLine("0. 다음");
					Console.WriteLine();
					Console.Write(">>");

					if (i != dp.monsterlist.Count - 1)
					{
						int input = dp.CheckValidInput(0, 3);

						switch (input)
						{
							case 0: break;
						}
					}
				}
			}
			int input1 = dp.CheckValidInput(0, 3);

			switch (input1)
			{
				case 0: dungeon.MonsterAtkStage(); break;
			}
		}
	}
}

