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
    public class Magician : IClass
    {
        public string ClassName { get; set; }
        public List<IItem> DefaultItems { get; }
        public Magician()
        {
            ClassName = "마법사";
            DefaultItems = new List<IItem>
            {
                ItemList.GetItemByName("비단 로브"),
                ItemList.GetItemByName("나무 몽둥이")
            };
        }
        public void ApplyClassStats(ICharacter character)
        {
            character.MAXHp = 95f;
            character.Hp += 95f;
            character.ATK += 12;
            character.DEF += 4;
        }
    }
}
