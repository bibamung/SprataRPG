using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG
{
    class Player
    {
        public string playerName;
        public int playerJob;

        private int playerHp;
        private int playerDex;
        private int playerATK;

        public int GetHp() { return playerHp; }
        public void SetHp(int hp) { this.playerHp = hp; }

        public int GetDex() { return playerDex; }
        public void SetDex(int dex) { this.playerDex = dex; }

        public int GetATK() { return playerATK; }
        public void SetATK(int atk) { this.playerATK = atk; }
    }
}
