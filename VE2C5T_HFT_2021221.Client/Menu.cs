using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;
using VE2C5T_HFT_2021221.Models;
using System.Runtime.InteropServices;

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
                if (actualOption == "6")
                {
                    Case_6_NonCRUDS();
                }
                else if (actualOption != "7")
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
                            Case_4_Update();
                            break;
                        case "5":
                            Case_5_Delete();
                            break;
                        default:
                            break;
                    }

                    actualTable = "";
                }
                else
                {
                    Exit();
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
                    Console.Title = "READ ALL - PET";
                    Case_1_1_Pet_ReadAll();
                    break;
                case "2":
                    Console.Title = "READ ALL - PETOWNER";
                    Case_1_2_PetOwner_ReadAll();
                    break;
                case "3":
                    Console.Title = "READ ALL - VET";
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
                    Console.Title = "READ - PET";
                    Case_2_1_Pet_ReadOne();
                    break;
                case "2":
                    Console.Title = "READ - PETOWNER";
                    Case_2_2_PetOwner_ReadOne();
                    break;
                case "3":
                    Console.Title = "READ - VET";
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
            Console.WriteLine($"PetOwnerId: {pet.PetOwnerId}", Color.FloralWhite);
            Console.WriteLine($"VetId: {pet.VetId}", Color.FloralWhite);

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
                    Console.Title = "CREATE - PET";
                    Case_3_1_Create_Pet();
                    break;
                case "2":
                    Console.Title = "CREATE - PETOWNER";
                    Case_3_2_Create_PetOwner();
                    break;
                case "3":
                    Console.Title = "CREATE - VET";
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

        //CASE - 4 - Update
        private void Case_4_Update()
        {
            switch (actualTable)
            {
                case "1":
                    Console.Title = "UPDATE - PET";
                    Case_4_1_Update_Pet();
                    break;
                case "2":
                    Console.Title = "UPDATE - PETOWNER";
                    Case_4_2_Update_PetOwner();
                    break;
                case "3":
                    Console.Title = "UPDATE - VET";
                    Case_4_3_Update_Vet();
                    break;
                default:
                    break;
            }
        }
        private void Case_4_1_Update_Pet()
        {
            var pets = rest.Get<Pet>("pet").ToList();
            Console.Clear();
            Console.WriteLine("Updating a Pet object.", Color.GreenYellow);

            Console.WriteLine("Please select an exists ID of PetTable\nReal indexes: ", Color.GreenYellow);
            foreach (var item in pets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());
            var pet = rest.Get<Pet>(index, "pet");

            Console.WriteLine("\nDetails of Pet what you want to update.", Color.GreenYellow);

            Console.WriteLine($"ID: {pet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {pet.Name}", Color.FloralWhite);
            Console.WriteLine($"Species: {pet.Species}", Color.FloralWhite);
            Console.WriteLine($"Weight: {pet.Weight}", Color.FloralWhite);
            Console.WriteLine($"Age: {pet.Age}", Color.FloralWhite);
            Console.WriteLine($"MonthlyCostInHUF: {pet.MonthlyCostInHUF}", Color.FloralWhite);
            Console.WriteLine($"PetOwnerId: {pet.PetOwnerId}", Color.FloralWhite);
            Console.WriteLine($"VetId: {pet.VetId}", Color.FloralWhite);

            Console.WriteLine("\nNEW datas", Color.GreenYellow);

            Console.Write($"{pet.Name} new name: ", Color.FloralWhite);
            string name = Console.ReadLine();
            Console.Write($"{pet.Name} new species: ", Color.FloralWhite);
            string species = Console.ReadLine();
            Console.Write($"{pet.Name} new weight: ", Color.FloralWhite);
            int weight = int.Parse(Console.ReadLine());
            Console.Write($"{pet.Name} new age: ", Color.FloralWhite);
            int age = int.Parse(Console.ReadLine());
            Console.Write($"{pet.Name} new monthly cost in HUF: ", Color.FloralWhite);
            int cost = int.Parse(Console.ReadLine());
            Console.Write($"{pet.Name} new PetOwnerId: ", Color.FloralWhite);
            int ownerID = int.Parse(Console.ReadLine());
            Console.Write($"{pet.Name} new VetId: ", Color.FloralWhite);
            int vetID = int.Parse(Console.ReadLine());

            Pet newPet = new Pet() { Id=pet.Id, Name = name, Species = species, Weight = weight, Age = age, MonthlyCostInHUF = cost, PetOwnerId = ownerID, VetId = vetID };

            rest.Put<Pet>(newPet, "pet");

            Console.WriteLine($"Update is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();

        }
        private void Case_4_2_Update_PetOwner()
        {
            var petowners = rest.Get<PetOwner>("petowner").ToList();
            Console.Clear();
            Console.WriteLine("Updating a PetOwner object.", Color.GreenYellow);
            foreach (var item in petowners)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var owner = rest.Get<PetOwner>(index, "petowner");

            Console.WriteLine("\nDetails of PetOwner what you want to update.", Color.GreenYellow);

            Console.WriteLine($"ID: {owner.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {owner.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {owner.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {owner.Age}", Color.FloralWhite);
            Console.WriteLine($"SalaryInHUF: {owner.SalaryInHUF}", Color.FloralWhite);

            Console.WriteLine("\nNEW datas", Color.GreenYellow);

            Console.Write($"{owner.Name} new Name: ", Color.FloralWhite);
            string name = Console.ReadLine();
            Console.Write($"{owner.Name} new PhoneNumber: ", Color.FloralWhite);
            string PhoneNumber = Console.ReadLine();
            Console.Write($"{owner.Name} new Age: ", Color.FloralWhite);
            int Age = int.Parse(Console.ReadLine());
            Console.Write($"{owner.Name} new SalaryInHUF: ", Color.FloralWhite);
            int SalaryInHUF = int.Parse(Console.ReadLine());

            PetOwner newOwner = new PetOwner() { Id = owner.Id, Name = name, PhoneNumber = PhoneNumber, Age = Age, SalaryInHUF = SalaryInHUF };

            rest.Put<PetOwner>(newOwner, "petowner");

            Console.WriteLine($"Update is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_4_3_Update_Vet()
        {
            var vets = rest.Get<Vet>("vet").ToList();
            Console.Clear();
            Console.WriteLine("Updating a Vet object.", Color.GreenYellow);
            foreach (var item in vets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var vet = rest.Get<Vet>(index, "vet");

            Console.WriteLine("\nDetails of Vet what you want to update.", Color.GreenYellow);

            Console.WriteLine($"ID: {vet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {vet.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {vet.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {vet.Age}", Color.FloralWhite);
            Console.WriteLine($"SalaryInHUF: {vet.SalaryInHUF}", Color.FloralWhite);

            Console.WriteLine("\nNEW datas", Color.GreenYellow);

            Console.Write($"{vet.Name} new Name: ", Color.FloralWhite);
            string name = Console.ReadLine();
            Console.Write($"{vet.Name} new PhoneNumber: ", Color.FloralWhite);
            string PhoneNumber = Console.ReadLine();
            Console.Write($"{vet.Name} new Age: ", Color.FloralWhite);
            int Age = int.Parse(Console.ReadLine());
            Console.Write($"{vet.Name} new SalaryInHUF: ", Color.FloralWhite);
            int SalaryInHUF = int.Parse(Console.ReadLine());

            Vet newVet = new Vet() { Id = vet.Id, Name = name, PhoneNumber = PhoneNumber, Age = Age, SalaryInHUF = SalaryInHUF };

            rest.Put<Vet>(newVet, "vet");

            Console.WriteLine($"Update is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }

        //CASE - 5 - Delete
        private void Case_5_Delete()
        {
            switch (actualTable)
            {
                case "1":
                    Console.Title = "DELETE - PET";
                    Case_5_1_Delete_Pet();
                    break;
                case "2":
                    Console.Title = "DELETE - PETOWNER";
                    Case_5_2_Delete_PetOwner();
                    break;
                case "3":
                    Console.Title = "DELETE - VET";
                    Case_5_3_Delete_Vet();
                    break;
                default:
                    break;
            }
        }
        private void Case_5_1_Delete_Pet()
        {
            var pets = rest.Get<Pet>("pet").ToList();
            Console.Clear();
            Console.WriteLine("Deleting a Pet object.", Color.GreenYellow);

            Console.WriteLine("Please select an exists ID of PetTable\nReal indexes: ", Color.GreenYellow);
            foreach (var item in pets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());
            var pet = rest.Get<Pet>(index, "pet");

            Console.WriteLine("\nDetails of Pet what you Deleted.", Color.GreenYellow);

            Console.WriteLine($"ID: {pet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {pet.Name}", Color.FloralWhite);
            Console.WriteLine($"Species: {pet.Species}", Color.FloralWhite);
            Console.WriteLine($"Weight: {pet.Weight}", Color.FloralWhite);
            Console.WriteLine($"Age: {pet.Age}", Color.FloralWhite);
            Console.WriteLine($"MonthlyCostInHUF: {pet.MonthlyCostInHUF}", Color.FloralWhite);
            Console.WriteLine($"PetOwnerId: {pet.PetOwnerId}", Color.FloralWhite);
            Console.WriteLine($"VetId: {pet.VetId}", Color.FloralWhite);
            rest.Delete(index, "pet");

            Console.WriteLine();
            Console.WriteLine($"Delete is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();

        }
        private void Case_5_2_Delete_PetOwner()
        {
            var petowners = rest.Get<PetOwner>("petowner").ToList();
            Console.Clear();
            Console.WriteLine("Deleting a PetOwner object.", Color.GreenYellow);
            foreach (var item in petowners)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var owner = rest.Get<PetOwner>(index, "petowner");

            Console.WriteLine("\nDetails of PetOwner what you Deleted.", Color.GreenYellow);

            Console.WriteLine($"ID: {owner.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {owner.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {owner.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {owner.Age}", Color.FloralWhite);
            Console.WriteLine($"SalaryInHUF: {owner.SalaryInHUF}", Color.FloralWhite);

            rest.Delete(index, "petowner");

            Console.WriteLine();
            Console.WriteLine($"Delete is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();

        }
        private void Case_5_3_Delete_Vet()
        {
            var vets = rest.Get<Vet>("vet").ToList();
            Console.Clear();
            Console.WriteLine("Deleting a Vet object.", Color.GreenYellow);
            foreach (var item in vets)
            {
                Console.Write($"{item.Id} | ", Color.BlueViolet);
            }
            System.Console.WriteLine();
            Console.Write("INDEX: ", Color.GreenYellow);
            int index = int.Parse(Console.ReadLine());

            var vet = rest.Get<Vet>(index, "vet");

            Console.WriteLine("\nDetails of Vet what you Deleted.", Color.GreenYellow);

            Console.WriteLine($"ID: {vet.Id}", Color.FloralWhite);
            Console.WriteLine($"Name: {vet.Name}", Color.FloralWhite);
            Console.WriteLine($"PhoneNumber: {vet.PhoneNumber}", Color.FloralWhite);
            Console.WriteLine($"Age: {vet.Age}", Color.FloralWhite);
            Console.WriteLine($"SalaryInHUF: {vet.SalaryInHUF}", Color.FloralWhite);

            rest.Delete(index, "vet");

            Console.WriteLine();
            Console.WriteLine($"Delete is done..", Color.GreenYellow);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }


        //NonCruds - 6
        private void NonCrud_SUbMenu()
        {
            Console.Clear();
            Console.Write("   [", Color.BlueViolet); Console.Write(" 1 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Most Experience Pet And His Owner", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 2 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Group Pets By Species And Their AVGage", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 3 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Group Pets By Species And Their AVGcost", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 4 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Which Vet Has The Most Fattes tPet", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 5 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Which Vet Treats More Than One Pet And How Many", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 6 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Who Has The Most Pets And How Many", Color.OrangeRed);

            Console.Write("   [", Color.BlueViolet); Console.Write(" 6 ", Color.OrangeRed); Console.Write("]", Color.BlueViolet);
            Console.WriteLine("  Who Spends The Most On Animals How Many", Color.OrangeRed);

            Console.Write("Select your option: ");
        }
        private void Case_6_NonCRUDS()
        {
            Console.Title = "NONCRUDS";
            NonCrud_SUbMenu();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Title = "MostExperiencePetAndHisOwner";
                    Case_1_NonCruds();
                    break;
                case "2":
                    Console.Title = "GrupPetsBySpeciesAndTheirAVGage";
                    Case_2_NonCruds();
                    break;
                case "3":
                    Console.Title = "GrupPetsBySpeciesAndTheirAVGcost";
                    Case_3_NonCruds();
                    break;
                case "4":
                    Console.Title = "WhichVetHasTheMostFattestPet";
                    Case_4_NonCruds();
                    break;
                case "5":
                    Console.Title = "WhichVetTreatsMoreThanOnePetAndHowMany";
                    Case_5_NonCruds();
                    break;
                case "6":
                    Console.Title = "WhoHasTheMostPetsAndHowMany";
                    Case_6_NonCruds();
                    break;
                case "6":
                    Console.Title = "WhoSpendsTheMostOnAnimalsHowMany";
                    Case_7_NonCruds();
                    break;
                default:
                    break;
            }
        }
        private void Case_1_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<Pet, PetOwner>>("stat/MostExperiencePetAndHisOwner").ToList();

            Console.WriteLine("Details of most experience pet and his owner");
            Console.WriteLine("Details of pet");
            Console.WriteLine("Pet Id: "+ q[0].Key.Id);
            Console.WriteLine("Pet Name: " + q[0].Key.Name);
            Console.WriteLine("Pet Age: " + q[0].Key.Age);
            Console.WriteLine("Pet MonthlyCostInHUF: " + q[0].Key.MonthlyCostInHUF);
            Console.WriteLine("Pet Species: " + q[0].Key.Species);
            Console.WriteLine("Pet VetId: " + q[0].Key.VetId);
            Console.WriteLine("Pet PetOwnerId " + q[0].Key.PetOwnerId);

            Console.WriteLine("\nDetails of owner");
            Console.WriteLine("Owner Id: " + q[0].Value.Id);
            Console.WriteLine("Owner Name: " + q[0].Value.Name);
            Console.WriteLine("Owner Age: " + q[0].Value.Age);
            Console.WriteLine("Owner PhoneNumber: " + q[0].Value.PhoneNumber);
            Console.WriteLine("Owner SalaryInHUF: " + q[0].Value.SalaryInHUF);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_2_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<string, int>>("stat/GrupPetsBySpeciesAndTheirAVGage").ToList();

            Console.WriteLine(String.Format("|{0,25}|{1,15}|", "Species", "AVG Age"), Color.GreenYellow);
            foreach (var item in q)
            {
                Console.WriteLine((String.Format("|{0,25}|{1,15}|", item.Key.ToString(), item.Value.ToString())), Color.BlueViolet);
            }
            
            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_3_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<string, int>>("stat/GrupPetsBySpeciesAndTheirAVGcost").ToList();

            Console.WriteLine((String.Format("|{0,25}|{1,15}|", "Species", "AVG Cost")), Color.GreenYellow);
            foreach (var item in q)
            {
                Console.WriteLine((String.Format("|{0,25}|{1,15}|", item.Key.ToString(), item.Value.ToString())), Color.BlueViolet);
            }

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_4_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<Vet, Pet>>("stat/WhichVetHasTheMostFattestPet").ToList().ToList();

            Console.WriteLine("Details Vet and his/her pet, who is the fattest pet.");
            Console.WriteLine("Details of pet");
            Console.WriteLine("Pet Id: " + q[0].Value.Id);
            Console.WriteLine("Pet Name: " + q[0].Value.Name);
            Console.WriteLine("Pet Age: " + q[0].Value.Age);
            Console.WriteLine("Pet MonthlyCostInHUF: " + q[0].Value.MonthlyCostInHUF);
            Console.WriteLine("Pet Species: " + q[0].Value.Species);
            Console.WriteLine("Pet VetId: " + q[0].Value.VetId);
            Console.WriteLine("Pet PetOwnerId " + q[0].Value.PetOwnerId);

            Console.WriteLine("\nDetails of vet");
            Console.WriteLine("Vet Id: " + q[0].Key.Id);
            Console.WriteLine("Vet Name: " + q[0].Key.Name);
            Console.WriteLine("Vet Age: " + q[0].Key.Age);
            Console.WriteLine("Vet PhoneNumber: " + q[0].Key.PhoneNumber);
            Console.WriteLine("Vet SalaryInHUF: " + q[0].Key.SalaryInHUF);

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_5_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<string, int>>("stat/WhichVetTreatsMoreThanOnePetAndHowMany").ToList();

            System.Console.WriteLine();
            Console.WriteLine($"The vet of year is {q[0].Key}, who treating {q[0].Value} animals.");

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_6_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<string, int>>("stat/WhoHasTheMostPetsAndHowMany").ToList();

            System.Console.WriteLine();
            System.Console.WriteLine($"The greatest animal lover is {q[0].Key}, who has {q[0].Value} amimals..");

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }
        private void Case_7_NonCruds()
        {
            Console.Clear();
            var q = rest.Get<KeyValuePair<string, int>>("stat/WhoSpendsTheMostOnAnimalsHowMany").ToList();

            System.Console.WriteLine();
            System.Console.WriteLine($"The richest owner who spends a lot of money to animals is {q[0].Key}, who spends {q[0].Value} HUF / Month..");

            Console.WriteLine();
            Console.WriteLine("BACK TO MAIN MENU --> ENTER", Color.GreenYellow);
            Console.ReadLine();
        }



        //case - 7
        public void Exit()
        {
            Console.Clear();

            string logo3 = @"$$\   $$\          $$\ $$\                                                                                                               $$\                  $$\     
$$ | $$  |         $$ |$$ |                                                                                                              $$ |                 $$ |    
$$ |$$  / $$$$$$\  $$ |$$ | $$$$$$\  $$$$$$\$$$$\   $$$$$$\   $$$$$$$\       $$\   $$\ $$$$$$$\  $$$$$$$\   $$$$$$\   $$$$$$\   $$$$$$\  $$ |  $$\  $$$$$$\ $$$$$$\   
$$$$$  / $$  __$$\ $$ |$$ |$$  __$$\ $$  _$$  _$$\ $$  __$$\ $$  _____|      $$ |  $$ |$$  __$$\ $$  __$$\ $$  __$$\ $$  __$$\ $$  __$$\ $$ | $$  |$$  __$$\\_$$  _|  
$$  $$<  $$$$$$$$ |$$ |$$ |$$$$$$$$ |$$ / $$ / $$ |$$$$$$$$ |\$$$$$$\        $$ |  $$ |$$ |  $$ |$$ |  $$ |$$$$$$$$ |$$ /  $$ |$$$$$$$$ |$$$$$$  / $$$$$$$$ | $$ |    
$$ |\$$\ $$   ____|$$ |$$ |$$   ____|$$ | $$ | $$ |$$   ____| \____$$\       $$ |  $$ |$$ |  $$ |$$ |  $$ |$$   ____|$$ |  $$ |$$   ____|$$  _$$<  $$   ____| $$ |$$\ 
$$ | \$$\\$$$$$$$\ $$ |$$ |\$$$$$$$\ $$ | $$ | $$ |\$$$$$$$\ $$$$$$$  |      \$$$$$$  |$$ |  $$ |$$ |  $$ |\$$$$$$$\ $$$$$$$  |\$$$$$$$\ $$ | \$$\ \$$$$$$$\  \$$$$  |
\__|  \__|\_______|\__|\__| \_______|\__| \__| \__| \_______|\_______/        \______/ \__|  \__|\__|  \__| \_______|$$  ____/  \_______|\__|  \__| \_______|  \____/ 
                                                                                                                     $$ |                                             
                                                                                                                     $$ |                                             
                                                                                                                     \__|                                             
$$\       $$\                                         $$\                 $$$\             $$$\                                                                       
$$ |      \__|                                        $$ |                 \$$\             \$$\                                                                      
$$ |  $$\ $$\ $$\    $$\ $$$$$$\  $$$$$$$\   $$$$$$\  $$ |  $$\       $$\   \$$\       $$\   \$$\                                                                     
$$ | $$  |$$ |\$$\  $$  |\____$$\ $$  __$$\ $$  __$$\ $$ | $$  |      \__|   $$ |      \__|   $$ |                                                                    
$$$$$$  / $$ | \$$\$$  / $$$$$$$ |$$ |  $$ |$$ /  $$ |$$$$$$  /              $$ |             $$ |                                                                    
$$  _$$<  $$ |  \$$$  / $$  __$$ |$$ |  $$ |$$ |  $$ |$$  _$$<        $$\   $$  |      $$\   $$  |                                                                    
$$ | \$$\ $$ |   \$  /  \$$$$$$$ |$$ |  $$ |\$$$$$$  |$$ | \$$\       \__|$$$  /       \__|$$$  /       $$\                                                           
\__|  \__|\__|    \_/    \_______|\__|  \__| \______/ \__|  \__|          \___/            \___/        \__|                                                          
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      ";


            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            System.Console.WriteLine(logo3, Color.MediumVioletRed);


            Console.ReadLine();
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
    }
}
