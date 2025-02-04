using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Dungeon.Interface
{
    public interface IDungeon
    {
        string DungeonLv { get; }
        int RecommendDEF {  get; }
        int ClearGold { get; }
    }
}
