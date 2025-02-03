using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Item
{
    public static class ItemList
    {
        public static List<IItem> Items {  get; set; }
        public static List<Armor> Armors { get; set; }
        public static List<Weapon> Weapons { get; set; }
        public static List<Potion> Potions { get; set; }

        static ItemList()
        {
            Armors = new List<Armor>();
            //방어구
            Armors.Add(new Armor(10001, "비단 로브", "편하긴하지만...성능은...잘 모르겠네요...", 10, 50));
            Armors.Add(new Armor(10002, "스웨터", "왠지 입으면 뭔가 chill해질 것 같다.", 10, 50));
            Armors.Add(new Armor(10006, "범가죽 흉갑", "호랑이의 가중을 벗겨내 만든 흉갑.북실북실한 털에서 호랑이 기운이 솟는다.", 15, 100));
            Armors.Add(new Armor(10003, "미스릴 체인메일", "고대 드워프들이 만들어낸 경량 갑옷으로, 희귀한 금속인 미스릴로 특별 제작한 방어구", 25, 150));
            Armors.Add(new Armor(10004, "드래곤 스케일 아머", "전설적인 드래곤의 비늘을 가공하여 만든 갑옷", 50, 200));
            Armors.Add(new Armor(10005, "신념의 업화 상의", "어? 어디서 많이 본 장비인데? 옆동네 게임 건가? 성능은 좋아 보인다", 100, 500));
            Armors.Add(new Armor(10007, "후드티", "성능이 좋아보이진 않지만, 누군가 입으면... 무적이 된다는 전설의 방어구", 10, 700));

            //무기
            Weapons = new List<Weapon>();
            Weapons.Add(new Weapon(20001, "나무 몽둥이", "폭력은 모든것을 해결해 주지", 10, 50));
            Weapons.Add(new Weapon(20002, "키보드", "이건 여기 왜 있는거야?", 10, 50));
            Weapons.Add(new Weapon(20003, "장미칼", "유행했던 때가 있었지...", 15, 100));
            Weapons.Add(new Weapon(20004, "패자의 검", "고대 드워프들이 만들어낸 전설의 무기, 부러지긴 했지만 괜찮아 다시 고치면 돼", 25, 150));
            Weapons.Add(new Weapon(20005, "대마법사의 지팡이", "대 마법사의 힘이 깃든 강력한 지팡이", 50, 200));
            Weapons.Add(new Weapon(20006, "그림자 단검", "암살자들을 위해 만들어진 단검으로, 빛을 거의 반사하지 않는다.", 100, 500));
            Weapons.Add(new Weapon(20007, "무소음 적축 키보드", "이건 여기에 왜 있는거야?", 10, 700));


            //포션
            Potions = new List<Potion>();
            Potions.Add(new Potion(30001,"회복약","맛있진 않다...",20,25));
            Potions.Add(new Potion(30002,"고급 회복약","회복약 보단 성능이 개선됬다. 맛도 조금은 맛있어진 것 같다.",40,50));
            Potions.Add(new Potion(30003,"정령의 가호 회복약","피가 복사가 된다구!",70,75));
            Potions.Add(new Potion(30003, "Monstar", "에너지 드링크!", 100, 100));

            Items = new List<IItem>();
            Items.AddRange(Armors);
            Items.AddRange(Weapons);
            Items.AddRange(Potions);
        }
        public static IItem GetItemByID(int id)
        {
            return Items.FirstOrDefault(item => item.ID == id);
        }

        public static IItem GetItemByName(string name)
        {
            return Items.FirstOrDefault(item => item.Name == name);
        }


        public static Potion GetRandomPotion()
        {
            Random random = new Random();

            int index = random.Next(0, Potions.Count - 1);
            return Potions[index];

        }
    }
}
