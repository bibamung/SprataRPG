using SpartaRPG.Character;
using SpartaRPG.Class;
using SpartaRPG.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpartaRPG
{
    internal class MainSystem
    {
        public static Player player;
        static void Main(string[] args)
        {

            player = GameManager.Init();
            
            Console.Clear();

            Console.WriteLine("루미에라 마을에 오신 모험가님 환영합니다.");
            while (true)
            {
                Console.Clear();
                GameManager.Town(player);
            }
        }
    }
}
