using System.Numerics;

namespace SpartaRPG
{
    internal class MainSystem
    {
        static void Main(string[] args)
        {
            //변수 설정
            string[] jobs = { "전사", "마법사", "도적", "코딩전사" };
            Player player = new Player();
            bool isConfirm = false;
            string confirm;

            //게임 내부
            #region 이름설정 및 결정
            Console.WriteLine("모험가님 안녕하세요~ 아르칸디아에 오신 것을 환영해요~!");
            Console.WriteLine("모험하기 전에 모험가님 이름을 알려주세요! : ");

            do
            {

                player.playerName = Console.ReadLine();
                do
                {
                    Console.WriteLine($"{player.playerName}으로 결정하시겠습니까?");
                    Console.WriteLine(" 1. 네! \n 2. 이름을 다시 정할래요!");

                    confirm = Console.ReadLine();
                    Console.Clear();
                    if (confirm == "1")
                    {
                        isConfirm = true;
                        Console.Clear();
                    }
                    else if (confirm == "2")
                    {
                        isConfirm = false;
                        Console.Clear();
                        Console.WriteLine("모험하기 전에 모험가님 이름을 알려주세요! : ");
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력하였습니다.");
                    }
                } while (!(confirm == "1" || confirm == "2"));
            } while (!isConfirm);
            #endregion

            isConfirm = false;  //재결정 의사를 다시 물을 것이기 때문에, false로 초기화
            Console.WriteLine($"와! 정말 멋진 이름이네요! {player.playerName}님 반가워요.");

            #region 직업선택
            do
            {
                Console.WriteLine($"{player.playerName}님 이제 직업을 선택해볼까요? {player.playerName}님은 어떤 직업을 선호하시나요?");
                Console.WriteLine(" 1. 전사(직업) \n\n 2. 마법사 \n\n 3. 도적 \n\n 4. 코딩전사");
                player.playerJob = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (player.playerJob)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"{jobs[player.playerJob - 1]}를 선택하셨군요! 낭만적인 사람이군요?");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"{jobs[player.playerJob - 1]}를 선택하셨군요! 같이 적을 한방에 쓸어버리죠!");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"{jobs[player.playerJob - 1]}을 선택하셨군요! 이기는 것보단 상대를 화나게 하는데 재미를 느끼시는군요...");
                        Console.WriteLine("...뭐! 그래도 재밌는 직업이죠!");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"{jobs[player.playerJob - 1]}를 선택하셨군요...! 힘들긴하겠지만..모험가님이라면 할 수 있을거예요!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.WriteLine("다시 선택해주세요");
                        break;
                }
                if (player.playerJob <= 4 && player.playerJob > 0)
                {
                    Console.WriteLine($"{jobs[player.playerJob - 1]}을/를 선택하였습니다. {jobs[player.playerJob - 1]}으로 결정하시겠습니까?");
                    Console.WriteLine(" 1. 네! \n 2. 다시 고민해볼게요...!");

                    confirm = Console.ReadLine();
                    Console.Clear();

                    if (confirm == "1")
                    {
                        isConfirm = true;
                        Console.Clear();
                        Console.WriteLine(" 다시 한번 아르칸디아에 오신 것을 환영해요~! 이제부터 함께 모험을 즐겨볼까요?");
                    }
                    else if (confirm == "2")
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
            #endregion

            Console.WriteLine("");
        }
    }
}
