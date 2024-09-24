using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dungeon
{

    enum STARTSELECT
    {
        SELECTSTAT,
        SELECTHEAL,
        SELECTINVEN,
        SELECTDUNGEON,
        SELECTSHOP,
        NONSELECT,
    }


    class Item
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public string Description { get; set; }

        public Item(string name, int power, string description)
        {
            Name = name;
            Power = power;
            Description = description;
        }
    }
    class Inventory
    {
        public Player player;
        List<Item> items = new List<Item>();

        public void Inven()
        {
            items.Add(new Item("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다."));
            items.Add(new Item("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다."));
            items.Add(new Item("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다."));
        }
        public void Shop()
        {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.Gold);
            Console.WriteLine("[아이템 목록]");
            items.Add(new Item("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다."));
            items.Add(new Item("무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            items.Add(new Item("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."));
            items.Add(new Item("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다."));
            items.Add(new Item("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다."));
            items.Add(new Item("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다."));
        }
        public void ShowItems()
        {
            Inven();
            Console.WriteLine("[인벤토리 목록]");
            
            if (items.Count == 0)
            {
                Console.WriteLine("인벤토리가 비었습니다");
            }
            else
            {
                foreach (var item in items) 
                {
                    Console.WriteLine($"{item.Name} | 공격력/방어력: {item.Power} | {item.Description}");
                }

            }
        }

    }

    class Player
    {
        public Inventory inventory;
        public int At = 10;
        public int Hp = 100;
        public int MxpHP = 100;
        public int Def = 5;
        public int Gold { get; private set; } = 1500;
        public int GetGold()
        {
            return Gold;
        }


        public void Status()
        {
            Console.Clear();
            Console.WriteLine($"모험가의 능력치 (전사)");
            Console.WriteLine();
            Console.WriteLine($"공격력 : {At}");
            Console.WriteLine($"방어력 : {Def}");
            Console.WriteLine($"체  력 : {Hp}");
            Console.WriteLine($"Gold : {Gold}");
        }
        public void Invenotory()
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            int input = int.Parse(Console.ReadLine());
        
            if (input == 1)
            {
                inventory.ShowItems();
            }
            else if (input == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다. 숫자로 입력해주세요");
                return;
            }
        }
}

internal class Program
{
    static STARTSELECT StartSelect()
    {
        Console.Clear();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("1. 상태 확인");
        Console.WriteLine("2. 인벤토리 확인");
        Console.WriteLine("3. 상점 방문");
        Console.WriteLine("4. 체력 회복");
        Console.WriteLine("5. 던전으로 이동");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해주세요.(숫자로 입력)");

        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                Console.WriteLine("상태 확인중..");
                Console.ReadKey();
                return STARTSELECT.SELECTSTAT;
            case 2:
                Console.WriteLine("인벤토리 확인중..");
                Console.ReadKey();
                return STARTSELECT.SELECTINVEN;
            case 3:
                Console.WriteLine("상점으로 이동합니다..");
                Console.ReadKey();
                return STARTSELECT.SELECTSHOP;
            case 4:
                Console.WriteLine("치료소로 이동합니다..");
                Console.ReadKey();
                return STARTSELECT.SELECTHEAL;
            case 5:
                Console.WriteLine("던전으로 이동합니다..");
                Console.ReadKey();
                return STARTSELECT.SELECTDUNGEON;
            default:
                Console.WriteLine("잘못된 선택입니다.");
                Console.ReadKey();
                return STARTSELECT.NONSELECT;


        }
    }


    static void Main(string[] args)
    {
        Player player = new Player();
        player.inventory = new Inventory();
        Inventory inventory = new Inventory();

        while (true)
        {
            STARTSELECT SelectCheck = StartSelect();

            switch (SelectCheck)
            {
                case STARTSELECT.SELECTSTAT:
                    player.Status();
                    Console.ReadKey();
                    break;
                case STARTSELECT.SELECTINVEN:
                    player.Invenotory();
                    Console.ReadKey();
                    break;
                    case STARTSELECT.SELECTSHOP:
                        inventory.Shop();
                        Console.ReadKey();
                        break;
            }
        }
    }
}
}
