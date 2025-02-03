using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpartaRPG.Character.Interface;
using SpartaRPG.Item.Interface;

namespace SpartaRPG.Class.Interface
{
    public interface IClass
    {
        string ClassName { get; }
        void ApplyClassStats(ICharacter character);
        List<IItem> DefaultItems { get; }
    }
}
