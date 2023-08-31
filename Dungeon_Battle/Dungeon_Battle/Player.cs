﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Player
	{
		public string Name { get; set; }
		public string Job { get; }
		public int Level { get; }
		public int Atk { get; }
		public int Def { get; }
		public int Hp { get; }
		public int Gold { get; }

		public Player(string name, string job, int level, int atk, int def, int hp, int gold)
		{
			Name = name;
			Job = job;
			Level = level;
			Atk = atk;
			Def = def;
			Hp = hp;
			Gold = gold;
		}
	}
}
