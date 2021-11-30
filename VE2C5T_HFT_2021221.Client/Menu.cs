using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;
using VE2C5T_HFT_2021221.Models;

namespace VE2C5T_HFT_2021221.Client
{
    class Menu
    {
        string logo = @"                                                                                                                                                                                                                                      
  _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ 
 |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|
 | / ___|__  /_ _| |     /_/ / ___\ \ / /_ _| |  _ \ _/_/|_   _| ____|  _ \  / ___| /_/ | \ | |  _ \ / _ \|  _ \| | 
 | \___ \ / / | || |     /_\| |  _ \ V / | |  | |_) | ____|| | |  _| | |_) | \___ \ /_\ |  \| | | | | | | | |_) | | 
 | |___) / /_ | || |___ / _ \ |_| | | |  | |  |  __/|  _|_ | | | |___|  _ <   ___) / _ \| |\  | |_| | |_| |  _ <| | 
 | |____/____|___|_____/_/ \_\____| |_| |___| |_|   |_____||_| |_____|_| \_\ |____/_/ \_\_| \_|____/ \___/|_| \_\ | 
 |_|_     _______ ____   ____ ____ _____           _   _ _____ _____                                            |_| 
 | \ \   / / ____|___ \ / ___| ___|_   _|         | | | |  ___|_   _|                                           | | 
 | |\ \ / /|  _|   __) | |   |___ \ | |    _____  | |_| | |_    | |                                             | | 
 | | \ V / | |___ / __/| |___ ___) || |   |_____| |  _  |  _|   | |                                             | | 
 | |  \_/  |_____|_____|\____|____/ |_|           |_| |_|_|     |_|                                             | | 
 |_|___ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ __|_| 
 |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|";

        string actualOption = "";
        string actualTable = "";
        RestService rest;

        public Menu()
        {
            rest = new RestService("http://localhost:60557");

            while (actualOption != "7")
            {
                actualOption = MainMenu();
                if (actualOption != "7")
                {
                    actualTable = ChooseTable();

                    switch (actualOption)
                    {
                        case "1":
                            Case_1_ReadAll();
                            break;
                        case "2":
                            Case_2_ReadOne();
                            break;
                        case "3":
                            Case_3_Create();
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        default:
                            break;
                    }

                    actualTable = "";
                }
                else
                {
                    //ELKÖSZÖNÉS
                }
            }
        }

        private string MainMenu()
        {
            Console.Clear();
            Console.Title = "MainMenu";
            Console.WriteLine(logo, Color.DarkOliveGreen);

            System.Console.WriteLine();
            System.Console.WriteLine();

            Console.Write("   [", Color.BlueViolet); Console.Write(" 1 ", Color.OrangeRed); Console.Write("]",Color.BlueViolet);
            Console.WriteLine("  READ ALL", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 2 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  READ", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 3 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  CREATE", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 4 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  UPDATE", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 5 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  DELETE", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 6 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  NON CRUDS", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 7 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  EXIT", Color.OrangeRed);

            System.Console.WriteLine();
            System.Console.WriteLine();
            Console.Write("  SELECT YOUR OPTION: ", Color.GreenYellow);
            return Console.ReadLine();
            
        }

        private string ChooseTable()
        {
            while (actualTable != "1" && actualTable != "2" && actualTable != "3")
            {
                Console.Clear();
                Console.Title = "SubMenu";
                System.Console.WriteLine();
                System.Console.WriteLine("  Choose a table", Color.GreenYellow);
                Console.Write("   [", Color.BlueViolet); Console.Write(" 1 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
                Console.WriteLine("  PET", Color.OrangeRed);

                Console.Write("   [", Color.BlueViolet); Console.Write(" 2 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
                Console.WriteLine("  PETOWNER", Color.OrangeRed);

                Console.Write("   [", Color.BlueViolet); Console.Write(" 3 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
                Console.WriteLine("  VET", Color.OrangeRed);

                System.Console.WriteLine();
                System.Console.WriteLine();
                Console.Write("  SELECT YOUR OPTION: ", Color.GreenYellow);
                actualTable = Console.ReadLine();
            }
            return actualTable;
        }

        //CASE - 1 - Read All
        private void Case_1_ReadAll()
        {
            switch (actualTable)
            {
                case "1":
                    Case_1_1_Pet_ReadAll();
                    break;
                case "2":
                    Case_1_2_PetOwner_ReadAll();
                    break;
                case "3":
                    Case_1_3_Vet_ReadAll();
                    break;
                default:
                    break;
            }
        }
        private void Case_1_1_Pet_ReadAll()
        {
            var pets = rest.Get<Pet>("pet").ToList();
            Console.Clear();
            Console.WriteLine("Pet's List", Color.GreenYellow);
            Console.WriteLine(String.Format($"|{"ID",4}|{"NAME",20}|{"Species",20}|{"Weight",8}|{"Age",5}|{"MonthlyCostInHUF",16}|{"PetOwnerId",12}|{"VetId",7}|"), Color.BlueViolet);
            Console.WriteLine();
            foreach (var actual in pets)
            {
                System.Console.WriteLine((String.Format("|{0,4}|{1,20}|{2,20}|{3,8}|{4,5}|{5,16}|{6,12}|{7,7}|", actual.Id, actual.Name, actual.Species, actual.Weight, actual.Age, actual.MonthlyCostInHUF, actual.PetOwnerId, actual.VetId)), Color.BlueViolet);
            }
            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_1_2_PetOwner_ReadAll()
        {
            var petOwners = rest.Get<PetOwner>("petowner").ToList();
            Console.Clear();
            Console.WriteLine("PetOwner's List", Color.GreenYellow);
            Console.WriteLine(String.Format($"|{"ID",4}|{"NAME",20}|{"PhoneNumber",15}|{"Age",5}|{"SalaryInHUF",13}|"),Color.BlueViolet);
            Console.WriteLine();
            foreach (var actual in petOwners)
            {
                System.Console.WriteLine((String.Format("|{0,4}|{1,20}|{2,15}|{3,5}|{4,13}", actual.Id, actual.Name, actual.PhoneNumber, actual.Age, actual.SalaryInHUF)), Color.BlueViolet);
            }
            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_1_3_Vet_ReadAll()
        {
            var vets = rest.Get<Vet>("vet").ToList();
            Console.Clear();
            Console.WriteLine("Vet's List", Color.GreenYellow);
            Console.WriteLine(String.Format($"|{"ID",4}|{"NAME",20}|{"PhoneNumber",15}|{"Age",5}|{"SalaryInHUF",13}|"), Color.BlueViolet);
            Console.WriteLine();
            foreach (var actual in vets)
            {
                System.Console.WriteLine((String.Format("|{0,4}|{1,20}|{2,15}|{3,5}|{4,13}", actual.Id, actual.Name, actual.PhoneNumber, actual.Age, actual.SalaryInHUF)), Color.BlueViolet);
            }
            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }


        //CASE - 2 - Read One
        private void Case_2_ReadOne()
        {
            switch (actualTable)
            {
                case "1":
                    Case_2_1_Pet_ReadOne();
                    break;
                case "2":
                    Case_2_2_PetOwner_ReadOne();
                    break;
                case "3":
                    Case_2_3_Vet_ReadOne();
                    break;
                default:
                    break;
            }
        }
        private void Case_2_1_Pet_ReadOne()
        {
            var pets = rest.Get<Pet>("pet").ToList();
            Console.Clear();
            Console.WriteLine("Please select an exists ID of Pet\nReal indexes: ", Color.GreenYellow);
            foreach (var item in pets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var pet = rest.Get<Pet>(index, "pet");

            Console.WriteLine("Details of Pet", Color.GreenYellow);

            Console.WriteLine($"ID: {pet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {pet.Name}", Color.FloralWhite);
            Console.WriteLine($"Species: {pet.Species}", Color.FloralWhite);
            Console.WriteLine($"Weight: {pet.Weight}", Color.FloralWhite);
            Console.WriteLine($"Age: {pet.Age}", Color.FloralWhite);
            Console.WriteLine($"MonthlyCostInHUF: {pet.MonthlyCostInHUF}", Color.FloralWhite);
            Console.WriteLine($"PetOwnerId: {pet.PetOwner}", Color.FloralWhite);
            Console.WriteLine($"VetId: {pet.Vet}", Color.FloralWhite);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_2_2_PetOwner_ReadOne()
        {
            var petowners = rest.Get<PetOwner>("petowner").ToList();
            Console.Clear();
            Console.WriteLine("Please select an exists ID of PetOwner\nReal indexes: ", Color.GreenYellow);
            foreach (var item in petowners)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var owner = rest.Get<PetOwner>(index, "petowner");

            Console.WriteLine("Details of PetOwner", Color.GreenYellow);

            Console.WriteLine($"ID: {owner.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {owner.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {owner.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {owner.Age}", Color.FloralWhite);
            Console.WriteLine($"SalaryInHUF: {owner.SalaryInHUF}", Color.FloralWhite);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_2_3_Vet_ReadOne()
        {
            var vets = rest.Get<Vet>("vet").ToList();
            Console.Clear();
            Console.WriteLine("Please select an exists ID of Vet\nReal indexes: ", Color.GreenYellow);
            foreach (var item in vets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var vet = rest.Get<Vet>(index, "vet");

            Console.WriteLine("Details of PetOwner", Color.GreenYellow);

            Console.WriteLine($"ID: {vet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {vet.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {vet.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {vet.Age}", Color.FloralWhite);
            Console.WriteLine(($"SalaryInHUF: {vet.SalaryInHUF}"), Color.FloralWhite);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }

        //CASE - 3 - Create
        private void Case_3_Create()
        {
            switch (actualTable)
            {
                case "1":
                    Case_3_1_Create_Pet();
                    break;
                case "2":
                    Case_3_2_Create_PetOwner();
                    break;
                case "3":
                    Case_3_3_Create_Vet();
                    break;
                default:
                    break;
            }
        }
        private void Case_3_1_Create_Pet()
        {
            Console.Clear();
            Console.WriteLine("Creating a new PET object", Color.GreenYellow);
            Console.WriteLine();
            Console.Write("The new pet's name: ", Color.FloralWhite);
            string name = Console.ReadLine();

            Console.Write("The new pet's species: ", Color.FloralWhite);
            string species = Console.ReadLine();

            Console.Write("The new pet's weight: ", Color.FloralWhite);
            int weight = int.Parse(Console.ReadLine());

            Console.Write("The new pet's age: ", Color.FloralWhite);
            int age = int.Parse(Console.ReadLine());

            Console.Write("The new pet's monthly cost in HUF: ", Color.FloralWhite);
            int cost = int.Parse(Console.ReadLine());

            Console.Write("The new pet's PetOwnerId: ", Color.FloralWhite);
            int ownerID = int.Parse(Console.ReadLine());

            Console.Write("The new pet's VetId: ", Color.FloralWhite);
            int vetID = int.Parse(Console.ReadLine());

            Pet newPet = new Pet(name, species, weight, age, cost, ownerID, vetID);
            rest.Post<Pet>(newPet, "pet");

            Console.WriteLine($"{name} inserted to Pet table", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_3_2_Create_PetOwner()
        {
            Console.Clear();
            Console.WriteLine("Creating a new PetOwner object", Color.GreenYellow);
            Console.WriteLine();

            Console.Write("The new owner's Name: ", Color.FloralWhite);
            string name = Console.ReadLine();

            Console.Write("The new owner's PhoneNumber: ", Color.FloralWhite);
            string PhoneNumber = Console.ReadLine();

            Console.Write("The new owner's Age: ", Color.FloralWhite);
            int Age = int.Parse(Console.ReadLine());

            Console.Write("The new owner's SalaryInHUF: ", Color.FloralWhite);
            int SalaryInHUF = int.Parse(Console.ReadLine());

            PetOwner owner = new PetOwner(name, PhoneNumber, Age, SalaryInHUF);
            rest.Post(owner, "owner");
            Console.WriteLine($"{name} inserted to PetOwner table", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();

        }
        private void Case_3_3_Create_Vet()
        {
            Console.Clear();
            Console.WriteLine("Creating a new Vet object", Color.GreenYellow);
            Console.WriteLine();

            Console.Write("The new vet's Name: ", Color.FloralWhite);
            string name = Console.ReadLine();

            Console.Write("The new vet's PhoneNumber: ", Color.FloralWhite);
            string PhoneNumber = Console.ReadLine();

            Console.Write("The new vet's Age: ", Color.FloralWhite);
            int Age = int.Parse(Console.ReadLine());

            Console.Write("The new vet's SalaryInHUF: ", Color.FloralWhite);
            int SalaryInHUF = int.Parse(Console.ReadLine());

            Vet vet = new Vet(name, PhoneNumber, Age, SalaryInHUF);
            rest.Post(vet, "vet");
            Console.WriteLine($"{name} inserted to Vet table", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }

    }
}
