using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class Dungeon
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		bool deadChk = false;
		
		public void BattleStage()
		{
			Stage stage = new Stage();
			stage.Stage2();
		}

		public void SkillSelect(Skill job)
		{
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
			Console.WriteLine($"HP 100 / {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine($"1. {job.skill1} - MP {job.skill1Cost}");
			Console.WriteLine($"{job.skill1Info}");
			Console.WriteLine();
			Console.WriteLine($"2. {job.skill2} - MP {job.skill2Cost}");
			Console.WriteLine($"{job.skill2Info}");
			Console.WriteLine();
			Console.WriteLine("0. 취소");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 2);

			switch (input)
			{
				case 1: job.skill_1(); break;
				case 2: job.skill_2(); break;
				case 0: BattleStage(); break;
					
			}
		}

		public void MonsterSelect()
		{
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
					Console.WriteLine($"{i + 1}. Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} HP {dp.monsterlist[i].Hp}");
				else
				{
					Console.WriteLine($"{i + 1}. Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} Dead");	
				}
			}
			
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[내정보]");
			Console.WriteLine($"Lv.{dp.player.Level}  {dp.player.Name} ({dp.player.Job})");
			Console.WriteLine($"HP 100 / {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("1. 공격");
			Console.WriteLine();
			Console.WriteLine("대상을 선택해주세요.");
			Console.Write(">>");
			if(deadChk) Console.WriteLine("잘못된 입력입니다.");
			deadChk = false;
            int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 1:
					if (dp.monsterlist[0].Hp > 0) PlayerAtkStage(dp.monsterlist[0], dp.player.Atk);
					else deadChk = true; MonsterSelect(); break;
				case 2:
					if (dp.monsterlist[1].Hp > 0) PlayerAtkStage(dp.monsterlist[1], dp.player.Atk);
					else deadChk = true; MonsterSelect(); break;
				case 3:
					if (dp.monsterlist[2].Hp > 0) PlayerAtkStage(dp.monsterlist[2], dp.player.Atk);
					else deadChk = true; MonsterSelect(); break;
			}
		}

		public void PlayerAtkStage(Monster monster, int Atk)
		{
			Random playerAtk = new Random();
			int monsterHp = monster.Hp;
			double error = (Atk / (double)100) * 10;
			int Error = (int)Math.Ceiling(error);
			int player_Atk = playerAtk.Next(Atk - Error, Atk + Error + 1);
			
			Console.Clear();
			Console.WriteLine("Battle!!");
			Console.WriteLine();
			Console.WriteLine($"{dp.player.Name} 의 공격!");

            if (playerAtk.Next(100) <= 90)//공격 성공률
            {
                if (playerAtk.Next(100) <= 15)
                {
                    player_Atk = (int)(player_Atk * 1.6); // 크리티컬 데미지 증가
                    monster.Hp -= player_Atk;
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]-치명타 공격!");

                }
                else
                {
                    monster.Hp -= player_Atk;
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player_Atk}]");
                }
            }
            else
            {
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
            }

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
			int deadCnt = 0;
			for (int i = 0; i < dp.monsterlist.Count; i++)
			{
				if (dp.monsterlist[i].Hp > 0)
				{
					Random monsterAtk = new Random();
					int playerHp = dp.player.Hp;
					double error = (dp.monsterlist[i].Atk / (double)100) * 10;
					int Error = (int)Math.Ceiling(error);
					int monster_Atk = monsterAtk.Next(dp.monsterlist[i].Atk - Error, dp.monsterlist[i].Atk + Error + 1);

					
					Console.Clear();
					Console.WriteLine("Battle!!");
					Console.WriteLine();
					Console.WriteLine($"Lv.{dp.monsterlist[i].Level} {dp.monsterlist[i].Name} 의 공격!");

                    if (monsterAtk.Next(100) <= 90)
                    {
                        if (monsterAtk.Next(100) <= 15)
                        {
                            monster_Atk = (int)(monster_Atk * 1.6); // 크리티컬 데미지 증가
                            dp.player.Hp -= monster_Atk;

                            Console.WriteLine($"Lv.{dp.player.Name} 을(를) 맞췄습니다. [데미지 : {monster_Atk}]-치명타 공격!");
                        }
                        else
                        {
                            dp.player.Hp -= monster_Atk;
                            Console.WriteLine($"Lv.{dp.player.Name} 을(를) 맞췄습니다. [데미지 : {monster_Atk}]");
                        }
                    }
                    else
                    {

                        Console.WriteLine($"Lv.{dp.player.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                    }


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
				else
				deadCnt ++;
			}

			if (deadCnt == 3) Victory();
			else if (dp.player.Hp <= 0) Lose(); 
			BattleStage();
		}

		public void Victory()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("Victory");
			Console.WriteLine();
			Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.");
			Console.WriteLine();
			Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
			Console.WriteLine($"HP {dp.player.OriHp} -> {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");
			dp.minion.Hp = 15;
			dp.cannonminion.Hp = 25;
			dp.emptyworm.Hp = 10;
			
			int input = dp.CheckValidInput(0, 0);

			switch (input)
			{
				case 0: dp.GameIntro(); break;
			}
		}

		public void Lose()
		{
			dp.player.Hp = 0;
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("You Lose");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Lv.{dp.player.Level} {dp.player.Name}");
			Console.WriteLine($"HP {dp.player.OriHp} -> {dp.player.Hp}");
			Console.WriteLine();
			Console.WriteLine("0. 다음");
			Console.WriteLine();
			Console.Write(">>");
			dp.minion.Hp = 15;
			dp.cannonminion.Hp = 25;
			dp.emptyworm.Hp = 10;

			int input = dp.CheckValidInput(0, 0);

			switch (input)
			{
				case 0: dp.GameIntro(); break;
			}
		}
	}
}
