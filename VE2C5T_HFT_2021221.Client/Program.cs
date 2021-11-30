using System;
using System.Linq;
using VE2C5T_HFT_2021221.Models;
using System.Threading;
using System.Collections.Generic;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;

namespace VE2C5T_HFT_2021221.Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Thread.Sleep(15000);

            RestService rest = new RestService("http://localhost:60557");

            //var pets = rest.Get<Pet>("pet").ToList();
            //var vets = rest.Get<Vet>("vet");
            //var petowners = rest.Get<PetOwner>("petowner");

            
            Menu menu = new Menu();

        }
    }
}
