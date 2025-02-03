using SpartaRPG.Character;
using SpartaRPG.Class;
using SpartaRPG.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaRPG
{
    internal class MainSystem
    {
        static void Main(string[] args)
        {
            


            Console.WriteLine("모험가님 안녕하세요~ 아르칸디아에 오신 것을 환영해요~!");
            Console.WriteLine("모험하기 전에 모험가님 이름을 알려주세요!");

            string playerName = GameManager.PlayerNameCreate();
                        
            Console.WriteLine($"와! 정말 멋진 이름이네요! {playerName}님 반가워요.");

            IClass playerClass = GameManager.PlayerClass(playerName);

            Player player = new Player(playerName,playerClass,1);


        }
    }
}
