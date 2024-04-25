using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;

namespace textgame
{

    class Program
    {

        static void Main()
        {
            Console.WriteLine("스파르타 마을에 오신것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            int answer;
            bool act = int.TryParse(input, out answer);

            while (act)
            {
                Character player = new Character(01, "( 전사 )", 10, 5, 100, 1500);
                switch (answer)
                {
                    case 1:
                        Console.Clear();
                        player.StatusInfo();
                        player.Inventory.Items(구매한아이템);

                        string input2 = Console.ReadLine();
                        int answer2;
                        bool act2 = int.TryParse(input2, out answer2);

                        if (answer2 == 0)
                        {
                            Program menu = new Program();
                            Console.Clear();
                            Main();
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Inventory.Item.ItemInfo();

                        string input3 = Console.ReadLine();
                        int answer3;
                        bool act3 = int.TryParse(input3, out answer3);

                        if (answer3 == 0)
                        {
                            Program menu = new Program();
                            Console.Clear();
                            Main();
                        }

                        if (answer3 == 1)
                        {
                            Console.Clear();
                            Inventory.Item.itemEquip();

                            ConsoleKeyInfo info = Console.ReadKey();
                            int selectedequip = (info.KeyChar - '0') - 1;

                            //if (0 <= selectedequip && selectedequip < equipitemlist.Count)
                            //{
                            //    Console.ReadKey();
                            //    Console.Clear();
                            //}
                        }

                        break;


                    case 3:
                        Console.Clear();
                        Shop product = new();
                        product.Showshop();

                        string input4 = Console.ReadLine();
                        int answer4;
                        bool act4 = int.TryParse(input4, out answer4);

                        if (answer4 == 0)
                        {
                            Program menu = new Program();
                            Console.Clear();
                            Main();
                        }

                        break;

                    default:
                        if (answer <= 0 || answer >= 4)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Main();
                            break;
                        }
                         break;
                 
                }

            }
        }
    }

   public class Character
    {
        public int Lv { get; set; }
        public string Chad { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int Originatk { get; }
        public int Origindef { get; }
        public Inventory Inventory { get; set; }


        public Character(int Lv, string Chad, int attack, int defense, int hp, int gold) //생성자
        {
            this.Lv = Lv;
            this.Chad = Chad;
            this.Attack = attack;
            this.Defense = defense;
            this.Hp = hp;
            this.Gold = gold;
            Inventory = new Inventory();
        }

        public void StatusInfo()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine(" ");
            Console.WriteLine($"Lv. {this.Lv}");
            Console.WriteLine($"Chad {this.Chad}");
            Console.WriteLine($"공격력: {this.Attack}");
            Console.WriteLine($"방어력: {this.Defense}");
            Console.WriteLine($"체 력: {this.Hp}");
            Console.WriteLine($"Gold: {this.Gold} G");
            Console.WriteLine(" ");
            Console.WriteLine("0. 나가기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }


    }

    public class Inventory
    {
        public List<Item> equipitemlist;

        public Inventory()
        {
            equipitemlist = new List<Item>();
        }

        public void Items(Item item)
        {
            equipitemlist.Add(item);
        }

        


        public class Item
        {
            public string Itequip { get; set; }
            public string Itname { get; set; }
            public string Itinfo { get; set; }
            public bool Isused { get; set; }
            public int Itatk { get; set; }
            public int Itdef {  get; set; }

            Item itemlist = new Item();



            static public void ItemInfo()
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine(" ");
                Console.WriteLine("1. 장착 관리\n0. 나가기\n ");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }

            static public void itemEquip()
            {
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine(" ");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine(" ");
                Console.WriteLine("0. 나가기\n ");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");


            }

            public bool setIsused()
            {
                Isused = !Isused;
                Console.WriteLine(Isused);
                return Isused;
            }



        }
    }
    
    

    class Shop
    {
        public string Itnum { get; set; }
        public int Effect { get; set; }
        public int Price { get; set; }
        public Program Program { get; set; }

        public Shop(string Itnum, int Effect, int Price)
        {
            this.Itnum = Itnum;
            this.Effect = Effect;
            this.Price = Price;
            Program = new Program();
        }

        Shop shoplist = new Shop();

        public Shop()
        {
        }

        public void Showshop()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드]\n{Character.Gold} G\n");
            Console.WriteLine("[아이템 목록]");
            Shoplist();
            Console.WriteLine(" ");
            Console.WriteLine("1. 아이템 구매\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }


        public void Shoplist()
        {
            Console.WriteLine($"- 수련자 갑옷    | 방어력  {this.Effect}  |  수련에 도움을 주는 갑옷입니다.              |   {this.Price} G");
            Console.WriteLine($"- 무쇠갑옷      | 방어력  {this.Effect}  |  무쇠로 만들어져 튼튼한 갑옷입니다.              |   {this.Price} G");
            Console.WriteLine($"- 스파르타의 갑옷 | 방어력  {this.Effect}  |  스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|   {this.Price} G");
            Console.WriteLine($"- 낡은 검      | 공격력  {this.Effect}  |  쉽게 볼 수 있는 낡은 검입니다.              |   {this.Price} G");
            Console.WriteLine($"- 청동 도끼      | 공격력  {this.Effect}  |  어디선가 사용됐던 것 같은 도끼입니다.        |   {this.Price} G");
            Console.WriteLine($"- 스파르타의 창      | 공격력  {this.Effect}  |  스파르타의 전사들이 사용했다는 전설의 창입니다. |   {this.Price} G");
        }
        //이거저거 찾아봐도 머리가 새하얘져서 못하겠음......
    }
}
