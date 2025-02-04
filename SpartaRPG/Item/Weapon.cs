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
    public class Weapon : IEquippable
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int IncreaseUnit { get; set; }
        public int PurchasePrice { get; }
        public int Quantity { get; set; }

        public bool isEquip { get; set; }
        
        public Weapon(int id, string name, string description, int atk, int pp)
        {
            ID = id; 
            Name = name; 
            Description = description;
            IncreaseUnit = atk; 
            PurchasePrice = pp;
        }

        public void Equip(ICharacter character)
        {
            if (character is Player player)
            {
                if (player.EquippedWeapon != null)
                {
                    player.EquippedWeapon.Unequip(player);
                }

                player.ATK += (float)IncreaseUnit;
                player.EquippedWeapon = this;
                this.isEquip = true;
                Console.WriteLine($"{Name}을(를) 장착했습니다.");
            }
        }
        public void Unequip(ICharacter character)
        {
            if (character is Player player)
            {
                player.ATK -= (float)IncreaseUnit;
                player.EquippedWeapon = null;
                this.isEquip = false;
                Console.WriteLine($"{Name}을(를) 해제했습니다.");
            }
        }
    }
}
