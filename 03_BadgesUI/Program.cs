using _03_BadgeRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_BadgesUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgesUI ui = new BadgesUI();
            ui.Run();
        }
    }
    class BadgesUI
    {
        BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            SeedDictionary();
            MainMenu();
        }
        public void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all badges.\n" +
                    "4. Exit.");
                string input = Console.ReadLine().Trim();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        Console.WriteLine("Exited Program.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid entry.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What is the number on the badge?");
                int badgeNum = -1;
                bool isValidInput = GetNumberInput(out badgeNum);
                if (isValidInput == false)
                {
                    Console.WriteLine("Returning to main menu...");
                    keepRunning = false;
                }
                else if (_repo.GetBadgeDictionary().ContainsKey(badgeNum))
                {
                    Console.WriteLine("Badge number already assigned");
                    Console.ReadKey();
                }
                else
                {
                    List<string> newList = new List<string>();
                    bool hasListedAllDoors = false;
                    while (!hasListedAllDoors)
                    {
                        Console.WriteLine("Please enter a door the badge needs access too");
                        string door = Console.ReadLine();
                        if (newList.Contains(door))
                        {
                            Console.WriteLine("Badge already has access to door.");
                        }
                        else
                        {
                            newList.Add(door);
                            Console.WriteLine("Any other doors?");
                            hasListedAllDoors = !GetYesOrNo();
                        }
                    }
                    Badge newBadge = new Badge(badgeNum, newList);
                    _repo.AddBadge(newBadge);
                    keepRunning = false;
                }
            }
        }
        public void EditBadge()
        {
            Console.Clear();
            bool keepRunningMain = true;
            
            while (keepRunningMain)
            {
                Console.WriteLine("What is the badge number to update?");
                int badgeNum = -1;
                bool isValidInput = GetNumberInput(out badgeNum);
                if (isValidInput == false)
                {
                    Console.WriteLine("Returning to main menu...");
                    keepRunningMain = false;
                }
                else if (!_repo.GetBadgeDictionary().ContainsKey(badgeNum))
                {
                    Console.WriteLine("Badge number not assigned");
                    Console.ReadKey();
                }
                else
                {
                    string rooms = string.Join(" & ", _repo.GetBadgeDictionary()[badgeNum].RoomList);
                    Console.WriteLine(badgeNum + " has access to doors " + rooms + ".\n" +
                        "What would you like to do? \n" +
                        "   1. Remove a door\n" +
                        "   2. Add a door.\n" +
                        "   3. Exit to main menu.");
                    string input = Console.ReadLine().Trim();
                    switch (input)
                    {
                        case "1":
                            RemoveDoor(badgeNum);
                            keepRunningMain = false;
                            break;
                        case "2":
                            AddDoor(badgeNum);
                            keepRunningMain = false;
                            break;
                        case "3":
                            Console.WriteLine("Exiting to main menu.");
                            keepRunningMain = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid entry.");
                            Console.ReadKey();
                            break;

                    }
                }
            }
        }
        public void ListBadges()
        {
            StringBuilder titleRow = new StringBuilder();
            titleRow.AppendFormat("{0,-8}   {1,-15}", "Badge #", "Door Access");
            Console.WriteLine(titleRow);
            SortedDictionary<int, Badge> sorted = new SortedDictionary<int, Badge>(_repo.GetBadgeDictionary());
            SortedDictionary<int, Badge>.KeyCollection keyColl = sorted.Keys;
            StringBuilder dataRow = new StringBuilder();
            foreach (int key in keyColl)
            {
                
                string rooms = string.Join(", ", _repo.GetBadgeDictionary()[key].RoomList);
                dataRow.AppendFormat("{0,-8}   {1,-15}", key, rooms);
                Console.WriteLine(dataRow);
                dataRow.Clear();
            }
            Console.ReadKey();

        }
        public void SeedDictionary()
        {

            List<string> _list1;
            List<string> _list2;
            List<string> _list3;
            List<string> _list4;
            Badge _badge1;
            Badge _badge2;
            Badge _badge3;
            Badge _badge4;
            _list1 = new List<string>() { "room_a", "room_b", "room_c" };
            _list2 = new List<string>() { "room_d", "room_e", "room_f" };
            _list3 = new List<string>() { "room_g", "room_h", "room_i" };
            _list4 = new List<string>() { "room_j", "room_k", "room_l" };
            _badge1 = new Badge(1, _list1);
            _badge2 = new Badge(2, _list2);
            _badge3 = new Badge(3, _list3);
            _badge4 = new Badge(4, _list4);

            _repo.AddBadge(_badge1);
            _repo.AddBadge(_badge2);
            _repo.AddBadge(_badge3);
            _repo.AddBadge(_badge4);
        }
        public bool GetNumberInput(out int i)//takes an int parameter, returns true if int assigned, returns false otherwise. Sets int to zero if no value assigned.
        {
            string input;
            bool isInt = false;
            while (!isInt)
            {
                input = Console.ReadLine();
                isInt = int.TryParse(input, out i);
                if (isInt)
                {
                    return true;
                }
                else if (input.ToLower() == "exit")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input a number or type exit to cancel.");
                }

            }
            i = 0;
            return false;
        }
        public bool GetYesOrNo()//returns true for yes, false for no;
        {
            bool isValidInput = false;
            bool yOrNo = false;
            while (!isValidInput)
            {

                string input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "yes":
                        yOrNo = true;
                        isValidInput = true;
                        break;
                    case "y":
                        yOrNo = true;
                        isValidInput = true;
                        break;
                    case "no":
                        yOrNo = false;
                        isValidInput = true;
                        break;
                    case "n":
                        yOrNo = false;
                        isValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input in the form of y/n");
                        break;
                }
            }
            return yOrNo;
        }
        public void RemoveDoor(int key)
        {
            Console.WriteLine("Which door would you like to remove?");
            bool validDoor = false;
            while (!validDoor)
            {
                string input = Console.ReadLine();
                if (!_repo.GetBadgeDictionary()[key].RoomList.Contains(input.ToLower().Trim()))
                {
                    Console.WriteLine("Please choose a valid door.");
                    string rooms = string.Join(" & ", _repo.GetBadgeDictionary()[key].RoomList);
                    Console.WriteLine(key + " has access to doors " + rooms + ".");
                }
                else
                {
                    Console.WriteLine("Door removed");
                    _repo.GetBadgeDictionary()[key].RoomList.Remove(input.ToLower().Trim());
                    string rooms = string.Join(" & ", _repo.GetBadgeDictionary()[key].RoomList);
                    Console.WriteLine(key + " has access to doors " + rooms + ".");
                    validDoor = true;

                }
            }
        }
        public void AddDoor(int key)
        {
            Console.WriteLine("Which door would you like to add?");
            bool validDoor = false;
            while (!validDoor)
            {
                string input = Console.ReadLine();
                if (_repo.GetBadgeDictionary()[key].RoomList.Contains(input.ToLower().Trim()))
                {
                    Console.WriteLine("Badge already has access to door.");
                    string rooms = string.Join(" & ", _repo.GetBadgeDictionary()[key].RoomList);
                    Console.WriteLine(key + " has access to doors " + rooms + ".");
                }
                else
                {
                    Console.WriteLine("Door added");
                    _repo.GetBadgeDictionary()[key].RoomList.Add(input.ToLower().Trim());
                    string rooms = string.Join(" & ", _repo.GetBadgeDictionary()[key].RoomList);
                    Console.WriteLine(key + " has access to doors " + rooms + ".");
                    validDoor = true;

                }
            }
        }
    }

}
