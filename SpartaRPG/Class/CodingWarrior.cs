﻿using SpartaRPG.Character.Interface;
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
    public class CodingWarrior : IClass
    {
        public string ClassName => "코딩전사";
        public List<IItem> DefaultItems { get; }
        public CodingWarrior()
        {
            DefaultItems = new List<IItem>
            {
                ItemList.GetItemByName("스웨터"),
                ItemList.GetItemByName("키보드")
            };
        }
        public void ApplyClassStats(ICharacter character)
        {
            character.MAXHp = 70f;
            character.Hp += 70f;
            character.ATK += 10;
            character.DEF += 3;
        }
    }
}
