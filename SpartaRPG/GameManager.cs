using SpartaRPG.Character;
using SpartaRPG.Character.Interface;
using SpartaRPG.Class;
using SpartaRPG.Class.Interface;
using SpartaRPG.Item;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        // 마을 활동
        public static void Town(Player player)
        {
            char choose = ' ';
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");

            Console.WriteLine("1. 상태 보기\r\n2. 인벤토리\r\n3. 상점");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            choose = char.Parse(Console.ReadLine());
            switch (choose)
            {
                case '1':
                    PlayerInfo(player);
                    break;
                case '2':
                    Inventory(player); 
                    break;
                case '3':
                    Shop(player);
                    break;
                default:
                    break;
            }

        }


        //캐릭터 상태보기
        public static void PlayerInfo(Player player)
        {
            Console.Clear();
            int choose;

            player.DisplayCharacterInfo();

            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            choose = int.Parse(Console.ReadLine());

            switch (choose) 
            {
                case 0:
                    break;
                default:
                    PlayerInfo(player);
                    break;
            }
        }


        //인벤토리
        public static void Inventory(Player player)
        {
            int count = 1;
            int choose = 0;
            Console.Clear();

            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("[아이템 목록]\n\n");
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }
            Console.WriteLine("[아이템 목록]\n\n");

            foreach (IItem item in player.Inventory)
            {
                string type = "", increaseUnit = "";
                switch (item)
                {
                    case Weapon:
                        type = "무기"; increaseUnit = "공격력 + ";
                        break;
                    case Armor:
                        type = "방어구"; increaseUnit = "방어력 + ";
                        break;
                    case Potion:
                        type = "포션"; increaseUnit = "체력회복 + ";
                        break;
                    default:
                        type = "아이템";
                        break;
                }
                Console.WriteLine($"{count}.\t{(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리\n2. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    EquipmentManage(player);
                    break;
                case 2:
                    break;
                default:
                    Inventory(player);
                    break;
            }

        }

        //장비 탈부착
        public static void EquipmentManage(Player player)
        {
            int chooseItem = 1;
            
            while (chooseItem != 0) {
                DisplayEquippableItem(player);

                Console.Write("\n0. 나가기\n");

                Console.Write("\n장착 및 해제할 장비를 선택해주십시오.\n>> ");
                chooseItem = int.Parse(Console.ReadLine());

                if (chooseItem >= 1 && chooseItem <= player.Inventory.Count && player.Inventory[chooseItem - 1] != null)
                {
                    
                    if (player.Inventory[chooseItem - 1] is Weapon && player.Inventory[chooseItem - 1] is IEquippable equippableWeapon)
                    {
                        if (player.Inventory[chooseItem - 1].isEquip)
                            player.EquippedWeapon.Unequip(player);
                        else
                            equippableWeapon.Equip(player);
                    }
                    else if (player.Inventory[chooseItem - 1] is Armor && player.Inventory[chooseItem - 1] is IEquippable equippableArmor)
                    {
                        if (player.Inventory[chooseItem - 1].isEquip)
                            player.EquippedArmor.Unequip(player);
                        else
                        {
                            equippableArmor.Equip(player);
                        }
                    }
                }
            }

        }

        //상점
        public static void Shop(Player plyaer)
        {

        }


        //장착 가능한 아이템 표시
        public static void DisplayEquippableItem(Player player)
        {
            int count = 1;
            Console.WriteLine("[아이템 목록]\n\n");

            foreach (IItem item in player.Inventory)
            {
                if (item is Weapon || item is Armor)
                {
                    string type = "", increaseUnit = "";
                    switch (item)
                    {
                        case Weapon:
                            type = "무기"; increaseUnit = "공격력 + ";
                            break;
                        case Armor:
                            type = "방어구"; increaseUnit = "방어력 + ";
                            break;
                        default:
                            type = "아이템";
                            break;
                    }
                    Console.WriteLine($"{count}.\t{(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                    count++;
                }
            }
        }

    }
}
