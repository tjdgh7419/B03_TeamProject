using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	internal class Bandit
	{
		public string skill1 { get; set; }
		public string skill2 { get; set; }
		public string skill1Info { get; set; }
		public string skill2Info { get; set; }
		public Bandit()
		{
			skill1 = "찌르기";
			skill2 = "숨기";
			skill1Info = "공격력 * 1.3으로 하나의 적을 공격합니다.";
			skill2Info = "회피율이 20% 증가합니다.";
		}

		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public int skill_1()
		{
			return (int)(dp.player.Atk * 1.3);
		}
	}
}
