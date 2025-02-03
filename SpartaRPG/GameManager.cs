using SpartaRPG.Class;
using SpartaRPG.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG
{
    public static class GameManager
    {
        public static string PlayerNameCreate()
        {
            string playerName;
            bool isConfirm = false;
            char confirm;
            do
            {
                Console.SetCursorPosition(0, 3);
                Console.Write("사용할 이름을 입력해주세요. \n>>");
                playerName = Console.ReadLine();

                Console.Clear();
                do
                {
                    Console.WriteLine($"{playerName}으로 결정하시겠습니까?");
                    Console.WriteLine("1. 네! \n2. 이름을 다시 정할래요!");

                    confirm = char.Parse(Console.ReadLine());
                    Console.Clear();
                    if (confirm == '1')
                    {
                        isConfirm = true;
                        Console.Clear();
                    }
                    else if (confirm == '2')
                    {
                        isConfirm = false;
                        Console.Clear();
                        Console.WriteLine("모험하기 전에 모험가님 이름을 알려주세요!");
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력하였습니다.");
                    }
                } while (!(confirm == '1' || confirm == '2'));
            } while (!isConfirm);

            return playerName;
        }
        public static IClass PlayerClass(string playerName)
        {
            IClass playerClass = null;
            string playerJob = " ";
            bool isConfirm = false;
            char confirm;
            int job = 0;
            
            do
            {
                Console.WriteLine($"{playerName}님 이제 직업을 선택해볼까요? {playerName}님은 어떤 직업을 선호하시나요?");
                Console.WriteLine("1. 전사(직업) \n\n2. 마법사 \n\n3. 도적 \n\n4. 코딩전사");
                job = int.Parse(Console.ReadLine()); ;
                Console.Clear();
                switch (job)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("전사를 선택하셨군요! 낭만적인 사람이군요?");
                        playerJob = "전사";  //playerClass = new Warrior();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("마법사를 선택하셨군요! 같이 적을 한방에 쓸어버리죠!");
                        playerJob = "마법사"; //palyerClass = new Magician();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("도적을 선택하셨군요! 이기는 것보단 상대를 화나게 하는데 재미를 느끼시는군요...");
                        Console.WriteLine("...뭐! 그래도 재밌는 직업이죠!");
                        playerJob = "암살자"; //palyerClass = new Assassin();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("코딩전사를 선택하셨군요...! 힘들긴하겠지만..모험가님이라면 할 수 있을거예요!");
                        playerJob = "코딩전사";  //palyerClass = new CodingWarrior();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.WriteLine("다시 선택해주세요");
                        break;
                }
                if (job <= 4 && job > 0)
                {
                    Console.WriteLine($"{playerJob}을/를 선택하였습니다. {playerJob}으로 결정하시겠습니까?");
                    Console.WriteLine("1. 네! \n2. 다시 고민해볼게요...!");

                    confirm = char.Parse(Console.ReadLine());
                    Console.Clear();

                    if (confirm == '1')
                    {
                        isConfirm = true;
                        Console.Clear();
                    }
                    else if (confirm == '2')
                    {
                        isConfirm = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력하였습니다.");
                    }
                }

            } while (!isConfirm);
            switch (playerJob)
            {
                case "전사":
                    playerClass = new Warrior();
                    break;
                case "마법사":
                    playerClass = new Magician();
                    break;
                case "암살자":
                    playerClass = new Assassin();
                    break;
                case "코딩전사":
                    playerClass = new CodingWarrior();
                    break;

            }
            return playerClass;

        }
    }
}
