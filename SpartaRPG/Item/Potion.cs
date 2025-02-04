using SpartaRPG.Character.Interface;
using SpartaRPG.Character;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaRPG.Class;

namespace SpartaRPG.Item
{
    public class Potion : IUseable
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int IncreaseUnit { get; set; }
        public int PurchasePrice { get; }
        public int Quantity { get; set; }
        public bool isEquip { get; set; }
        
        public Potion(int id, string name, string description, int hp, int pp)
        {
            ID = id; 
            Name = name; 
            Description = description;
            IncreaseUnit = hp; 
            PurchasePrice = pp;
            Quantity = 0;
        }

        public void ItemUse(ICharacter character)
        {
            if (character.MAXHp > character.Hp)
            {
                character.Hp += IncreaseUnit;
                Console.WriteLine($"{Name}을(를) 사용하여 체력이 {IncreaseUnit}만큼 회복되었습니다.");

                if (character.Class == new CodingWarrior() && this.Name == "Monstar")
                {
                    character.MAXHp -= 100;
                    character.ATK += 500;
                    character.DEF += 500;
                    Console.WriteLine($"{Name}을(를) 사용하여 최대 체력이 {IncreaseUnit}만큼 감소하였지만, 공격력과 방어력이 영구적으로 500만큼 상승하였습니다");
                }
            }
            else
            {
                Console.WriteLine($"{Name}의 현재 체력이 가득 차 있습니다.");
            }


        }
    }
}
