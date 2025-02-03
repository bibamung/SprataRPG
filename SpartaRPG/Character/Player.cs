using SpartaRPG.Character.Interface;
using SpartaRPG.Class.Interface;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Character
{
    public class Player : ICharacter
    {
        public string Name { get; set; }        //이름
        public IClass Class { get; set; }       //직업
        public float MAXHp { get; set; }        //최대 체력

        public float Hp { get; set; }           //체력
        public int Level { get; set; }          //레벨

        
        public int ATK { get; set; }            //공격력
        public int DEF { get; set; }            //방어력
        

        public IEquippable EquippedWeapon { get; set; }     //착용무기
        public IEquippable EquippedArmor { get; set; }      //착용방어구

        public int Gold { get; set; }           //보유골드

        public List<IItem> Inventory { get; set; }      //인벤토리

        public Player(string name, IClass classtype, int level)     //생성자
        {
            Name = name;
            Class = classtype;
            Level = level;

            ATK = 0; // 초기화
            DEF = 0;  // 초기화

            Gold = 100;

            Inventory = new List<IItem>();

            Class.ApplyClassStats(this);

            foreach (var item in Class.DefaultItems)
            {
                if (item != null)
                {
                    Inventory.Add(item);
                    if (item is IEquippable equippable)
                    {
                        equippable.Equip(this);
                    }
                }
                else
                {
                    Console.WriteLine("기본 아이템 중 일부를 찾을 수 없습니다.");
                }
            }
        }


        public void DisplayCharacterInfo()          //캐릭터 정보
        {
            Console.WriteLine();
            Console.WriteLine($"Lv. {Level:D2}");
            Console.WriteLine($"{Name} ({Class.ClassName})");
            Console.WriteLine($"공격력: {ATK}");
            Console.WriteLine($"방어력: {DEF}");
            Console.WriteLine($"체력: {Hp}");
            Console.WriteLine($"Gold: {Gold} G\n");
            Console.WriteLine();
        }



    }
}
