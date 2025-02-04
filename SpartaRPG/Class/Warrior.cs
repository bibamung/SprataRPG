using SpartaRPG.Character.Interface;
using SpartaRPG.Class.Interface;
using SpartaRPG.Item;
using SpartaRPG.Item.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Class
{
    public class Warrior : IClass
    {
        public string ClassName { get; set; }
        public List<IItem> DefaultItems { get; }
        public Warrior()
        {
            ClassName = "전사";
            DefaultItems = new List<IItem>
            {
                
            };
        }
        public void ApplyClassStats(ICharacter character)
        {
            character.MAXHp = 100f;
            character.Hp += 100f;
            character.ATK += 10;
            character.DEF += 5;
        }
    }
}
