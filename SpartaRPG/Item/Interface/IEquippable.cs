﻿using SpartaRPG.Character.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Item.Interface
{
    public interface IEquippable : IItem
    {
        void Equip(ICharacter character);
        void Unequip(ICharacter character);
    }
}
