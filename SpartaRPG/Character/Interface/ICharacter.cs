using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaRPG.Class.Interface;
using SpartaRPG.Item.Interface;

namespace SpartaRPG.Character.Interface
{
    public interface ICharacter
    {
        string Name { get; set; }       //이름
        IClass Class { get; set; }      //직업
        public float MAXHp { get; set; }        //최대 체력

        float Hp { get; set; }      //체력
        int Level { get; set; }         //레벨
        

        //
        int ATK { get; set; }
        int DEF { get; set; }
        //


        IEquippable EquippedWeapon { get; set; }
        IEquippable EquippedArmor { get; set; }

        int Gold { get; set; }
    }
}
