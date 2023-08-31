using Dungeon_Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNewCharacter;

public class CreateNewCharater
{
	DisplayGameIntro dp = DisplayGameIntro.Instance();
	public void Create_NewCharacter() // 메인 함수에서만 쓰는 코드
	{
		Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
		Console.Write("원하시는 이름을 설정해주세요.\n>> ");

		string playerName = Console.ReadLine();

		Console.WriteLine($"당신이 선택한 이름은 {playerName}입니다.");
   
    }
}