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
        static void Main(string[] args)
        {
            bool isOver = false;
            while (!isOver)
            {
                Player player;
                Console.Clear();
                Console.WriteLine("\r\n _____                      _          ______ ______  _____ \r\n/  ___|                    | |         | ___ \\| ___ \\|  __ \\\r\n\\ `--.  _ __    __ _  _ __ | |_   __ _ | |_/ /| |_/ /| |  \\/\r\n `--. \\| '_ \\  / _` || '__|| __| / _` ||    / |  __/ | | __ \r\n/\\__/ /| |_) || (_| || |   | |_ | (_| || |\\ \\ | |    | |_\\ \\\r\n\\____/ | .__/  \\__,_||_|    \\__| \\__,_|\\_| \\_|\\_|     \\____/\r\n       | |                                                  \r\n       |_|                                                  \r\n");
                player = GameManager.Init();

                Console.Clear();

                Console.WriteLine("루미에라 마을에 오신 모험가님 환영합니다.");
                while (player.Hp >= 0)
                {
                    Console.Clear();
                    GameManager.Town(player);
                }
                isOver = GameManager.GameOver();
            }
        }
    }
}
