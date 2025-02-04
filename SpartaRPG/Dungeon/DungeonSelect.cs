using SpartaRPG.Dungeon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG.Dungeon
{
    enum DifficultyLevel
    {
        Easy = 1, Nomal, Hard
    }
    public class DungeonSelect : IDungeon
    {
        public string DungeonLv { get; }
        public int RecommendDEF { get; }
        public int ClearGold { get; }

        public DungeonSelect(int dungeonLv)
        {
            switch (dungeonLv)
            {
                case (int)DifficultyLevel.Easy:
                    DungeonLv = "쉬운 던전";
                    RecommendDEF = 5;
                    ClearGold = 1000;
                    break;
                case (int)DifficultyLevel.Nomal:
                    DungeonLv = "일반 던전";
                    RecommendDEF = 11;
                    ClearGold = 1700;
                    break;
                case (int)DifficultyLevel.Hard:
                    DungeonLv = "어려운 던전";
                    RecommendDEF = 17;
                    ClearGold = 2500;
                    break;
                default:
                    break;
            }
        }

    }
}
