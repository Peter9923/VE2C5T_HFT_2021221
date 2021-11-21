using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VE2C5T_HFT_2021221.Logic;
using VE2C5T_HFT_2021221.Models;
using VE2C5T_HFT_2021221.Repository;

namespace VE2C5T_HFT_2021221.Test
{
    [TestFixture]
    class Pet_Tests
    {

        PetLogic petLogic;

        public Pet_Tests()
        {
            var mockPetRepo = new Mock<IPetRepository>();

            PetOwner owner1 = new PetOwner() { Id = 1, Name = "Szilágyi Péter", PhoneNumber = "+36204516718", Age = 22, SalaryInHUF = 220000 };
            PetOwner owner2 = new PetOwner() { Id = 2, Name = "Neumann Norbert", PhoneNumber = "+36301234567", Age = 23, SalaryInHUF = 10000 };
            PetOwner owner3 = new PetOwner() { Id = 3, Name = "Triff Ádám", PhoneNumber = "+36207654321", Age = 22, SalaryInHUF = 20000 };

            Vet vet1 = new Vet() { Id = 1, Name = "Dr. Soós Ferenc", PhoneNumber = "+36309513506", SalaryInHUF = 300000, Age = 30 };
            Vet vet2 = new Vet() { Id = 2, Name = "Dr. Gipsz Jakab", PhoneNumber = "+36209874562", SalaryInHUF = 10, Age = 50 };
            Vet vet3 = new Vet() { Id = 3, Name = "Dr. Bubó", PhoneNumber = "+36998887766", SalaryInHUF = 10000000, Age = 999 };

            Pet pet1 = new Pet() { Id = 1, Name = "Fibi", Weight = 15, Age = 2, MonthlyCostInHUF = 10000, Species = "Kutya", PetOwnerId = owner1.Id, VetId = vet1.Id, PetOwner = owner1, Vet = vet1 };
            Pet pet2 = new Pet() { Id = 2, Name = "Max", Weight = 20, Age = 10, MonthlyCostInHUF = 12500, Species = "Kutya", PetOwnerId = owner1.Id, VetId = vet3.Id, PetOwner = owner1, Vet = vet3 };
            Pet pet3 = new Pet() { Id = 3, Name = "Gábor", Species = "Macska", Weight = 5, Age = 8, MonthlyCostInHUF = 3500, PetOwnerId = owner2.Id, VetId = vet2.Id, PetOwner = owner2, Vet = vet2 };
            Pet pet4 = new Pet() { Id = 4, Name = "Némó", Species = "Hal", Weight = 0.2, Age = 1, MonthlyCostInHUF = 2000, PetOwnerId = owner3.Id, VetId = vet3.Id, PetOwner = owner3, Vet = vet3 };
            Pet pet5 = new Pet() { Id = 5, Name = "Charlie", Species = "Csimpánz", Weight = 50, Age = 25, MonthlyCostInHUF = 40000, PetOwnerId = owner1.Id, VetId = vet2.Id, PetOwner = owner1, Vet = vet2 };
            Pet pet6 = new Pet() { Id = 6, Name = "Kis Krampusz", Species = "Kutya", Weight = 20, Age = 15, MonthlyCostInHUF = 10000, PetOwnerId = owner2.Id, VetId = vet1.Id, PetOwner = owner2, Vet = vet1 };
            Pet pet7 = new Pet() { Id = 7, Name = "Julien Király", Species = "Gyűrűsfarkú maki", Weight = 2.2, Age = 18, MonthlyCostInHUF = 30000, PetOwnerId = owner1.Id, VetId = vet1.Id, PetOwner = owner1, Vet = vet1 };

            vet1.PetPatients = new List<Pet> { pet1, pet6, pet7 };
            vet2.PetPatients = new List<Pet> { pet3, pet5 };
            vet3.PetPatients = new List<Pet> { pet2, pet4 };

            owner1.Pets = new List<Pet> { pet1, pet2, pet5, pet7 };
            owner2.Pets = new List<Pet> { pet3, pet6 };
            owner3.Pets = new List<Pet> { pet4 };

            var pets = new List<Pet>()
            {
                pet1, pet2, pet3, pet4, pet5, pet6, pet7
            }.AsQueryable();

            mockPetRepo.Setup(t => t.ReadAll()).Returns(pets);

            petLogic = new PetLogic(mockPetRepo.Object);
        }

    }
}
