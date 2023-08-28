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
			Console.WriteLine($"Lv.{dp.minion.Level} {dp.minion.Name} HP {dp.minion.Hp}");
			Console.WriteLine($"Lv.{dp.cannonminion.Level} {dp.cannonminion.Name} HP {dp.cannonminion.Hp}");
			Console.WriteLine($"Lv.{dp.emptyworm.Level} {dp.emptyworm.Name} HP {dp.emptyworm.Hp}");
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
	}
}
