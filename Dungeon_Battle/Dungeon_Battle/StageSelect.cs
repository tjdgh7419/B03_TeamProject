using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class StageSelect
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void Stage_Select()
		{
			Console.WriteLine("해금된 층");
			Console.WriteLine();
			Console.WriteLine("1층");
			Console.WriteLine();
			Console.WriteLine("2층");
			Console.WriteLine();
			Console.WriteLine("3층");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 층을 선택해주세요");
			Console.Write(">>");

			int input = dp.CheckValidInput(0, 3);

			switch (input)
			{
				case 0: dp.GameIntro(); break;

			}
		}
	}
}
