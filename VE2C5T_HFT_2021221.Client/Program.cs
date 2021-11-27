using System;
using System.Linq;
using VE2C5T_HFT_2021221.Models;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;
using ConsoleTools;
using System.Threading;
using System.Collections.Generic;

namespace VE2C5T_HFT_2021221.Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string logo = @"  ____ ________ _       __  ______   _____   ____    __ _____ _____ ____    ____   __  _   _ ____   ___  ____  
 / ___|__  /_ _| |     /_/ / ___\ \ / /_ _| |  _ \ _/_/|_   _| ____|  _ \  / ___| /_/ | \ | |  _ \ / _ \|  _ \ 
 \___ \ / / | || |     /_\| |  _ \ V / | |  | |_) | ____|| | |  _| | |_) | \___ \ /_\ |  \| | | | | | | | |_) |
  ___) / /_ | || |___ / _ \ |_| | | |  | |  |  __/|  _|_ | | | |___|  _ <   ___) / _ \| |\  | |_| | |_| |  _ < 
 |____/____|___|_____/_/_\_\____|_|_|_|___| |_|  _|_____||_| |_____|_| \_\ |____/_/ \_\_| \_|____/ \___/|_| \_\
 \ \   / / ____|___ \ / ___| ___|_   _|         | | | |  ___|_   _|                                            
  \ \ / /|  _|   __) | |   |___ \ | |    _____  | |_| | |_    | |                                              
   \ V / | |___ / __/| |___ ___) || |   |_____| |  _  |  _|   | |                                              
    \_/  |_____|_____|\____|____/ |_|           |_| |_|_|     |_|                                              
                                                                                                               ";


            Thread.Sleep(10000);

            RestService rest = new RestService("http://localhost:60557");

            var pets = rest.Get<Pet>("pet").ToList();
            var vets = rest.Get<Vet>("vet");
            var petowners = rest.Get<PetOwner>("petowner");

            Console.WriteLine(logo, Color.BlueViolet);
            var Menu = new ConsoleMenu(args, level:0)
            .Add("Pets - ReadAll", () => ReadAllPets(pets))
            .Add("Pets - ReadOne", () => ReadPets())
            .Add("Pets - Create", () => CreatePets())
            .Add("Pets - Update", () => UpdatePets())
            .Add("Pets - Delete", () => DeletePets())
            .Add("Vets - ReadAll", () => ReadAllVets())
            .Add("Vets - ReadOne", () => ReadVets())
            .Add("Vets - Create", () => CreateVets())
            .Add("Vets - Update", () => UpdateVets())
            .Add("Vets - Delete", () => DeletePets())
            .Add("PetOwners - ReadAll", () => ReadAllPetOwners())
            .Add("PetOwnersets - ReadOne", () => ReadPetOwners())
            .Add("PetOwners - Create", () => CreatePetOwners())
            .Add("PetOwners - Update", () => UpdatePetOwners())
            .Add("PetOwners - Delete", () => DeletePetOweners())
            .Add("EXIT", () => Environment.Exit(0))
            .Configure(config =>
            {
                config.Selector = "---->> ";
                config.Title = "PETS - VETS - PETOWNERS";
                config.EnableWriteTitle = true;
                config.SelectedItemBackgroundColor = ConsoleColor.White;
                config.SelectedItemForegroundColor = ConsoleColor.DarkRed;
                config.WriteHeaderAction = () => Console.WriteLine("Please Choose an option", Color.BlueViolet);
            });

            Menu.Show();

            ;
        }

        //PETS
        public static void ReadAllPets(List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("All Pets List", Color.BlueViolet);
            System.Console.WriteLine(String.Format($"|{"ID",2}|{"NAME",20}|{"Species",20}|{"Weight",7}|{"Age",3}|{"MonthlyCostInHUF",16}|{"PetOwnerId",10}|{"VetId",5}|"),Color.BlueViolet);
            System.Console.WriteLine();
            foreach (var pet in pets)
            {
                System.Console.WriteLine((String.Format("|{0,2}|{1,20}|{2,20}|{3,7}|{4,3}|{5,16}|{6,10}|{7,5}|", pet.Id, pet.Name, pet.Species, pet.Weight, pet.Age, pet.MonthlyCostInHUF, pet.PetOwnerId, pet.VetId)), Color.BlueViolet);
            }
            System.Console.WriteLine();
            System.Console.WriteLine("BACK - ENTER", Color.DarkRed);
            Console.ReadLine();
        }
        public static void ReadPets()
        {

        }
        public static void CreatePets()
        {

        }
        public static void UpdatePets()
        {

        }
        public static void DeletePets()
        {

        }

        //VETS
        public static void ReadAllVets()
        {

        }
        public static void ReadVets()
        {

        }
        public static void CreateVets()
        {

        }
        public static void UpdateVets()
        {

        }
        public static void DeleteVets()
        {

        }

        //PETOWNERS
        public static void ReadAllPetOwners()
        {

        }
        public static void ReadPetOwners()
        {

        }
        public static void CreatePetOwners()
        {

        }
        public static void UpdatePetOwners()
        {

        }
        public static void DeletePetOweners()
        {

        }
    }
}
