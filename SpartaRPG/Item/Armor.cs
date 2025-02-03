using SpartaRPG.Character.Interface;
using SpartaRPG.Character;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Item
{
    public class Armor : IEquippable
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int Defense { get; set; }
        public int PurchasePrice { get; }
        public bool isEquip { get; set; }
        
        public Armor(int id, string name, string description, int def, int pp)
        {
            ID = id; 
            Name = name; 
            Description = description; 
            Defense = def; 
            PurchasePrice = pp;
        }

        public void Equip(ICharacter character)
        {
            if (character is Player player)
            {
                if (player.EquippedArmor != null)
                {
                    player.EquippedArmor.Unequip(player);
                }

                player.DEF += Defense;
                player.EquippedArmor = this;
                Console.WriteLine($"{Name}을(를) 장착했습니다.");
            }
        }
        public void Unequip(ICharacter character)
        {
            if (character is Player player)
            {
                player.DEF -= Defense;
                player.EquippedArmor = null;
                Console.WriteLine($"{Name}을(를) 해제했습니다.");
            }
        }
    }
}
