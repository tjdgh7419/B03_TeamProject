using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Stage
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		Dungeon dungeon = new Dungeon();
		Warrior warrior = new Warrior();
		Bandit bandit = new Bandit();
		Wizard wizard = new Wizard();
		public void Stage1()
		{
			bool skillOn = false;
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();

			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} Dead");
				}
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit);
					else dungeon.SkillSelect(wizard);
					break;
			}
		}

		public void Stage2()
		{
			bool skillOn = false;
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			Random monRan = new Random();
			List<Monster> monList = new List<Monster>();
			var normalSet = new HashSet<int>();
			var hardSet = new HashSet<int>();
			int monLvlChk = monRan.Next(0, 2);

			if(monLvlChk == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					int a = monRan.Next(0, dp.monsterlist.Count - normalSet.Count);
					var nRange = Enumerable.Range(0, dp.monsterlist.Count).Where(i => !normalSet.Contains(i));
					int nVal = nRange.ElementAt(a);
					monList.Add(dp.monsterlist[nVal]);
					normalSet.Add(nVal);
				}
				int b = monRan.Next(0, dp.hardMonsterlist.Count);
				monList.Add(dp.hardMonsterlist[b]);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					int c = monRan.Next(0, dp.hardMonsterlist.Count - hardSet.Count);
					var hRange = Enumerable.Range(0, dp.hardMonsterlist.Count).Where(i => !hardSet.Contains(i));
					int hVal = hRange.ElementAt(c);
					monList.Add(dp.hardMonsterlist[hVal]);
					hardSet.Add(hVal);
				}
				int d = monRan.Next(0, dp.monsterlist.Count);
				monList.Add(dp.monsterlist[d]);
			}
			
			foreach (Monster val in monList) 
			{
				if (val.Hp > 0)
					Console.WriteLine($"Lv.{val.Level} {val.Name} HP {val.Hp}");
				else
				{
					Console.WriteLine($"Lv.{val.Level} {val.Name} Dead");
				}
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit);
					else dungeon.SkillSelect(wizard);
					break;
			}
		}

		public void Stage3()
		{
			bool skillOn = false;
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();

			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} Dead");
				}
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP {dp.player.OriHp} / {dp.player.Hp}");
			Console.WriteLine($"MP {dp.player.OriMp} / {dp.player.Mp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine("2. 스킬");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 2);

			switch (input)
			{
				case 1: dungeon.MonsterSelect(); break;
				case 2:
					if (dp.player.Job == "전사") dungeon.SkillSelect(warrior);
					else if (dp.player.Job == "도적") dungeon.SkillSelect(bandit);
					else dungeon.SkillSelect(wizard);
					break;
			}
		}
	}
}
