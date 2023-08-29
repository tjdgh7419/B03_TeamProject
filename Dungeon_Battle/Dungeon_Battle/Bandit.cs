using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Bandit : Skill
	{
		public string skill1 { get; set; }
		public string skill2 { get; set; }
		public string skill1Info { get; set; }
		public string skill2Info { get; set; }
		public int skill1Cost { get; set; }
		public int skill2Cost { get; set; }
		public Bandit()
		{
			skill1 = "찌르기";
			skill2 = "숨기";
			skill1Info = "공격력 * 1.3으로 하나의 적을 공격합니다.";
			skill2Info = "회피율이 20% 증가합니다.";
			skill1Cost = 10;
			skill2Cost = 20;
		}

		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void skill_1()
		{
			dp.player.Mp -= skill1Cost;
            Console.WriteLine("도적 스킬입니다");
        }

		public void skill_2()
		{
			dp.player.Mp -= skill2Cost;
			dp.player.Avoidance += 2;
            Console.WriteLine("도적 스킬2입니다");
        }
	}
}
