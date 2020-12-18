using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ClaimsRepo;
using System.Data;

namespace _02_ClaimsUI
{
    class UI
    {
        private ClaimsRepo _claimsRepo;
        public void Run()
        {
            SeedQueue();
            MainMenu();
        }
        public void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n\n" +
                    "2. Take care of next claim\n\n" +
                    "3. Enter a new claim\n\n" +
                    "4.Exit program");
                string input = Console.ReadLine().Trim();
                switch (input)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        HandleNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Exited program.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid entry.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void DisplayClaims()//could implement variable alignment length
        {
            Console.Clear();
            if (_claimsRepo.GetClaimsQueue().Count == 0)
            {
                Console.WriteLine("No claims in the current queue.");
            }
            else
            {
                
                StringBuilder titleRow = new StringBuilder();
                titleRow.AppendFormat("{0,-7} {1,-5} {2,-40} {3,-15} {4,-14} {5,-12} {6,-7}", "ClaimId", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");

                Console.WriteLine(titleRow);
                StringBuilder dataRow = new StringBuilder();
                foreach (Claims claim in _claimsRepo.GetClaimsQueue())
                {
                    //          ID     Type    Description      Amount  Accident Claim   isValid
                    dataRow.AppendFormat("{0,-7} {1,-5} {2,-40} {3,-15:C} {4,-14:d} {5,-12:d} {6,-7}", claim.ClaimNumber, claim.ClaimType, claim.Description, claim.ClaimAmout, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
                    Console.WriteLine(dataRow);
                    dataRow.Clear();

                }
                Console.ReadKey();
            }


        }
        public void HandleNextClaim()
        {
            Console.Clear();
            Console.WriteLine($"Here are the details for the next claim to be handled: \n\n" +
                $"ClaimID: {_claimsRepo.GetClaimsQueue().Peek().ClaimNumber}\n\n" +
                $"Type:  {_claimsRepo.GetClaimsQueue().Peek().ClaimType}\n\n " +
                $"Description:  {_claimsRepo.GetClaimsQueue().Peek().Description}\n\n" +
                $"Amount  {_claimsRepo.GetClaimsQueue().Peek().ClaimAmout:C}\n\n" +
                $"DateOfAccident:  {_claimsRepo.GetClaimsQueue().Peek().DateOfIncident:d}\n\n" +
                $"DateOfClaim:  {_claimsRepo.GetClaimsQueue().Peek().DateOfClaim:d}\n\n" +
                $"IsValid:  {_claimsRepo.GetClaimsQueue().Peek().IsValid}\n");
            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            if (GetYesOrNo())
            {

                _claimsRepo.RemoveClaim();
                Console.WriteLine("Press enter to view updated queue\n");
                Console.ReadKey();
                DisplayClaims();
            }

        }
        public void AddNewClaim()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                int typeOfClaim = -1;
                bool isValidClaimType = false;
                while (!isValidClaimType)
                {
                    
                    Console.WriteLine("Enter the claim type or type x to exit: ");
                    string claimType = Console.ReadLine().Trim().ToLower();
                    switch (claimType)
                    {
                        case "car":
                            typeOfClaim = 0;
                            isValidClaimType = true;
                            break;
                        case "home":
                            typeOfClaim = 1;
                            isValidClaimType = true;
                            break;
                        case "theft":
                            typeOfClaim = 2;
                            isValidClaimType = true;
                            break;
                        case "x":
                            isValidClaimType = true;
                            Console.WriteLine("Exiting to main menu..");
                            Console.ReadLine();
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid claim type. Please enter car, home, or theft.");
                            Console.ReadKey();
                            break;
                    }
                }
                if (typeOfClaim >= 0)
                {
                    Console.WriteLine("Please enter a brief description of the event or type x to exit: ");
                    string description = Console.ReadLine().Trim();
                    if(description == "x")
                    {
                        keepRunning = false;

                    }
                    decimal amount;
                    Console.WriteLine("Please enter the claim amount or type exit to return to main menu.");
                    bool isValidDecimal = GetNumberInput(out amount);
                    if (!isValidDecimal)
                    {
                        keepRunning = false;
                    }
                    else
                    {
                        DateTime accident;
                        DateTime claim;
                        if (GetDateTime("Date of Accident", out accident)&&GetDateTime("Date of Claim", out claim))
                        {
                            Claims newClaim = new Claims((TypeOfClaim)typeOfClaim, description, amount, accident, claim);
                            _claimsRepo.AddClaim(newClaim);
                            keepRunning = false;
                            Console.WriteLine("Claim successfully added.");
                            Console.ReadLine();
                        }
                        else
                        {
                            keepRunning = false;
                        }
                    }
                }
            }
        }
        public void SeedQueue()
        {
            Claims.NextClaim = 1;
            Claims _claim1 = new Claims(TypeOfClaim.Car, "rear ending", 15000, new DateTime(2020, 01, 01), new DateTime(2020, 1, 30));
            Claims _claim2 = new Claims(TypeOfClaim.Home, "The Floods man, The floods", 170000, new DateTime(2020, 02, 02), new DateTime(2020, 5, 30));
            Claims _claim3 = new Claims(TypeOfClaim.Theft, "Election stolen", 80000000, new DateTime(2020, 11, 04), new DateTime(2020, 12, 12));
            Claims _claim4 = new Claims(TypeOfClaim.Car, "Small Scratch", 149.35m, new DateTime(2020, 05, 07), new DateTime(2020, 05, 15));
            _claimsRepo = new ClaimsRepo();
            _claimsRepo.AddClaim(_claim1);
            _claimsRepo.AddClaim(_claim2);
            _claimsRepo.AddClaim(_claim3);
            _claimsRepo.AddClaim(_claim4);


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
        public bool GetNumberInput(out decimal i)//takes an int parameter, returns true if int assigned, returns false otherwise. Sets int to zero if no value assigned.
        {
            string input;
            bool isDecimal = false;
            while (!isDecimal)
            {
                input = Console.ReadLine();
                isDecimal = decimal.TryParse(input, out i);
                if (isDecimal)
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
        public bool GetDateTime(string dateName, out DateTime dateTime)
        {
            bool isDate = false;
            while (!isDate)
            {
                char[] seperator = { '/', ' ', '-' };
                Console.WriteLine($"Please enter {dateName} in the following format: Day/Month/Year ex: 08/20/1994 or type x to exit");
                string input = Console.ReadLine();
                string[] dateComponetents = input.Split(seperator);
                if (input.Trim().ToLower() == "x")
                {
                    dateTime = DateTime.Now;
                    return false;
                }
                else
                {
                    try
                    {
                        int.TryParse(dateComponetents[0], out int month);
                        int.TryParse(dateComponetents[1], out int date);
                        int.TryParse(dateComponetents[2], out int year);
                        dateTime = new DateTime(year, month, date);
                        isDate = true;
                        return isDate;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("invalid date format");
                        Console.ReadLine();
                        
                    }
                }
            }
            dateTime = DateTime.Now;
            return false;

        }
    }
}
