using SpartaRPG.Character;
using SpartaRPG.Character.Interface;
using SpartaRPG.Class;
using SpartaRPG.Class.Interface;
using SpartaRPG.Dungeon;
using SpartaRPG.Item;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SpartaRPG
{
    public enum ePlayerBehavior
    {
        PlayerInfo = 1, PlayerInventory = 2, PlayerShop = 3, Purchase = 4, Sale = 5, Use = 6
    }
    public static class GameManager
    {
        private static int callCount = 1;
        public static Player Init()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("모험가님 안녕하세요~ 아르칸디아에 오신 것을 환영해요~!");
            Console.WriteLine("모험하기 전에 모험가님 이름을 알려주세요!");

            string playerName = PlayerNameCreate();

            Console.WriteLine($"와! 정말 멋진 이름이네요! {playerName}님 반가워요.");

            IClass playerClass = PlayerClass(playerName);
            Player player = new Player(playerName, playerClass, 1);
            return player;
        }
        public static string PlayerNameCreate()
        {
            string playerName;
            bool isConfirm = false;
            char confirm;
            do
            {
                Console.SetCursorPosition(0, 13);
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
            int choose;
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");

            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전 입장\n5. 여관\n0. 종료");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);
            if (isValidNum)
            {
                switch (choose)
                {
                    case 1:
                        PlayerInfo(player);
                        break;
                    case (int)ePlayerBehavior.PlayerInventory:
                        Inventory(player, (int)ePlayerBehavior.PlayerInventory);
                        break;
                    case (int)ePlayerBehavior.PlayerShop:
                        Shop(player, (int)ePlayerBehavior.PlayerShop);
                        break;
                    case 4:
                        DungeonEnter(player);
                        break;
                    case 5:
                        Rest(player);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n숫자를 입력해주세요.\n");
            }

        }

        //캐릭터 상태보기
        public static void PlayerInfo(Player player)
        {
            Console.Clear();
            int choose;

            Console.WriteLine("\n상태보기\n캐릭터의 정보가 표시됩니다.");

            player.DisplayCharacterInfo();

            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);

            if (isValidNum)
            {
                switch (choose)
                {
                    case 0:
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        PlayerInfo(player);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n숫자를 입력해주세요.\n");
            }
        }

        //인벤토리
        public static void Inventory(Player player, int playerBehavior)
        {
            int choose = 0;
            Console.Clear();

            if (player.Inventory.Count == 0)
            {
                Console.WriteLine("[아이템 목록]\n\n");
                Console.WriteLine("인벤토리가 비어 있습니다.\n");

                Console.Write("돌아가시려면 진행하시려면 Enter를 눌러주세요...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("[아이템 목록]\n\n");

            DisplayItem(player.Inventory, playerBehavior);

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리\n0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            
            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);
            if (isValidNum)
            {
                switch (choose)
                {
                    case 1:
                        EquipmentUseManage(player);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Inventory(player, playerBehavior);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n숫자를 입력해주세요.\n");
            }


        }

        //장비 탈부착
        public static void EquipmentUseManage(Player player)
        {
            Console.Clear();
            int chooseItem = 1;

            while (chooseItem != 0)
            {
                Console.WriteLine("[아이템 목록]\n\n");
                DisplayItem(player.Inventory, (int)ePlayerBehavior.Use);

                Console.Write("\n0. 나가기\n");

                Console.Write("\n장착 및 해제 or 사용할 아이템을 선택해주십시오.\n>> ");
                bool isValidNum = int.TryParse(Console.ReadLine(), out chooseItem);
                if (isValidNum)
                {
                    if (chooseItem >= 1 && chooseItem <= player.Inventory.Count && player.Inventory[chooseItem - 1] != null)
                    {

                        if (player.Inventory[chooseItem - 1] is Weapon && player.Inventory[chooseItem - 1] is IEquippable equippableWeapon)
                        {
                            if (player.Inventory[chooseItem - 1].isEquip)
                            {
                                Console.Clear();
                                player.EquippedWeapon.Unequip(player);
                            }
                            else
                            {
                                Console.Clear();
                                equippableWeapon.Equip(player);
                            }
                        }
                        else if (player.Inventory[chooseItem - 1] is Armor && player.Inventory[chooseItem - 1] is IEquippable equippableArmor)
                        {
                            if (player.Inventory[chooseItem - 1].isEquip)
                            {
                                Console.Clear();
                                player.EquippedArmor.Unequip(player);
                            }
                            else
                            {
                                Console.Clear();
                                equippableArmor.Equip(player);
                            }
                        }
                        else if (player.Inventory[chooseItem - 1] is Potion)
                        {
                            if (player.Hp >= player.MAXHp) { Console.WriteLine("현재 체력이 가득차 있습니다."); break; }

                            else
                            {
                                player.Inventory[chooseItem - 1].Quantity--;
                                player.Hp += player.Inventory[chooseItem - 1].IncreaseUnit;
                                if (player.Hp >= player.MAXHp) { player.Hp = player.MAXHp; }
                            }
                            Console.WriteLine($"모험가님의 체력이 {player.Inventory[chooseItem - 1].IncreaseUnit}만큼 회복되었습니다!\n현재 체력 >> {player.Hp}");
                            if (player.Inventory[chooseItem - 1].Quantity == 0)
                            {
                                player.Inventory.RemoveAt(chooseItem - 1);
                            }
                            Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못 입력하셨습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("\n숫자를 입력해주세요.\n");
                }
            }

        }

        //상점(구매, 판매)
        public static void Shop(Player player, int playerBehavior)
        {
            Console.Clear();
            int choose;

            List<IItem> saleItem = new List<IItem>();
            saleItem.Add(ItemList.GetItemByID(10001));
            saleItem.Add(ItemList.GetItemByID(10002));
            saleItem.Add(ItemList.GetItemByID(10003));
            saleItem.Add(ItemList.GetItemByID(10004));
            saleItem.Add(ItemList.GetItemByID(10005));
            saleItem.Add(ItemList.GetItemByID(10006));
            saleItem.Add(ItemList.GetItemByID(10007));
            saleItem.Add(ItemList.GetItemByID(20001));
            saleItem.Add(ItemList.GetItemByID(20002));
            saleItem.Add(ItemList.GetItemByID(20003));
            saleItem.Add(ItemList.GetItemByID(20004));
            saleItem.Add(ItemList.GetItemByID(20005));
            saleItem.Add(ItemList.GetItemByID(20006));
            saleItem.Add(ItemList.GetItemByID(20007));
            saleItem.Add(ItemList.GetItemByID(30001));
            saleItem.Add(ItemList.GetItemByID(30002));
            saleItem.Add(ItemList.GetItemByID(30003));
            saleItem.Add(ItemList.GetItemByID(30004));

            Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine($"[보유 골드]\n{player.Gold} G\n");

            Console.WriteLine("[아이템 목록]\n");

            DisplayItem(saleItem, playerBehavior);

            Console.Write("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            
            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);
            if (isValidNum)
            {
                switch (choose)
                {
                    case 0:
                        break;
                    case 1:
                        BuyItem(saleItem, player);
                        break;
                    case 2:
                        SaleItem(player);
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Shop(player, playerBehavior);
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n숫자를 입력해주세요.\n");
            }

        }
        public static void BuyItem(List<IItem> saleItem, Player player)
        {
            Console.Clear();
            int choose = 1;
            while (true)
            {
                Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine($"[보유 골드]\n{player.Gold} G\n");

                Console.WriteLine("[아이템 목록]\n");

                DisplayItem(saleItem, (int)ePlayerBehavior.Purchase);

                Console.Write("\n0. 나가기\n");

                Console.Write("\n구매할 아이템을 입력해주세요.\n>> ");
                bool isValidNum = int.TryParse(Console.ReadLine(), out choose);

                if (choose == 0)
                {
                    break;
                }
                if (choose > 0 && choose <= saleItem.Count)
                {
                    if (choose > 0 && player.Gold > saleItem[choose - 1].PurchasePrice)
                    {

                        if (player.Inventory.Contains(saleItem[choose - 1]) && (saleItem[choose - 1] is Weapon || saleItem[choose - 1] is Armor))
                        {
                            Console.Clear();
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.Inventory.Contains(saleItem[choose - 1]) && (saleItem[choose - 1] is Potion))
                        {
                            player.Inventory.Find(i => i.Name == saleItem[choose - 1].Name).Quantity++;
                            player.Gold -= saleItem[choose - 1].PurchasePrice;
                            Console.WriteLine($"{saleItem[choose - 1].Name}아이템 구매를 완료했습니다\n");

                        }
                        else
                        {
                            player.Inventory.Add(saleItem[choose - 1]);
                            player.Inventory.Last().Quantity++;
                            player.Gold -= saleItem[choose - 1].PurchasePrice;
                            Console.WriteLine($"{saleItem[choose - 1].Name}아이템 구매를 완료했습니다\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Gold 가 부족합니다.");
                    }
                }



                else if (choose > saleItem.Count)
                {
                    Console.Clear();
                    Console.WriteLine("잘못 입력하셨습니다.");
                }

            }

        }
        public static void SaleItem(Player player)
        {
            Console.Clear();
            int choose = 1, chooseItem = 0;
            while (true)
            {
                Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드]\n{player.Gold} G\n");

                Console.WriteLine("[아이템 목록]\n");

                DisplayItem(player.Inventory, (int)ePlayerBehavior.Sale);

                Console.Write("\n0. 나가기\n");

                Console.Write("\n판매할 아이템을 입력해주세요.\n>> ");
                bool isValidNum = int.TryParse(Console.ReadLine(), out chooseItem);
                if (isValidNum)
                {
                    if (chooseItem == 0)
                    {
                        break;
                    }
                    else if (chooseItem > 0 && chooseItem <= player.Inventory.Count)
                    {
                        if (player.Inventory.Contains(player.Inventory[chooseItem - 1]))
                        {

                            Console.Write("\n1. 네\n2. 아니요\n");

                            Console.Write("\n정말로 판매하시겠습니까?\n>> ");
                            choose = int.Parse(Console.ReadLine());

                            if (choose == 1)
                            {
                                if (player.Inventory[chooseItem - 1] is Weapon && player.Inventory[chooseItem - 1].isEquip)
                                {
                                    player.Gold += (int)Math.Round((player.Inventory[chooseItem - 1].PurchasePrice) * 0.5f);
                                    player.EquippedWeapon.Unequip(player);
                                    player.Inventory.RemoveAt(chooseItem - 1);
                                }
                                else if (player.Inventory[chooseItem - 1] is Armor && player.Inventory[chooseItem - 1].isEquip)
                                {
                                    player.Gold += (int)Math.Round((player.Inventory[chooseItem - 1].PurchasePrice) * 0.5f);
                                    player.EquippedArmor.Unequip(player);
                                    player.Inventory.RemoveAt(chooseItem - 1);
                                }
                                else if (player.Inventory[chooseItem - 1] is Potion)
                                {
                                    player.Gold += (int)Math.Round((player.Inventory[chooseItem - 1].PurchasePrice) * 0.5f);
                                    player.Inventory[chooseItem - 1].Quantity--;
                                    if (player.Inventory[chooseItem - 1].Quantity == 0)
                                    {
                                        player.Inventory.RemoveAt(chooseItem - 1);
                                    }
                                }
                                else if (player.Inventory[chooseItem - 1] is Weapon || player.Inventory[chooseItem - 1] is Armor)
                                {
                                    player.Gold += (int)Math.Round((player.Inventory[chooseItem - 1].PurchasePrice) * 0.5f);
                                    player.Inventory.RemoveAt(chooseItem - 1);
                                }

                            }
                            else if (choose == 2)
                            {
                                break;
                            }
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못 입력하셨습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("\n숫자를 입력해주세요.\n");
                }
            }

        }

        //던전
        public static void DungeonEnter(Player player)
        {
            int choose, chooseDungeon;
            Console.WriteLine("던전에 입장 하시겠습니까?");
            Console.WriteLine("1. 네\n2. 아니요");
            Console.Write("원하시는 행동을 선택해주세요.\n>> ");
            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);
            if (isValidNum)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    Random random = new Random();
                    Console.WriteLine("던전입장\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                    Console.WriteLine("1. 쉬운 던전\t| 방어력 5 이상 권장\n2. 일반 던전\t| 방어력 11 이상 권장\n3. 어려운 던전\t| 방어력 17 이상 권장\n0. 나가기");

                    Console.Write("원하시는 던전을 선택해주세요.\n>> ");
                    chooseDungeon = int.Parse(Console.ReadLine());


                    DungeonSelect dungeon = new DungeonSelect(chooseDungeon);
                    if (player.DEF >= dungeon.RecommendDEF)
                    {
                        float curHp = player.Hp;
                        Console.Clear();
                        curHp -=
                            random.Next(20 - ((int)player.DEF - dungeon.RecommendDEF), 35 - ((int)player.DEF - dungeon.RecommendDEF));
                        if (curHp <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"던전 실패\n강해져서 돌아와라...ㅋㅋ\n{dungeon.DungeonLv}을 실패하였습니다.\n");

                            /*Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                            Console.ReadLine();*/
                        }
                        else
                        {
                            Console.WriteLine($"던전 클리어\n축하합니다!!\n{dungeon.DungeonLv}을 클리어 하였습니다.\n");
                            Console.Write($"체력 {player.Hp} → ");//클리어 전 체력
                            player.Hp = curHp;

                            Console.WriteLine($"{player.Hp}");    //클리어 후 체력

                            Console.Write($"Gold {player.Gold} → ");//클리어 전 골드
                            player.Gold +=
                                (int)(dungeon.ClearGold * Math.Round(1.1 + (random.NextDouble() * 0.1), 2));
                            Console.WriteLine($"{player.Gold}");    //클리어 후 골드

                            player.DungeonClearCount++;

                            PlayerLevel(player);

                            Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        if (random.Next(0, 10) >= 6)         //40% 확률로 성공 (반대로 적용함, 기존: 40% 확률로 실패)
                        {
                            Console.Clear();
                            Console.WriteLine($"던전 클리어\n축하합니다!!\n아슬아슬하게 {dungeon.DungeonLv}을 클리어 하였습니다.\n");
                            Console.Write($"체력 {player.Hp} → ");//클리어 전 체력
                            player.Hp -= 35;
                            Console.WriteLine($"{player.Hp}");    //클리어 후 체력

                            Console.Write($"Gold {player.Gold} → ");//클리어 전 골드
                            player.Gold += dungeon.ClearGold;
                            Console.WriteLine($"{player.Gold}");    //클리어 후 골드
                            player.DungeonClearCount++;

                            PlayerLevel(player);

                            Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"던전 실패\n강해져서 돌아와라...ㅋㅋ\n{dungeon.DungeonLv}을 실패하였습니다.\n");
                            Console.Write($"체력 {player.Hp} → ");
                            player.Hp /= 2;
                            Console.WriteLine($"{player.Hp}");

                            Console.Write($"Gold {player.Gold} → ");
                            Console.WriteLine($"{player.Gold}");
                            Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }

        //휴식기능
        public static void Rest(Player player)
        {

            Console.WriteLine($"휴식하기\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)\n");
            Console.WriteLine("1. 휴식하기\n0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int choose;
            bool isValidNum = int.TryParse(Console.ReadLine(), out choose);
            if (isValidNum)
            {
                switch (choose)
                {
                    case 0:
                        break;
                    case 1:

                        if (player.Hp >= player.MAXHp) { Console.WriteLine("현재 체력이 가득차 있습니다."); break; }

                        else
                        {
                            player.Gold -= 500;
                            player.Hp += 100;
                            if (player.Hp >= player.MAXHp) { player.Hp = player.MAXHp; }
                        }
                        Console.WriteLine($"모험가님의 체력이 100만큼 회복되었습니다! ^^7\n현재 체력 >> {player.Hp}");
                        Console.Write("계속 진행하시려면 Enter를 눌러주세요...");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n숫자를 입력해주세요.\n");
            }
        }

        //게임 종료
        public static bool GameOver()
        {
            Console.WriteLine("\r\n__   __ _____  _   _  ______  _____  _____ ______ \r\n\\ \\ / /|  _  || | | | |  _  \\|_   _||  ___||  _  \\\r\n \\ V / | | | || | | | | | | |  | |  | |__  | | | |\r\n  \\ /  | | | || | | | | | | |  | |  |  __| | | | |\r\n  | |  \\ \\_/ /| |_| | | |/ /  _| |_ | |___ | |/ / \r\n  \\_/   \\___/  \\___/  |___/   \\___/ \\____/ |___/  \r\n                                                  \r\n                                                  \r\n");

            Console.WriteLine("그는...유명한 모험가였습니다...\r\n");

            Console.WriteLine("1. 환생하기\n0. 끝내기");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            int choose = int.Parse(Console.ReadLine());

            if (choose == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //아이템 출력
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
                    Console.WriteLine($"- {count} {(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                    count++;
                }
            }
        }
        public static void DisplayItem(List<IItem> items, int playerBehavior)
        {
            int count = 1;
            foreach (IItem item in items)
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
                switch (playerBehavior)
                {
                    case (int)ePlayerBehavior.PlayerInventory:
                        if (item is Potion)
                        {
                            Console.WriteLine($"- {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Quantity}개 | {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"- {(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                        }
                        break;
                    case (int)ePlayerBehavior.PlayerShop:
                        Console.WriteLine($"- {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                        break;
                    case (int)ePlayerBehavior.Purchase:
                        Console.WriteLine($"- {count} {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description} | {item.PurchasePrice} G");
                        break;
                    case (int)ePlayerBehavior.Sale:
                        if (item is Potion)
                        {
                            Console.WriteLine($"- {count} {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Quantity}개 | {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"- {count} {(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                        }
                        break;
                    case (int)ePlayerBehavior.Use:
                        if (item is Potion)
                        {
                            Console.WriteLine($"- {count} {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Quantity}개 | {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"- {count} {(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                        }
                        break;
                    default:
                        break;
                }
                /*if (playerBehavior == (int)ePlayerBehavior.PlayerInventory)
                    Console.WriteLine($"- {(item.isEquip ? "[E]" : "")}{item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
                else if (playerBehavior == (int)ePlayerBehavior.PlayerShop)
                    Console.WriteLine($"- {item.Name} | {increaseUnit}{item.IncreaseUnit} | {item.Description}");
*/

                count++;
            }
        }
        public static void PlayerLevel(Player player)
        {
            if (player.DungeonClearCount == callCount)
            {
                callCount++;
                
                Console.WriteLine($"모험가 레벨이 상승하였습니다\n");
                Console.WriteLine($"================================");
                Console.WriteLine($"{player.Level} => {++player.Level}");
                Console.WriteLine($"{player.DEF} => {(player.DEF+=1.0f)}");
                Console.WriteLine($"{player.ATK} => {(player.ATK+=0.5f)}");
                Console.WriteLine($"================================\n");
            }
        }

    }
}
